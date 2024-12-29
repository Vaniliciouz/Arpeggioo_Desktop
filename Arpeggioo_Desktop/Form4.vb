Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class ManageProduk
    Private Async Sub BtnTambah_Click(sender As Object, e As EventArgs) Handles BtnTambah.Click

    End Sub



    Private Async Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click

    End Sub



    Private Async Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click

    End Sub



    Private Sub Btn_Data_Click(sender As Object, e As EventArgs) Handles Btn_Kembali.Click
        Me.Hide() ' Sembunyikan form login
        Dim Index As New Index() ' Buat instance form registrasi
        Index.Show() ' Tampilkan form registrasi
    End Sub

    Private Sub txProduk_TextChanged(sender As Object, e As EventArgs) Handles txProduk.TextChanged

    End Sub

    Private Sub txHarga_TextChanged(sender As Object, e As EventArgs) Handles txHarga.TextChanged

    End Sub

    Private Sub txDeskripsi_TextChanged(sender As Object, e As EventArgs) Handles txDeskripsi.TextChanged

    End Sub

    Private Sub txStok_TextChanged(sender As Object, e As EventArgs) Handles txStok.TextChanged

    End Sub

    Private Sub txImage_TextChanged(sender As Object, e As EventArgs)

    End Sub

End Class