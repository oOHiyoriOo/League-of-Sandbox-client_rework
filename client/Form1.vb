Imports System
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Form1
    Dim path As String
    Dim uname, pw As String
    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim reader As StreamReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        path = My.Computer.FileSystem.CurrentDirectory
        Me.BackgroundImage = System.Drawing.Image.FromFile(path + "\DATA\images\diana_background.png")
    End Sub

    Private Sub password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles password.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Login_Click(sender, e)
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles register.Click
        If server.Text <> "" Then
            If username.Text <> "" And password.Text <> "" Then

                request = DirectCast(WebRequest.Create(server.Text + "/ex/"), HttpWebRequest)

                response = DirectCast(request.GetResponse(), HttpWebResponse)
                reader = New StreamReader(response.GetResponseStream())

                Dim rawresp As String
                rawresp = reader.ReadToEnd()

                Dim array As JArray = JArray.Parse(rawresp)

                For Each item As JObject In array
                    Dim name As String = If(item("name") Is Nothing, "", item("name").ToString())
                    Dim email As String = If(item("email") Is Nothing, "", item("email").ToString())
                    Console.WriteLine("Name: " & name)
                    Console.WriteLine("Email: " & email)
                Next

            Else
                MsgBox("Password or Username Empty")
            End If
        Else
            MsgBox("Pls Define a Server First")
        End If
    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        If username.Text <> "" And password.Text <> "" And server.Text <> "" Then
            MsgBox("Login")
        Else
            If username.Text = "" Then
                MsgBox("Username is Empty")
                username.Focus()
            ElseIf password.Text = "" Then
                MsgBox("Password is Empty")
                password.Focus()
            Else
                MsgBox("No Server us Defind")
                server.Focus()
            End If
        End If
    End Sub
End Class
