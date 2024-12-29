Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class LoginForm
    ' URL API login
    Dim apiUrl As String = "http://localhost/arpeggio_web/admin/login.php" ' Ganti dengan URL API login Anda

    ' Ketika tombol login ditekan
    Private Async Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txUsername.Text
        Dim password As String = txPassword.Text

        ' Validasi input (username dan password tidak boleh kosong)
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Username dan password tidak boleh kosong.")
            Return
        End If

        ' Mengirimkan permintaan POST ke API login
        Dim response = Await SendLoginRequest(username, password)

        ' Mengecek apakah login berhasil berdasarkan respons API
        If response("success").ToString().ToLower() = "true" Then
            ' Login berhasil, tampilkan pesan atau pindahkan ke form utama admin
            MessageBox.Show("Login Successful!")

            ' Menyembunyikan form login
            Me.Hide()

            ' Tampilkan form utama admin
            Dim adminForm As New Index() ' Gantilah dengan nama form utama admin Anda
            adminForm.Show()
        Else
            ' Tampilkan pesan error jika login gagal
            MessageBox.Show("Login Failed: " & response("message").ToString())
        End If
    End Sub



    ' Fungsi untuk mengirim permintaan login ke API
    Private Async Function SendLoginRequest(username As String, password As String) As Task(Of JObject)
        Using client As New HttpClient()
            ' Menyiapkan data yang akan dikirim
            Dim content As New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"username", username},
                {"password", password}
            })

            ' Mengirim permintaan POST ke API login
            Dim result As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
            Dim resultContent As String = Await result.Content.ReadAsStringAsync()

            ' Mengembalikan respons JSON dalam bentuk JObject
            Return JObject.Parse(resultContent)
        End Using
    End Function

    ' Ketika tombol registrasi ditekan
    Private Sub btnRegistrasi_Click(sender As Object, e As EventArgs) Handles btnRegistrasi.Click
        ' Pindah ke form registrasi
        Me.Hide() ' Sembunyikan form login
        Dim registrasiForm As New RegistrasiForm() ' Buat instance form registrasi
        registrasiForm.Show() ' Tampilkan form registrasi
    End Sub
End Class
