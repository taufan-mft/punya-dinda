Public Class PpicProductPresentation
    Public productName As String
    Public quantity As Integer
    Public id As Integer

    Public Sub New(id As Integer, productName As String, quantity As Integer)
        Me.id = id
        Me.productName = productName
        Me.quantity = quantity
    End Sub
End Class
