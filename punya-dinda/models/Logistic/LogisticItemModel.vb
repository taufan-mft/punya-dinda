Imports System.Data.OleDb

Public Class LogisticItemModel
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public invoice_id As Integer
    Public product_id As Integer

    Public Sub New(invoiceId As Integer, productId As Integer)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_LOGISTIC_DO_DETAIL, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id = kode
        Me.invoice_id = invoiceId
        Me.product_id = productId
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Me.invoice_id = DM.GetValue(1)
        Me.product_id = DM.GetValue(2)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_LOGISTIC_DO_DETAIL} VALUES({Me.id}, {Me.invoice_id}, {Me.product_id})"
        repository.executeRaw(sql)
    End Sub
End Class
