Public Class Logistik
    Dim pendingInvoices As New List(Of MarketingInvoiceHead)
    Dim marketingCont = MarketingController.getInstance()
    Private Sub Logistik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pendingInvoices = marketingCont.getCompletedInvoices()
        ComboBox1.Items.Clear()
        For Each workOrder In pendingInvoices
            ComboBox1.Items.Add(workOrder.invoice_code)
        Next
    End Sub
End Class