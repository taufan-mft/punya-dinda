Imports System.Data.OleDb

Public Class QcItemModel
    Inherits BaseModel
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public qc_head_id As Integer
    Public product_id As Integer
    Public reject As Integer
    Public accept As Integer
    Public total As Integer

    Public Sub New(id As Integer, qc_head_id As Integer, product_id As Integer, reject As Integer, accept As Integer, total As Integer)
        Me.id = id
        Me.qc_head_id = qc_head_id
        Me.product_id = product_id
        Me.reject = reject
        Me.accept = accept
        Me.total = total
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id.ToString(), Me.product_id.ToString(), Me.reject.ToString(), Me.accept.ToString(), Me.total.ToString()}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.qc_head_id = list(1)
        Me.product_id = list(2)
        Me.reject = list(3)
        Me.accept = list(4)
        Me.total = list(5)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_QC_ITEMS} VALUES({Me.id}, {Me.qc_head_id}, {Me.product_id}, {Me.reject}, {Me.accept}, {Me.total})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.qc_head_id = DM.GetValue(1)
        Me.product_id = DM.GetValue(2)
        Me.reject = DM.GetValue(3)
        Me.accept = DM.GetValue(4)
        Me.total = DM.GetValue(5)
    End Sub

End Class
