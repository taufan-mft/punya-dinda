Public Class PpicMainForm
    Dim logistic As LogisticControllers = LogisticControllers.getInstance()
    Dim marketing As MarketingController = MarketingController.getInstance()
    Dim productStock As List(Of LogisticProductStatusPresentation)
    Dim rawStock As List(Of LogisticProductStatusPresentation)
    Dim productRequired As List(Of LogisticProductStatusPresentation)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub PpicMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productStock = logistic.getProductStock()
        rawStock = logistic.getRawStock()
        productRequired = marketing.getProductRequirements()
        For Each product In productRequired
            ListView1.Items.Add(New ListViewItem(New String() {product.id, product.name, product.quantity}))
        Next
        For Each product In productStock
            ListView3.Items.Add(New ListViewItem(New String() {product.id, product.name, product.quantity}))
        Next
        For Each raw In rawStock
            ListView2.Items.Add(New ListViewItem(New String() {raw.id, raw.name, raw.quantity}))
        Next
    End Sub
End Class