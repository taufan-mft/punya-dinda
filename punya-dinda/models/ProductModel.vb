Imports System.Data.OleDb

Public Class ProductModel
    Inherits BaseModel
    Dim repository As Repository = Repository.getInstance()
    Public id As String
    Public name As String
    Public price As Integer

    Public Sub New(id As String, nama As String, harga As Integer)
        Me.id = id
        Me.name = nama
        Me.price = harga
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.name, Me.price.ToString()}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.name = list(1)
        Me.price = list(2)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Me.name = DM.GetString(1)
        Me.price = CInt(DM.GetString(2))
    End Sub

End Class
