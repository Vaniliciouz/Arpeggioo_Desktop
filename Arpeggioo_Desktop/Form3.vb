Imports System.IO
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Data

Public Class Index
    Private dataTable As DataTable
    Private Shared ReadOnly client As New HttpClient()

    ' Fungsi untuk melakukan logout
    Private Async Function LogoutAsync() As Task
        Dim apiUrl As String = "http://localhost/arpeggio_web/admin/api_get_produk.php"

        Try
            Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Logout berhasil!", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                LoginForm.Show()
            Else
                MessageBox.Show("Terjadi kesalahan saat logout.", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Async Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Await LogoutAsync()
    End Sub

    ' Fungsi untuk memuat data dari API
    Private Async Function LoadDataAsync() As Task
        Dim jsonUrl As String = "http://localhost/arpeggio_web/admin/api_get_produk.php"

        Try
            Dim response As HttpResponseMessage = Await client.GetAsync(jsonUrl)
            response.EnsureSuccessStatusCode()

            Dim jsonData As String = Await response.Content.ReadAsStringAsync()
            dataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonData)

            DGVProduk.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Error fetching JSON data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' Memuat data saat form dimuat
    Private Async Sub Index_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadDataAsync()
    End Sub

    Private Async Sub Index_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Await LoadDataAsync()
        End If
    End Sub

    Private Sub btnData_Click(sender As Object, e As EventArgs) Handles btnData.Click
        Me.Hide() ' Sembunyikan form login
        Dim managrProduk As New ManageProduk() ' Buat instance form registrasi
        ManageProduk.Show() ' Tampilkan form registrasi
    End Sub
End Class
