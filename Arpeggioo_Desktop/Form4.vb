Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text
Imports System.IO

Public Class ManageProduk
    ' Variable to hold the selected image file path
    Private selectedImagePath As String = String.Empty

    ' Method for adding a new product
    Private Async Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click
        Try
            ' Validate inputs
            If String.IsNullOrEmpty(txProduk.Text) OrElse String.IsNullOrEmpty(txHarga.Text) OrElse String.IsNullOrEmpty(txStok.Text) Then
                MessageBox.Show("Nama produk, harga, dan stok tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate that the price is positive and stock is non-negative
            Dim harga As Decimal
            Dim stok As Integer
            If Not Decimal.TryParse(txHarga.Text, harga) OrElse harga <= 0 Then
                MessageBox.Show("Harga harus lebih besar dari 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If Not Integer.TryParse(txStok.Text, stok) OrElse stok < 0 Then
                MessageBox.Show("Stok tidak boleh negatif.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Prepare HTTP client and multipart content
            Dim client As New HttpClient()
            Dim content As New MultipartFormDataContent()

            ' Add form data (product name, price, stock, description)
            content.Add(New StringContent(txProduk.Text), "nama")
            content.Add(New StringContent(txHarga.Text), "harga")
            content.Add(New StringContent(txStok.Text), "stok")
            content.Add(New StringContent(txDeskripsi.Text), "deskripsi")

            ' Ensure that a valid image file path is provided
            If Not String.IsNullOrEmpty(selectedImagePath) AndAlso File.Exists(selectedImagePath) Then
                content.Add(New ByteArrayContent(File.ReadAllBytes(selectedImagePath)), "image", Path.GetFileName(selectedImagePath))
            Else
                MessageBox.Show("File gambar tidak ditemukan atau path tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Indicate that the request is being processed
            ' You can add a loading animation or disable the button to prevent multiple clicks

            ' Send POST request
            Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost/arpeggio_web/admin/api_get_produk.php", content)

            ' Handle response
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                MessageBox.Show("Produk berhasil ditambahkan: " & responseString, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Reset form fields after successful submission
                txProduk.Clear()
                txHarga.Clear()
                txStok.Clear()
                txDeskripsi.Clear()
                selectedImagePath = String.Empty
            Else
                Dim errorResponse As String = Await response.Content.ReadAsStringAsync()
                MessageBox.Show("Terjadi kesalahan: " & errorResponse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Handle any unexpected errors
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Method for updating a product
    Private Async Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Try
            ' Validate inputs
            If String.IsNullOrEmpty(txIdProduk.Text) OrElse String.IsNullOrEmpty(txProduk.Text) OrElse String.IsNullOrEmpty(txHarga.Text) OrElse String.IsNullOrEmpty(txStok.Text) Then
                MessageBox.Show("Semua field harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Prepare HTTP client and data
            Dim client As New HttpClient()
            Dim data As New Dictionary(Of String, String) From {
            {"id", txIdProduk.Text},
            {"nama", txProduk.Text},
            {"harga", txHarga.Text},
            {"stok", txStok.Text},
            {"deskripsi", txDeskripsi.Text}
        }

            ' Serialize data into JSON format
            Dim jsonData As String = JsonConvert.SerializeObject(data)
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Send PUT request
            Dim apiUrl As String = "http://localhost/arpeggio_web/admin/api_get_produk.php"
            Dim response As HttpResponseMessage = Await client.PutAsync(apiUrl, content)

            ' Handle response
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                MessageBox.Show("Produk berhasil diperbarui: " & responseString, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim errorResponse As String = Await response.Content.ReadAsStringAsync()
                MessageBox.Show("Gagal memperbarui produk: " & errorResponse, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Handle any unexpected errors
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button click for uploading an image
    Private Sub btnUpImage_Click(sender As Object, e As EventArgs) Handles btnUpImage.Click
        ' Create an OpenFileDialog to allow the user to select an image file
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*"

        ' Show the dialog and check if the user selected a file
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Store the selected image file path in the selectedImagePath variable
            selectedImagePath = openFileDialog.FileName

            ' Optionally, display the selected file path (e.g., in a label or message box)
            MessageBox.Show("File gambar terpilih: " & selectedImagePath, "File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Btn_Kembali_Click(sender As Object, e As EventArgs) Handles Btn_Kembali.Click
        Me.Hide()
        Dim PanelAdmin As New Index()
        PanelAdmin.Show()
    End Sub
End Class
