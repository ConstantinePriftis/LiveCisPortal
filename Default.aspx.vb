Imports LiveCisPortal.LPVARS
Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Class _Default
    Inherits Page


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        Dim Subordinate As Person = DirectCast(Session("LoggedInPerson"), Person)
        lblNAme.Text = Subordinate.Name
        lblCmtp.Text = Subordinate.Cmpt
        lblEaddress.Text = Subordinate.Eaddress
        lblEcity.Text = Subordinate.Ecity
        lblPersonType.Text = Subordinate.PersonType
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub
End Class