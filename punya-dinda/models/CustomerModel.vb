Imports System.Data.OleDb

Public Class CustomerModel
    Inherits BaseModel
    Public id As String
    Public name As String
    Public address As String
    Public phone As String

    Public Sub New(id As String, nama As String, address As String, phone As String)
        Me.id = id
        Me.name = nama
        Me.address = address
        Me.phone = phone
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.name, Me.address, Me.phone}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.name = list(1)
        Me.address = list(2)
        Me.phone = list(3)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.name = DM.GetString(1)
        Me.address = DM.GetString(2)
        Me.phone = DM.GetString(3)
    End Sub

End Class
