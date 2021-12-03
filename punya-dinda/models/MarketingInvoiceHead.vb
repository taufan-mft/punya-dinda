Public Class MarketingInvoiceHead
    Inherits BaseModel
    Dim repository As Repository = Repository.getInstance()
    Public id As Integer
    Public invoice_code As String
    Public create_at As String
    Public total_price As Integer
    Public date_now As String
    Public customer_id As Integer


    Public Sub New(invoice_code As String,
                create_at As String,
                total_price As String,
                date_now As String, customer_id As Integer)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_MARKETING_DETAIL, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id = kode
        Me.invoice_code = invoice_code
        Me.create_at = create_at
        Me.total_price = total_price
        Me.date_now = date_now
        Me.customer_id = customer_id
    End Sub

    Sub saveData()
        Dim sql As String
        sql = $"INSERT INTO {TABLE_MARKETING_HEAD} VALUES({Me.id}, '{Me.invoice_code}', '{Me.create_at}', {Me.total_price}, '{Me.date_now}', {Me.customer_id})"
        repository.executeRaw(sql)
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.invoice_code, Me.create_at, Me.total_price, Me.date_now, Me.customer_id}
        Return dynArray
    End Function
End Class
