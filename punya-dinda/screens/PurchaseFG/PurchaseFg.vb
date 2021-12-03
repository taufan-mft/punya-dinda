Public Class PurchaseFg
    Dim repository As Repository = Repository.getInstance()
    Dim selectedProduct As ProductModel
    Dim selectedCustomer As CustomerModel
    Dim orderList As New List(Of MarketingInvoiceDetail)()
    Dim total As Integer
    Private Sub PurchaseFg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showData($"SELECT * FROM {TABLE_PRODUK}", DataGridView1)
        repository.showData($"SELECT * FROM {TABLE_CUSTOMER}", DataGridView2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selectedProduct = repository.getSingleData(Of ProductModel)($"SELECT * FROM {TABLE_PRODUK} WHERE id={TextBox5.Text}")
        TextBox6.Text = selectedProduct.name
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        selectedCustomer = repository.getSingleData(Of CustomerModel)($"SELECT * FROM {TABLE_CUSTOMER} WHERE id={TextBox8.Text}")
        TextBox2.Text = selectedCustomer.name
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim entry As New MarketingInvoiceDetail(selectedProduct.name,
                                                TextBox1.Text,
                                                selectedProduct.id,
                                                TextBox7.Text,
                                                CInt(TextBox7.Text) * selectedProduct.price,
                                                selectedProduct.price)
        orderList.Add(entry)
        populateList()
    End Sub

    Private Sub populateList()
        ListView1.Items.Clear()
        For Each pesanan In orderList
            ListView1.Items.Add(New ListViewItem(New String() {pesanan.id_produk, pesanan.nama, pesanan.harga, pesanan.jumlah, pesanan.total}))
            total = total + pesanan.total
        Next
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'save here
    End Sub
End Class