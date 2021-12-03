Public Class products01
    Dim repository As Repository = Repository.getInstance()
    Dim idProduk As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not checkEmpty(TextBox1, TextBox2, TextBox3) Then
            If Not repository.checkDuplicate(TABLE_PRODUK, "id", TextBox1.Text) Then
                idProduk = TextBox1.Text
                repository.saveData(TABLE_PRODUK, TextBox1, TextBox2, TextBox3)
                repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
            Else
                MsgBox("ID tidak boleh sama.")

            End If
        Else
            MsgBox("Masih ada yang kosong.")
        End If
    End Sub
    Private Sub DGV_MouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        repository.showtoBox(e.RowIndex, DataGridView1, TextBox1, TextBox2, TextBox3)

    End Sub
    Private Sub Produk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
        Label4.Text = $"Nama: {repository.name}"
        canWeAccessThis(New List(Of String)({ROLE_ADMIN, ROLE_MANAGER}), Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        repository.updateData(TABLE_PRODUK, "id", TextBox1.Text, "name_product", TextBox2.Text, "price", TextBox3.Text)
        repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        repository.hapusData(TABLE_PRODUK, "id", TextBox1.Text)
        repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
    End Sub


End Class