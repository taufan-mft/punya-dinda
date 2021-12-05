Public Class PurchaseRaw
    Dim repository As Repository = Repository.getInstance()
    Dim selectedProduct As ProductModel
    Dim orderList As New List(Of PurchasingInvoiceItem)()
    Dim logistic As LogisticControllers = LogisticControllers.getInstance()
    Dim total = 0
    Private Sub PurchaseRaw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showData($"SELECT * FROM {TABLE_RAW_MATERIAL}", DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selectedProduct = repository.getSingleData(Of ProductModel)($"SELECT * FROM {TABLE_RAW_MATERIAL} WHERE id={TextBox5.Text}")
        TextBox6.Text = selectedProduct.name
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim entry As New PurchasingInvoiceItem(selectedProduct.name, CInt(TextBox1.Text), selectedProduct.id, CInt(TextBox7.Text), selectedProduct.price, CInt(TextBox7.Text) * selectedProduct.price)
        orderList.Add(entry)
        populateList()
    End Sub

    Private Sub populateList()
        ListView1.Items.Clear()
        For Each pesanan In orderList
            ListView1.Items.Add(New ListViewItem(New String() {pesanan.material_id, pesanan.name, pesanan.price, pesanan.quantity, pesanan.total_price}))
            total = total + pesanan.total_price
        Next
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim entry As New PurchasingInvoiceHead(TextBox1.Text, TextBox2.Text, total, TextBox3.Text)
        entry.saveData()
        For Each order In orderList
            order.saveData()
            logistic.insetRawStock(order.material_id, order.quantity, DIRECTION_IN)
        Next
    End Sub
End Class