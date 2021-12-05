Public Class WareHouse
    Dim repository As Repository = Repository.getInstance()
    Private Sub WareHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showData($"SELECT * FROM {TABLE_LOGISTIC_RAW_STOCK}", DataGridView1)
        repository.showData($"SELECT * FROM {TABLE_LOGISTIC_PRODUCT_STOCK}", DataGridView2)
    End Sub
End Class