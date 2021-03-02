Imports System.IO
Imports MadMilkman
Imports ICSharpCode.SharpZipLib

Module ModUtils
    Sub ReadFixedLengthRecords()

        ' Create an instance of StreamReader to read from a file.
        Dim sr As StreamReader = New StreamReader("C:\Users\john\source\repos\Sbmr\tmp\ELGATO\MESSAGES.DAT")
        Dim line As String
        Dim Head_System_Info As String
        ' Read and display the lines from the file until the end
        ' of the file is reached.
        Dim buff(128) As Char
        Dim rd As Integer = 128
        Dim index As Integer = 0
        Dim HeaderRecord As String = ""
        Dim x As Integer = 0
        Try
            While rd = 128
                rd = sr.Read(buff, 0, 127)
                line = New String(buff)
                If x = 0 Then
                    'fprintf(qwk,"%-128.128s","Produced by " VERSION_NOTICE "  " COPYRIGHT_NOTICE);
                    Head_System_Info = line
                End If
                If x = 1 Then
                    HeaderRecord = line
                End If
                'Console.WriteLine(line)
                x += 1
            End While
            sr.Close()
        Catch E As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(E.Message)
        End Try
        ' Process Header Record
        Dim Head_Message_Status As String
        Dim Head_Msg_Number As String
        Dim Head_DateTime As String
        Dim Head_to_Name As String
        Dim Head_from_Name As String
        Dim Head_Subject As String
        Dim Head_Password As String
        Dim Head_In_Reply_To As String
        Dim Head_Num_Blocks As String
        Dim Head_Message_Active As Byte
        Dim Head_Conf_Number As UInt16
        Dim Head_Relative_Msg As UInt16
        Dim Head_Tag_Present As Char

        DisplayField("Head_System_Info", Head_System_Info, 0)
        'Offset	Length	Format	Description
        '0   1	ASCII char	Message status (“*”, “+”, “~”, “`”, “%”, “^”, “#”, “$”, “-”, “ ”, Or “V”)
        Head_Message_Status = HeaderRecord.Substring(1, 1)
        DisplayField("Head_Message_Status", Head_Message_Status, 1)
        '1   7	ASCII string	message number for QWK packets, conference number for REP packets (7 decimal digits)
        Head_Msg_Number = HeaderRecord.Substring(2, 7)
        DisplayField("Head_Msg_Number", Head_Msg_Number, 2)
        '8   13	ASCII string	Date And time (“MM-DD-YYHH:MM”)
        Head_DateTime = HeaderRecord.Substring(9, 13)
        DisplayField("Head_DateTime", Head_DateTime, 3)
        '21  25	ASCII string	To name
        Head_to_Name = HeaderRecord.Substring(22, 25)
        DisplayField("Head_to_Name", Head_to_Name, 4)
        '46  25	ASCII string	From name
        Head_from_Name = HeaderRecord.Substring(47, 25)
        DisplayField("Head_from_Name", Head_from_Name, 5)
        '71  25	ASCII string	Subject
        Head_Subject = HeaderRecord.Substring(72, 25)
        DisplayField("Head_Subject", Head_Subject, 6)
        '96  12	ASCII string	Password (unused by Synchronet And un-populated by Synchronet)
        Head_Password = HeaderRecord.Substring(97, 12)
        DisplayField("Head_Password", Head_Password, 7)
        '108 8	ASCII string	In-reply-to message number (8 decimal digits)
        Head_In_Reply_To = HeaderRecord.Substring(109, 8)
        DisplayField("Head_In_Reply_To", Head_In_Reply_To, 8)
        '116 6	ASCII string	Number of blocks for the message, including header block (1+)
        Head_Num_Blocks = HeaderRecord.Substring(117, 6)
        DisplayField("Head_Num_Blocks", Head_Num_Blocks, 9)
        '122 1	byte	Message status: 225 = message active, 226 = message deleted
        Head_Message_Active = HeaderRecord.Substring(123, 1)
        DisplayField("Head_Message_Active", Head_Message_Active, 10)
        '123 2	uint16	Conference number
        Head_Conf_Number = HeaderRecord.Substring(124, 3)
        DisplayField("Head_Conf_Number", Head_Conf_Number, 11)
        '125 2	uint16	Relative message number in packet (1+) (unused And Not populated by Synchronet)
        Head_Relative_Msg = HeaderRecord.Substring(126, 2)
        DisplayField("Head_Relative_Msg", Head_Relative_Msg, 12)
        '127 1	ASCII char	Net tag line (“*” if present, “ ” otherwise)
        Head_Tag_Present = HeaderRecord.Substring(128, 1)
        DisplayField("Head_Tag_Present", Head_Tag_Present, 13)

    End Sub
    Sub DisplayField(myFieldName As String, myFieldValue As String, Optional myLineNumber As String = "0")
        If Val(myLineNumber) < 10 And myLineNumber <> "  " Then
            myLineNumber = " " & myLineNumber
        End If
        Console.ResetColor()
        Console.Write("|")
        Console.ForegroundColor = ConsoleColor.White
        Console.Write(myLineNumber & " ")
        Console.BackgroundColor = ConsoleColor.Blue
        Console.Write("{0,-25}", myFieldName)
        Console.Write(" : ")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write("{0,-40}", myFieldValue)
        Console.ForegroundColor = ConsoleColor.White
        Console.ResetColor()
        Console.Write(" |" & vbCrLf)

    End Sub
End Module
