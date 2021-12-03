Imports System.Data.OleDb

Public Class QcHeadModel
    Inherits BaseModel
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public date_now As String
    Public production_id As Integer

    Public Sub New(id As Integer, date_now As String, production_id As Integer)
        Me.id = id
        Me.date_now = date_now
        Me.production_id = production_id
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.date_now, Me.production_id}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.date_now = list(1)
        Me.production_id = list(2)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_QC_HEAD} VALUES({Me.id}, '{Me.date_now}', {Me.production_id})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.date_now = DM.GetString(1)
        Me.production_id = DM.GetValue(2)
    End Sub

End Class
