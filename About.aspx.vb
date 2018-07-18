Public Class About
    Inherits Page
    Dim FirstBtnSql As String = "SELECT Code ,description Περιγραφή,Type Τυπος,Team Ομαδα  FROM DocType   where 1=1"
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        'Dim EncryptedBtnSql As String = LPVARS.AES_EncryptHex(FirstBtnSql, "FirstBtn")
        'BtnSelector1.Sql = EncryptedBtnSql.ToString()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs)
    End Sub
End Class