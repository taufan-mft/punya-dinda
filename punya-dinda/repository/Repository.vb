Imports System.Data.OleDb

Public Class Repository
    Private Shared objRepository As Repository
    Private Sub New()
        koneksiDB()
    End Sub

    Public Shared Function getInstance() As Repository
        If (objRepository Is Nothing) Then
            objRepository = New Repository()
        End If
        Return objRepository
    End Function

    Sub nukeTable(tableName As String)
        Dim sql As String
        sql = "DELETE FROM " + tableName
        CMD = New OleDb.OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader
        MsgBox("Data terhapus.")
    End Sub
    Sub showData(sql As String, DGV As DataGridView)
        DA = New OleDb.OleDbDataAdapter(sql, Conn)
        DS = New DataSet
        DA.Fill(DS)

        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True

    End Sub
End Class
