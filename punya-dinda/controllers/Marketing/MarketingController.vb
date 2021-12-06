Public Class MarketingController
    Private Shared objLogistic As MarketingController
    Dim repository As Repository = Repository.getInstance()

    Public Shared Function getInstance() As MarketingController
        If (objLogistic Is Nothing) Then
            objLogistic = New MarketingController()
        End If
        Return objLogistic
    End Function

    Function getProductRequirements() As List(Of LogisticProductStatusPresentation)
        Dim result As New List(Of LogisticProductStatusPresentation)
        Dim products = repository.getManyData(Of ProductModel)($"SELECT * FROM {TABLE_PRODUK}")
        For Each product In products
            Dim total = 0
            Dim details = repository.getManyData(Of MarketingInvoiceDetail)($"SELECT marketing_invoice_items.* FROM product INNER JOIN (marketing_invoice_head INNER JOIN marketing_invoice_items ON marketing_invoice_head.id = marketing_invoice_items.invoice_id) ON product.id = marketing_invoice_items.product_id WHERE (((product.id)={product.id}) AND ((marketing_invoice_head.create_at)=''))")
            For Each detail In details
                total = total + detail.jumlah
            Next
            result.Add(New LogisticProductStatusPresentation(product.id, product.name, total))
        Next
        Return result
    End Function

    Function getCompletedInvoices() As List(Of MarketingInvoiceHead)
        Return repository.getManyData(Of MarketingInvoiceHead)($"SELECT * FROM {TABLE_MARKETING_HEAD} WHERE create_at=''")
    End Function

End Class
