Imports System.Data.OleDb

Public Class RawMaterialModel
    Inherits BaseModel
    Public id As Integer
    Public name_mat As String
    Public price As Integer

    Public Sub New(id As String, name_mat As String, price As Integer)
        Me.id = id
        Me.name_mat = name_mat
        Me.price = price
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.name, Me.price.ToString()}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.name_mat = list(1)
        Me.price = list(2)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_QC_HEAD} VALUES({Me.id}, '{Me.date_now}', {Me.production_id})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.name_mat = DM.GetString(1)
        Me.price = Dm.GetValue(2)
    End Sub

End Class
