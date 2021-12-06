Imports System.Data.OleDb

Public Class LogisticHead
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public date_now As String
    Public estimation As String
    Public customer_id As Integer
    Public invoice_id As Integer

    Public Sub New(dateNow As String, est As String, customerId As Integer, invoiceId As Integer)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_LOGISTIC_DO_HEAD, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id = kode
        Me.date_now = dateNow
        Me.estimation = est
        Me.customer_id = customerId
        Me.invoice_id = invoiceId
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Me.date_now = DM.GetString(1)
        Me.estimation = DM.GetString(2)
        Me.customer_id = DM.GetValue(3)
        Me.invoice_id = DM.GetValue(4)
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_LOGISTIC_DO_HEAD} VALUES({Me.id}, '{Me.date_now}', '{Me.estimation}', {Me.customer_id}, {Me.invoice_id})"
        repository.executeRaw(sql)
    End Sub

End Class
