Public Class TestingControls
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub DateEditTest_DateChanged(sender As Object, e As EventArgs) Handles DateEditTest.DateChanged
      
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim TextVal = DateEditTest.Text
        Dim DateVal = DateEditTest.Date
    End Sub
End Class