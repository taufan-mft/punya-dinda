Public Module RoleChecker
    Sub canWeAccessThis(role As List(Of String), form As Form)
        Dim repository As Repository = Repository.getInstance()
        If Not role.Contains(repository.role) Then
            Dim response = MsgBox("You don't have access to this page")
            form.Close()
        End If
    End Sub
End Module
