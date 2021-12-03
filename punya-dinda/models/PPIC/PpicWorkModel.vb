Imports System.Data.OleDb

Public Class PpicWorkModel
    Inherits BaseModel
    Public id As Integer
    Public work_code As String
    Public date_now As String
    Public keterangan As String
    Public completed As Integer

    Public Sub New(id As Integer, work_code As String, keterangan As String, completed As String)
        Me.id = id
        Me.work_code = work_code
        Me.keterangan = keterangan
        Me.completed = completed
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.work_code, Me.date_now, Me.keterangan, Me.completed}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.work_code = list(1)
        Me.date_now = list(2)
        Me.keterangan = list(3)
        Me.completed = list(4)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_PPIC_HEAD} VALUES({Me.id}, '{Me.work_code}', '{Me.date_now}, '{Me.keterangan}', {Me.completed})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.work_code = DM.GetString(1)
        Me.date_now = DM.GetString(2)
        Me.keterangan = DM.GetString(3)
        Me.completed = DM. GetValue(4)
    End Sub

End Class
