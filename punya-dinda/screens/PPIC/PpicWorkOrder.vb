Public Class PpicWorkOrder
    Dim repository As Repository = Repository.getInstance()
    Dim orderList As New List(Of MarketingInvoiceDetail)()
    Dim selectedProduct As ProductModel
    Private Sub PpicWorkOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showData($"SELECT * FROM {TABLE_PRODUK}", DataGridView1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim entry As New PpicWorkModel(CInt(TextBox1.Text), TextBox8.Text, TextBox3.Text, TextBox2.Text, 0)
        entry.saveData()
        For Each product In orderList
            Dim newEnt As New PpicWorkItemModel(entry.id, product.id_produk, product.jumlah)
            newEnt.saveData()
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim entry As New MarketingInvoiceDetail(selectedProduct.name, TextBox1.Text, selectedProduct.id, TextBox7.Text, 0, 0)
        orderList.Add(entry)
        populateList()
    End Sub

    Private Sub populateList()
        ListView1.Items.Clear()
        For Each pesanan In orderList
            ListView1.Items.Add(New ListViewItem(New String() {pesanan.id_produk, pesanan.nama, pesanan.jumlah}))
        Next
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selectedProduct = repository.getSingleData(Of ProductModel)($"SELECT * FROM {TABLE_PRODUK} WHERE id={TextBox5.Text}")
        TextBox6.Text = selectedProduct.name
    End Sub
End Class