Public Class LogisticControllers
    Private Shared objLogistic As LogisticControllers
    Dim repository As Repository = Repository.getInstance()

    Public Shared Function getInstance() As LogisticControllers
        If (objLogistic Is Nothing) Then
            objLogistic = New LogisticControllers()
        End If
        Return objLogistic
    End Function

    Function getProductStock() As List(Of LogisticProductStatusPresentation)
        Dim products As New List(Of ProductModel)
        Dim result As New List(Of LogisticProductStatusPresentation)
        products = repository.getManyData(Of ProductModel)($"SELECT * FROM {TABLE_PRODUK}")
        For Each product In products
            Dim productStocks As List(Of LogisticStockModel)
            Dim total = 0
            Dim sql = $"SELECT logistic_product_stock.id, product.name_product, logistic_product_stock.quantity, logistic_product_stock.direction FROM product INNER JOIN logistic_product_stock ON product.id = logistic_product_stock.product_id WHERE (((product.id)={product.id}))"
            productStocks = repository.getManyData(Of LogisticStockModel)(sql)
            For Each stock In productStocks
                If stock.direction = DIRECTION_IN Then
                    total = total + stock.quantity
                Else
                    total = total - stock.quantity
                End If
            Next
            result.Add(New LogisticProductStatusPresentation(product.id, product.name, total))
        Next
        Return result
    End Function

    Function getRawStock() As List(Of LogisticProductStatusPresentation)
        Dim products As New List(Of ProductModel)
        Dim result As New List(Of LogisticProductStatusPresentation)
        products = repository.getManyData(Of ProductModel)($"SELECT * FROM {TABLE_RAW_MATERIAL}")
        For Each product In products
            Dim rawStocks As List(Of LogisticStockModel)
            Dim total = 0
            Dim sql = $"SELECT logistic_raw_stock.id, raw_material.name_mat, logistic_raw_stock.quantity, logistic_raw_stock.direction FROM raw_material INNER JOIN logistic_raw_stock ON raw_material.id = logistic_raw_stock.material_id WHERE (((raw_material.id)={product.id}))"
            rawStocks = repository.getManyData(Of LogisticStockModel)(sql)
            For Each stock In rawStocks
                If stock.direction = DIRECTION_IN Then
                    total = total + stock.quantity
                Else
                    total = total - stock.quantity
                End If
            Next
            result.Add(New LogisticProductStatusPresentation(product.id, product.name, total))
        Next
        Return result
    End Function

    Sub insertFinishedStock(productId As Integer, quantity As Integer, direction As Integer)
        Dim logi = New LogisticStockModel("", quantity, direction, False)
        logi.saveData(productId)
    End Sub

    Sub insetRawStock(materialId As Integer, quantity As Integer, direction As Integer)
        Dim logi = New LogisticStockModel("", quantity, direction, True)
        logi.saveData(materialId)
    End Sub

End Class
