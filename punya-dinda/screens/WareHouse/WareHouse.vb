Public Class WareHouse
    Dim repository As Repository = Repository.getInstance()
    Dim logistic = LogisticControllers.getInstance()
    Private Sub WareHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim productStock = logistic.getProductStock()
        Dim rawStock = logistic.getRawStock()
        For Each product In productStock
            ListView1.Items.Add(New ListViewItem(New String() {product.id, product.name, product.quantity}))
        Next
        For Each raw In rawStock
            ListView2.Items.Add(New ListViewItem(New String() {raw.id, raw.name, raw.quantity}))
        Next
    End Sub
End Class