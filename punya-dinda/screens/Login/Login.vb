Public Class Login
    Dim repository As Repository = Repository.getInstance()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        repository.changeUserData("Tania Wijaya", "manager")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        products01.Show()
    End Sub
End Class