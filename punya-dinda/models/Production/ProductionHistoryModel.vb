Public Class ProductionHistoryModel
    Public id As Integer
    Public woId As Integer
    Public date_now As String
    Dim repository As Repository = Repository.getInstance()

    Public Sub New(woId As Integer, date_now As String)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_PRODUCTION_HISTORY, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id = kode
        Me.woId = woId
        Me.date_now = date_now
    End Sub

    Sub saveData()
        Dim sql = $"INSERT INTO {TABLE_PRODUCTION_HISTORY} VALUES({Me.id}, {Me.woId}, '{Me.date_now}')"
        repository.executeRaw(sql)
    End Sub

End Class
