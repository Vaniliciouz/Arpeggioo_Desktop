Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class RegistrasiForm
    ' URL API registrasi
    Dim apiUrl As String = "http://localhost/arpeggio_web/admin/register.php" ' Ganti dengan URL API registrasi Anda

    Private Sub txUserRegis_TextChanged(sender As Object, e As EventArgs) Handles txUserRegis.TextChanged
        ' Tidak ada logika tambahan untuk saat ini
    End Sub

    Private Sub txNamaRegis_TextChanged(sender As Object, e As EventArgs) Handles txNamaRegis.TextChanged
        ' Tidak ada logika tambahan untuk saat ini
    End Sub

    Private Sub txPassRegis_TextChanged(sender As Object, e As EventArgs) Handles txPassRegis.TextChanged
        ' Tidak ada logika tambahan untuk saat ini
    End Sub

    Private Async Sub btnRegistrasi_Click(sender As Object, e As EventArgs) Handles btnRegistrasi.Click
        ' Ambil data dari textbox
        Dim username As String = txUserRegis.Text
        Dim nama As String = txNamaRegis.Text
        Dim password As String = txPassRegis.Text

        ' Kirim data untuk registrasi
        Await SendRegistrationRequest(username, nama, password)

        ' Setelah registrasi, Anda dapat menambahkan logika lain jika perlu
    End Sub


    ' Fungsi untuk mengirim permintaan registrasi ke API
    Private Async Function SendRegistrationRequest(username As String, nama As String, password As String) As Task
        Using client As New HttpClient()
            ' Mengirimkan permintaan POST ke API registrasi
            Dim content As New FormUrlEncodedContent(New Dictionary(Of String, String) From {
             {"username", username},
             {"nama", nama},
             {"password", password}
         })

            Dim result As HttpResponseMessage = Await client.PostAsync(apiUrl, content)

            ' Membaca respons dari server
            Dim resultContent As String = Await result.Content.ReadAsStringAsync()

            ' Debug: menampilkan respons dari server
            Console.WriteLine(resultContent) ' Bisa juga MessageBox.Show(resultContent) untuk menampilkan di UI

            Try
                ' Parsing respons JSON
                Dim responseJson As JObject = JObject.Parse(resultContent)

                ' Memeriksa apakah registrasi sukses atau gagal
                If responseJson("success").ToString().ToLower() = "true" Then
                    MessageBox.Show("Registrasi berhasil!")
                Else
                    MessageBox.Show("Registrasi gagal: " & responseJson("message").ToString())
                End If
            Catch ex As Exception
                ' Jika gagal parse JSON
                MessageBox.Show("Error parsing JSON response: " & ex.Message & vbCrLf & resultContent)
            End Try
        End Using
    End Function



    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        ' Kembali ke form login
        Me.Hide()
        Dim loginForm As New LoginForm()
        loginForm.Show()
    End Sub
End Class
