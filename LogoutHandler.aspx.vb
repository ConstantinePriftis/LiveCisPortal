Public Class LogoutHandler
    Inherits System.Web.UI.Page
    Dim SelectedConnection As String = String.Empty
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        SelectedConnection = Session("SelectedConnection")
        If Session("pType") = 0 Then
            Response.Redirect("ClientLogin?d=" & SelectedConnection)
        Else
            Response.Redirect("SalesManLogin?d=" & SelectedConnection)
        End If
        Session.Clear()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class