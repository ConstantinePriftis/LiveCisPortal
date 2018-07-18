Imports System.Web.Optimization
Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls


Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AuthConfig.RegisterOpenAuth()
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        RouteTable.Routes.EnableFriendlyUrls()

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        'Dim FullOriginalPath As String = Server.UrlDecode(Request.Url.ToString())
        'Dim AbsoluteOriginalPath As String = Server.UrlDecode(Request.Url.AbsolutePath)

        'Dim application As HttpApplication = sender
        'FriendlyUrl.Resolve(HttpContext.Current.Request.Url.AbsolutePath)

        'Dim RewritePath As String = ""

        'If RewritePath IsNot Nothing Then
        '    For i = 0 To Request.QueryString.Count - 1
        '        RewritePath = RewritePath & "?" & Request.QueryString.Keys(i) & "=" & Request.QueryString.Item(Request.QueryString.Keys(i))
        '    Next
        '    Context.RewritePath(RewritePath)
        'End If

        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub
End Class