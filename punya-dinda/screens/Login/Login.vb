Public Class Login
    Dim repository As Repository = Repository.getInstance()
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        repository.changeUserData("Tania Wijaya", "manager")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        repository.loginUser(TextBox1.Text, TextBox2.Text, Me)
    End Sub
End Class