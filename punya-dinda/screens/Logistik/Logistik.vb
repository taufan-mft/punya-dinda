Public Class Logistik
    Dim pendingInvoices As New List(Of MarketingInvoiceHead)
    Dim repository As Repository = Repository.getInstance()
    Dim marketingCont = MarketingController.getInstance()
    Dim prodCont = ProductionController.getInstance()
    Dim products As New List(Of PpicProductPresentation)
    Dim selectedInvoice As MarketingInvoiceHead
    Dim selectedCust As CustomerModel
    Private Sub Logistik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pendingInvoices = marketingCont.getCompletedInvoices()
        ComboBox1.Items.Clear()
        For Each workOrder In pendingInvoices
            ComboBox1.Items.Add(workOrder.invoice_code)
        Next
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        selectedInvoice = repository.getSingleData(Of MarketingInvoiceHead)($"SELECT * FROM {TABLE_MARKETING_HEAD} WHERE invoice_code='{ComboBox1.SelectedItem.ToString()}'")
        selectedCust = repository.getSingleData(Of CustomerModel)($"SELECT * FROM {TABLE_CUSTOMER} WHERE id={selectedInvoice.customer_id}")
        TextBox3.Text = selectedCust.name
        products = prodCont.getProductsInvoice(selectedInvoice.invoice_code)
        ListView1.Items.Clear()
        For Each product In products
            ListView1.Items.Add(New ListViewItem(New String() {product.id, product.productName, product.quantity}))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim head As New LogisticHead(TextBox1.Text, TextBox2.Text, selectedCust.id, selectedInvoice.id)
        head.saveData()
        For Each product In products
            Dim entry As New LogisticItemModel(head.id, product.id)
            entry.saveData()
            Dim logisticStock As New LogisticStockModel("", product.quantity, DIRECTION_OUT, False)
            logisticStock.saveData(product.id)
        Next
        selectedInvoice.updateCompleted(TextBox1.Text)
    End Sub
End Class