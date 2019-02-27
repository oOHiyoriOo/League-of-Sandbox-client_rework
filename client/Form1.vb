Public Class Form1
    Dim path As String
    Dim uname, pw As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        path = My.Computer.FileSystem.CurrentDirectory
        Me.BackgroundImage = System.Drawing.Image.FromFile(path + "\DATA\images\diana_background.png")
    End Sub

    Private Sub password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles password.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Login_Click(sender, e)
        End If
    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        If username.Text <> "" And password.Text <> "" Then
            MsgBox("Login")
        Else
            If username.Text = "" Then
                MsgBox("Username is Empty")
                username.Focus()
            Else
                MsgBox("Password is Empty")
                password.Focus()
            End If
        End If
    End Sub
End Class
