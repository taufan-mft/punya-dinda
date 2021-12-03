Imports System.Data.OleDb

Public Class PpicWorkItemModel
    Inherits BaseModel
    Public id As Integer
    Public ppic_wo_id As Integer
    Public product_id As Integer
    Public quantity As Integer

    Public Sub New(ppic_wo_id As Integer, product_id As Integer, quantity As Integer)
    Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_MARKETING_DETAIL, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id = kode
        Me.ppic_wo_id = ppic_wo_id
        Me.product_id = product_id
        Me.quantity = quantity
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.ppic_wo_id, Me.product_id Me.quantity}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.ppic_wo_id = list(1)
        Me.product_id = list(2)
        Me.quantity = list(3)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_PPIC_ITEMS} VALUES({Me.id}, {Me.ppic_wo_id}, {Me.product_id}, {Me.quantity})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.ppic_wo_id = DM.GetString(1)
        Me.product_id = DM.GetString(2)
        Me.quantity = DM.GetString(3)
    End Sub

End Class
