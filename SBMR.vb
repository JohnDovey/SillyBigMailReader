
Imports MadMilkman.Ini
Imports ICSharpCode.SharpZipLib


Public Class SBMR
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        'New Message
        MsgBox("Compose a new Message",, "Not Yet Implemented")
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        'Open a QWK Packet
        MsgBox("Open a QWK Packet",, "Not Yet Implemented")
        ReadFixedLengthRecords()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' Send Replies
        MsgBox("Send Reply Packet",, "Not Yet Implemented")
    End Sub

    Private Sub SBMR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load
    End Sub
End Class