Public Class Form1
    Dim path As String
    Dim uname, pw As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        path = My.Computer.FileSystem.CurrentDirectory
        Me.BackgroundImage = System.Drawing.Image.FromFile(path + "\DATA\images\diana_background.png")
    End Sub
    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        If username.Text <> "" And password.Text <> "" Then MsgBox(username.Text + ":" + password.Text)
    End Sub
End Class
