Imports System.Data.OleDb

Public Class LogisticStockModel
    Inherits BaseModel
    Dim repository As Repository = Repository.getInstance()
    Public id As String
    Public name As String
    Public quantity As Integer
    Public direction As Integer
    Dim tableName As String

    Public Sub New(nama As String, quantity As Integer, direction As Integer, isRaw As Boolean)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))

        If isRaw Then
            tableName = TABLE_LOGISTIC_RAW_STOCK
        Else
            tableName = TABLE_LOGISTIC_PRODUCT_STOCK
        End If
        While repository.checkDuplicateInteger(tableName, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id = kode
        Me.name = nama
        Me.quantity = quantity
        Me.direction = direction
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.name, Me.quantity, Me.direction}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.name = list(1)
        Me.quantity = list(2)
        Me.direction = list(3)
    End Sub

    Sub saveData(productId As Integer)
        Dim sql As String
        sql = $"INSERT INTO {tableName} VALUES({Me.id}, {productId}, {Me.quantity}, {Me.direction})"
        repository.executeRaw(sql)
    End Sub

    Public Sub New(reader As OleDbDataReader)
        Me.id = DM.GetValue(0)
        Debug.WriteLine($"nih valuee {DM.GetString(1)}")
        Me.name = DM.GetString(1)
        Me.quantity = DM.GetValue(2)
        Me.direction = DM.GetValue(3)
    End Sub

End Class
