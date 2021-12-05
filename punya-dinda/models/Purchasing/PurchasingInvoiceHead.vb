Imports System.Data.OleDb

Public Class PurchasingInvoiceHead
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public date_now As String
    Public total As Integer
    Public received_date As String

    Public Sub New(id As Integer, date_now As String, total As Integer, received_date As String)
        Me.id = id
        Me.date_now = date_now
        Me.total = total
        Me.received_date = received_date
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_PURCHASING_HEAD} VALUES ({Me.id}, '{Me.date_now}', {Me.total}, '{Me.received_date}')"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Me.date_now = DM.GetString(1)
        Me.total = DM.GetValue(2)
        Me.received_date = DM.GetString(3)
    End Sub

End Class
