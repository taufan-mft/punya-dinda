Public Class Customer
    Dim repository As Repository = Repository.getInstance()

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_CUSTOMER, DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not checkEmpty(TextBox1, TextBox2, TextBox3) Then
            If Not repository.checkDuplicate(TABLE_CUSTOMER, "id", TextBox1.Text) Then
                repository.saveData(TABLE_CUSTOMER, TextBox1, TextBox2, TextBox3, TextBox4)
                repository.showDataFromTable(TABLE_CUSTOMER, DataGridView1)
            Else
                MsgBox("ID tidak boleh sama.")
            End If
        Else
            MsgBox("Masih ada yang kosong.")
        End If
    End Sub
    Private Sub DGV_MouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        repository.showtoBox(e.RowIndex, DataGridView1, TextBox1, TextBox2, TextBox3, TextBox4)

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        repository.updateData(TABLE_CUSTOMER, "id", TextBox1.Text,
                              "name_customer",
                              TextBox2.Text,
                              "address",
                              TextBox3.Text,
                               "phone_number",
                                TextBox4.Text)
        repository.showDataFromTable(TABLE_CUSTOMER, DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        repository.hapusData(TABLE_CUSTOMER, "id", TextBox1.Text)
        repository.showDataFromTable(TABLE_CUSTOMER, DataGridView1)
    End Sub
End Class