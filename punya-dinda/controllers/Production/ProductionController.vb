Public Class ProductionController
    Private Shared objProd As ProductionController
    Dim repository As Repository = Repository.getInstance()

    Public Shared Function getInstance() As ProductionController
        If (objProd Is Nothing) Then
            objProd = New ProductionController()
        End If
        Return objProd
    End Function

    Function getPendingWorkOrders() As List(Of PpicWorkModel)
        Dim workOrders = repository.getManyData(Of PpicWorkModel)($"SELECT * FROM {TABLE_PPIC_HEAD} WHERE completed=0")
        Return workOrders
    End Function

    Function getCompleteWorkOrders() As List(Of PpicWorkModel)
        Return repository.getManyData(Of PpicWorkModel)($"SELECT * FROM {TABLE_PPIC_HEAD} WHERE completed=-1")
    End Function

    Function getSingleWo(workCode As String) As PpicWorkModel
        Return repository.getSingleData(Of PpicWorkModel)($"SELECT * FROM {TABLE_PPIC_HEAD} WHERE work_code='{workCode}'")
    End Function

    Function getProducts(workCode As String) As List(Of PpicProductPresentation)
        Dim workHead = repository.getSingleData(Of PpicWorkModel)($"SELECT * FROM {TABLE_PPIC_HEAD} WHERE work_code='{workCode}'")
        Dim workItems = repository.getManyData(Of PpicWorkItemModel)($"SELECT * FROM {TABLE_PPIC_ITEMS} WHERE ppic_wo_id={workHead.id}")
        Dim result As New List(Of PpicProductPresentation)
        For Each item In workItems
            Dim product = repository.getSingleData(Of ProductModel)($"SELECT * FROM {TABLE_PRODUK} WHERE id={item.product_id}")
            result.Add(New PpicProductPresentation(product.id, product.name, item.quantity))
        Next
        Return result
    End Function

    Function getProductsInvoice(invoiceCode As String) As List(Of PpicProductPresentation)
        Dim invHead = repository.getSingleData(Of MarketingInvoiceHead)($"SELECT * FROM {TABLE_MARKETING_HEAD} WHERE invoice_code='{invoiceCode}'")
        Dim workItems = repository.getManyData(Of MarketingInvoiceDetail)($"SELECT * FROM {TABLE_MARKETING_DETAIL} WHERE invoice_id={invHead.id}")
        Dim result As New List(Of PpicProductPresentation)
        For Each item In workItems
            Dim product = repository.getSingleData(Of ProductModel)($"SELECT * FROM {TABLE_PRODUK} WHERE id={item.id_produk}")
            result.Add(New PpicProductPresentation(product.id, product.name, item.jumlah))
        Next
        Return result
    End Function

End Class
