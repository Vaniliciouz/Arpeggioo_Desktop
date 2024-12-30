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

            ' Tambahkan kolom tombol hapus jika belum ada
            If Not DGVProduk.Columns.Contains("Hapus") Then
                Dim deleteButton As New DataGridViewButtonColumn()
                deleteButton.Name = "Hapus"
                deleteButton.HeaderText = "Action"
                deleteButton.Text = "Hapus"
                deleteButton.UseColumnTextForButtonValue = True
                DGVProduk.Columns.Add(deleteButton)
            End If
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

    Private Async Function DeleteProdukAsync(id As Integer) As Task
        Dim deleteUrl As String = $"http://localhost/arpeggio_web/admin/api_get_produk.php?id={id}"

        Try
            Dim response As HttpResponseMessage = Await client.DeleteAsync(deleteUrl)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Produk berhasil dihapus.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await LoadDataAsync() ' Perbarui data setelah penghapusan
            Else
                MessageBox.Show("Gagal menghapus produk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' Event handler untuk klik tombol hapus di DataGridView
    Private Async Sub DGVProduk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVProduk.CellContentClick
        If e.ColumnIndex = DGVProduk.Columns("Hapus").Index AndAlso e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DGVProduk.Rows(e.RowIndex)
            Dim id As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

            Dim confirmResult = MessageBox.Show($"Apakah Anda yakin ingin menghapus produk dengan ID {id}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmResult = DialogResult.Yes Then
                Await DeleteProdukAsync(id)
            End If
        End If
    End Sub
End Class
