Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient
Public Class Lists
    Inherits System.Web.UI.Page
    Dim PageContent As String = String.Empty
    Dim _person As Person
    Dim PageId As String = String.Empty
    Protected Sub Page_Init(ByVal sender As Object, e As EventArgs) Handles Me.Init

        Try
            If (Not (String.IsNullOrEmpty(Request.QueryString("id").ToString()))) Then
                PageId = Request.QueryString("id").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ListDescr As String
        _person = New Person()
        _person = DirectCast(Session("LoggedInPerson"), Person)
        Dim SelSql = GetList("LivePortal", PageId, Session("CompanyCon"), _person.Code, ListDescr)
        KPGridPop(Session("CompanyCon"), MainGrid, SelSql, "", "")

        If PageId = "PortalOrders" Then
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                _person = DirectCast(Session("LoggedInPerson"), Person)
                Dim SelSqlOrders As String = "Select aa,DocType,DocDescr,Code,PersonCode,DocDate from Document where PersonCode = '" & _person.Code.ToString() & "'"
                KPGridPop(Session("CompanyCon"), MainGrid, SelSqlOrders, "", "")
            End Using
        End If
        Try
        Catch

        End Try
    End Sub

    Protected Sub imgExport_Click(sender As Object, e As ImageClickEventArgs) Handles imgExport.Click
        If _person IsNot Nothing Then
            DxExporter.WriteXlsToResponse(_person.Name & "_Export")
        End If
    End Sub
End Class