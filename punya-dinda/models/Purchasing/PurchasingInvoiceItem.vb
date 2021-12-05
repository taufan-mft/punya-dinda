Imports System.Data.OleDb

Public Class PurchasingInvoiceItem
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public invoice_id As Integer
    Public material_id As Integer
    Public quantity As Integer
    Public price As Integer
    Public total_price As Integer
    Public name As String

    Public Sub New(name As String, invoice_id As Integer, material_id As Integer, quantity As Integer, price As Integer, total_price As Integer)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_PURCHASING_ITEMS, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        id = kode
        Me.invoice_id = invoice_id
        Me.material_id = material_id
        Me.quantity = quantity
        Me.price = price
        Me.total_price = total_price
        Me.name = name
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_PURCHASING_ITEMS} VALUES ({Me.id}, {Me.invoice_id}, {Me.material_id}, {Me.quantity}, {Me.price}, {Me.total_price})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Me.invoice_id = DM.GetValue(1)
        Me.material_id = DM.GetValue(2)
        Me.quantity = DM.GetValue(3)
        Me.price = DM.GetValue(4)
        Me.total_price = DM.GetValue(5)
    End Sub

End Class
