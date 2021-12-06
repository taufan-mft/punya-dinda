Public Class QCForm
    Dim prodCont = ProductionController.getInstance()
    Dim completeOrders As New List(Of PpicWorkModel)()
    Dim selectedWo As PpicWorkModel
    Private Sub QCForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        completeOrders = prodCont.getCompleteWorkOrders()
        ComboBox1.Items.Clear()
        For Each workOrder In completeOrders
            ComboBox1.Items.Add(workOrder.work_code)
        Next
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        selectedWo = prodCont.getSingleWo(ComboBox1.SelectedItem.ToString())
        Dim products As New List(Of PpicProductPresentation)
        products = prodCont.getProducts(selectedWo.work_code)
        DataGridView1.Rows.Clear()
        For Each product In products
            DataGridView1.Rows.Add(New String() {product.id, product.productName, product.quantity, "0", product.quantity})
        Next
        For Each row As DataGridViewRow In DataGridView1.Rows
            Debug.WriteLine(row.Cells(1).Value)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selectedWo.updateQced()
        Dim head = New QcHeadModel(TextBox1.Text, selectedWo.id)
        head.saveData()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value <> 0 Then
                Dim entry = New QcItemModel(head.id, row.Cells(0).Value, row.Cells(3).Value, row.Cells(2).Value, row.Cells(4).Value)
                entry.saveData()
                Dim logisEntry = New LogisticStockModel("", entry.total, DIRECTION_IN, False)
                logisEntry.saveData(entry.product_id)
            End If

        Next
        completeOrders = prodCont.getCompleteWorkOrders()
        ComboBox1.Items.Clear()
        For Each workOrder In completeOrders
            ComboBox1.Items.Add(workOrder.work_code)
        Next

    End Sub
End Class