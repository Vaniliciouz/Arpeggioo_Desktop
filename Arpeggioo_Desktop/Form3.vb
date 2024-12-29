Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class Index
    Dim apiUrl As String = "http://localhost/arpeggio_web/admin/index.php"

    ' Fungsi untuk melakukan logout
    Private Async Function LogoutAsync() As Task
        Using client As New HttpClient()
            Try
                ' Kirim permintaan GET ke API logout
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)

                ' Periksa apakah status code adalah OK (200)
                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Logout berhasil!", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Hide()
                    LoginForm.Show()
                Else
                    MessageBox.Show("Terjadi kesalahan saat logout.", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Tangani error jika permintaan gagal
                MessageBox.Show("Terjadi kesalahan koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    Private Async Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Await LogoutAsync()
    End Sub

    ' Kelas untuk mewakili data produk
    Public Class Produk
        Public Property Nama As String
        Public Property Harga As Decimal
        Public Property Deskripsi As String
        Public Property Image As Image
        Public Property Stok As Integer
        Public Property Admin As String
    End Class

    ' Inisialisasi DataGridView
    Private Sub SetupDataGridView()
        DGVProduk.Columns.Clear()

        ' Kolom Nama
        Dim colNama As New DataGridViewTextBoxColumn()
        colNama.HeaderText = "Nama"
        colNama.DataPropertyName = "Nama"
        DGVProduk.Columns.Add(colNama)

        ' Kolom Harga
        Dim colHarga As New DataGridViewTextBoxColumn()
        colHarga.HeaderText = "Harga"
        colHarga.DataPropertyName = "Harga"
        colHarga.DefaultCellStyle.Format = "Rp ###,###,##0"
        DGVProduk.Columns.Add(colHarga)

        ' Kolom Deskripsi
        Dim colDeskripsi As New DataGridViewTextBoxColumn()
        colDeskripsi.HeaderText = "Deskripsi"
        colDeskripsi.DataPropertyName = "Deskripsi"
        DGVProduk.Columns.Add(colDeskripsi)

        ' Kolom Gambar
        Dim colImage As New DataGridViewImageColumn()
        colImage.HeaderText = "Image"
        colImage.DataPropertyName = "Image"
        colImage.ImageLayout = DataGridViewImageCellLayout.Zoom
        DGVProduk.Columns.Add(colImage)

        ' Kolom Stok
        Dim colStok As New DataGridViewTextBoxColumn()
        colStok.HeaderText = "Stok"
        colStok.DataPropertyName = "Stok"
        DGVProduk.Columns.Add(colStok)

        ' Kolom Admin
        Dim colAdmin As New DataGridViewTextBoxColumn()
        colAdmin.HeaderText = "Admin"
        colAdmin.DataPropertyName = "Admin"
        DGVProduk.Columns.Add(colAdmin)

        ' Kolom Edit
        Dim btnEdit As New DataGridViewButtonColumn()
        btnEdit.HeaderText = "Ubah"
        btnEdit.Text = "Edit"
        btnEdit.UseColumnTextForButtonValue = True
        DGVProduk.Columns.Add(btnEdit)

        ' Kolom Hapus
        Dim btnHapus As New DataGridViewButtonColumn()
        btnHapus.HeaderText = "Hapus"
        btnHapus.Text = "Hapus"
        btnHapus.UseColumnTextForButtonValue = True
        DGVProduk.Columns.Add(btnHapus)
    End Sub

    ' Memuat data dari API
    Private Async Function LoadDataFromAPI() As Task
        Dim apiUrl As String = "http://localhost/arpeggio_web/admin/api_get_produk.php"

        Using client As New HttpClient()
            Try
                Dim response = Await client.GetStringAsync(apiUrl)
                Dim produkList = JsonConvert.DeserializeObject(Of List(Of Produk))(response)

                ' Set data ke DataGridView
                DGVProduk.DataSource = New BindingSource() With {.DataSource = produkList}
            Catch ex As Exception
                ' Tangani kesalahan koneksi atau parsing JSON
                MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    ' Event handler untuk klik pada DataGridView
    Private Sub DGVProduk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVProduk.CellContentClick
        If e.RowIndex >= 0 Then
            Dim selectedRow = DGVProduk.Rows(e.RowIndex)

            ' Tangani tombol Edit atau Hapus
            If TypeOf DGVProduk.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                Dim colName = DGVProduk.Columns(e.ColumnIndex).HeaderText
                Dim namaProduk = selectedRow.Cells("Nama").Value.ToString()

                If colName = "Ubah" Then
                    MessageBox.Show("Edit produk: " & namaProduk)
                ElseIf colName = "Hapus" Then
                    Dim result = MessageBox.Show("Hapus produk: " & namaProduk & "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.Yes Then
                        ' Logika hapus data di sini
                        MessageBox.Show("Produk berhasil dihapus!")
                    End If
                End If
            End If
        End If
    End Sub

    ' Event saat form dimuat
    Private Async Sub Index_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        Await LoadDataFromAPI()
    End Sub
End Class
