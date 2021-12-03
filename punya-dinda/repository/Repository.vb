Imports System.Data.OleDb

Public Class Repository
    Private Shared objRepository As Repository
    Public name As String
    Public role As String
    Private Sub New()
        koneksiDB()
    End Sub

    Sub changeUserData(name As String, role As String)
        Me.name = name
        Me.role = role
    End Sub

    Sub loginUser(username As String, password As String, form As Form)
        Dim sql = $"SELECT * FROM {TABLE_USER} WHERE username='{username}' AND password='{password}'"
        CMD = New OleDb.OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader()
        Dim result = 0
        If DM.HasRows = True Then
            While DM.Read
                result = 1
                Me.name = DM.GetString(4)
                Me.role = DM.GetString(3)
            End While
        End If

        If result <> 0 Then
            form.Hide()
            Form1.Show()
        Else
            MsgBox("ANDA SIAPA?")
        End If

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

    Function checkDuplicate(tableName As String, idName As String, id As String)
        Dim sequel As String
        sequel = "select * from " + tableName + " where " + idName + " = " + id + ""
        CMD = New OleDb.OleDbCommand(sequel, Conn)

        DM = CMD.ExecuteReader()
        DM.Read()
        Return DM.HasRows

    End Function

    Sub showtoBox(row As Integer, DGV As DataGridView, ParamArray var() As TextBox)
        On Error Resume Next
        For i As Integer = 0 To UBound(var, 1)


            var(i).Text = DGV.Rows(row).Cells(i).Value

        Next
    End Sub
    Function checkDuplicateInteger(tableName As String, idName As String, id As String)
        Dim sequel As String
        sequel = "select * from " + tableName + " where " + idName + " = " + id + ""
        CMD = New OleDb.OleDbCommand(sequel, Conn)

        DM = CMD.ExecuteReader()
        DM.Read()
        Return DM.HasRows

    End Function
    Sub showDataFromTable(table As String, dgv As DataGridView)
        Dim sql As String = "SELECT * FROM " + table
        Debug.WriteLine(sql)
        DA = New OleDb.OleDbDataAdapter(sql, Conn)
        DS = New DataSet
        DA.Fill(DS)

        dgv.DataSource = DS.Tables(0)
        dgv.ReadOnly = True
    End Sub
    Sub saveData(tableName As String, ParamArray var() As TextBox)
        Dim sql As String = "insert into " + tableName + " values("
        For i As Integer = 0 To UBound(var, 1)
            If i <> UBound(var, 1) Then
                sql = sql + "'" + var(i).Text + "',"
            Else
                sql = sql + "'" + var(i).Text + "')"
            End If

        Next
        CMD = New OleDb.OleDbCommand(sql, Conn)
        CMD.ExecuteNonQuery()
        clearForm(var)

    End Sub

    Sub saveData(tableName As String, ParamArray var() As String)
        Dim sql As String = "insert into " + tableName + " values("
        For i As Integer = 0 To UBound(var, 1)
            If i <> UBound(var, 1) Then
                sql = sql + "'" + var(i) + "',"
            Else
                sql = sql + "'" + var(i) + "')"
            End If

        Next
        CMD = New OleDb.OleDbCommand(sql, Conn)
        CMD.ExecuteNonQuery()

    End Sub

    Sub updateData(tableName As String, idName As String, id As String, ParamArray var() As String)
        Dim sql As String
        sql = "update " + tableName + " set "
        For i As Integer = 0 To UBound(var, 1) Step 2
            If i <> (UBound(var, 1) - 1) Then
                sql = sql + var(i) + " ='" + var(i + 1) + "', "

            Else
                sql = sql + var(i) + " ='" + var(i + 1) + "'"
            End If
        Next
        sql = sql + " where " + idName + " = " + id + ""

        CMD = New OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader


    End Sub

    Sub hapusData(namatabel As String, namaid As String, id As String)
        Dim sql As String
        sql = "DELETE FROM " + namatabel + " WHERE " + namaid + " =" + id + ""
        CMD = New OleDb.OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader
        MsgBox("Data terhapus.")
    End Sub
End Class
