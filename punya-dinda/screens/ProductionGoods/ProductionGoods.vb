Public Class ProductionGoods
    Dim prodCont As ProductionController = ProductionController.getInstance()
    Dim pendingWo As New List(Of PpicWorkModel)()
    Dim selectedWo As PpicWorkModel
    Private Sub ProductionGoods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pendingWo = prodCont.getPendingWorkOrders()
        ComboBox1.Items.Clear()
        For Each workOrder In pendingWo
            ComboBox1.Items.Add(workOrder.work_code)
        Next
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Debug.WriteLine($"isi combobox nih tan {ComboBox1.SelectedItem.ToString()}")
        selectedWo = prodCont.getSingleWo(ComboBox1.SelectedItem.ToString())
        Dim products = prodCont.getProducts(selectedWo.work_code)
        ListView1.Items.Clear()
        For Each pesanan In products
            ListView1.Items.Add(New ListViewItem(New String() {pesanan.id, pesanan.productName, pesanan.quantity}))
        Next
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selectedWo.updateCompleted()
        Dim prodEntry = New ProductionHistoryModel(selectedWo.id, TextBox1.Text)
        prodEntry.saveData()
        pendingWo = prodCont.getPendingWorkOrders()
        ComboBox1.Items.Clear()
        For Each workOrder In pendingWo
            ComboBox1.Items.Add(workOrder.work_code)
        Next
        ListView1.Items.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.ResetText()
        TextBox1.Text = ""
    End Sub
End Class