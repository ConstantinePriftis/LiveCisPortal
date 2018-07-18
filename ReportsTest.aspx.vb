Imports System.Data
Imports System.Data.SqlClient
Imports LiveCisPortal.LPVARS

Public Class ReportsTest
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim ExpectedString As String = String.Empty
        Dim SelectStatement As String = "Select top 1 Params from Reports where aa = 9"
        Using con As New SqlConnection(Session("CompanyCon").ToString())
            dt = SelQDS(SelectStatement, Session("CompanyCon").ToString())
            Dim dr As DataRow = dt.NewRow()
            ExpectedString = dt.Rows(0)(0).ToString()
        End Using



        Gv2.DataSource = dt
        Gv2.DataBind()
    End Sub

End Class