Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient

Public Class OrdersView
    Inherits System.Web.UI.Page
    Dim PageId As String = String.Empty
    Dim ExpectedPageId = "PortalOrders"
    Dim _person As Person
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            PageId = Request.QueryString("id")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SelSqlOrders As String = String.Empty
        If (PageId = ExpectedPageId) Then
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                _person = DirectCast(Session("LoggedInPerson"), Person)
                If Session("pType") = 1 Then
                    SelSqlOrders = "Select aa,Code Κωδικός,PersonCode Κωδικός_Προσώπου,Persname Όνομα,DocDate Ημερομηνία from Document where SalesMan = '" & _person.Code.ToString() & "' and DocType='" & Session("OrderDocType") & "'"
                Else
                    SelSqlOrders = "Select aa,Code Κωδικός,PersonCode Κωδικός_Προσώπου,Persname Όνομα,DocDate Ημερομηνία from Document where PersonCode='" & _person.Code.ToString & "'"
                End If
                KPGridPop(Session("CompanyCon"), MainGrid, SelSqlOrders, "", "")
            End Using
        End If
        'MainGrid.Columns("aa").Visible = False
    End Sub
    Protected Sub MainGrid_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles MainGrid.CustomCallback
        Dim id As Integer = Convert.ToInt32(MainGrid.GetRowValues(e.Parameters, MainGrid.KeyFieldName))
        Dim TargetUrl As String = "~/Orders?_pagePurpose=Edit&aa=" & id
        RedirectTo(TargetUrl)
    End Sub
    Public Sub RedirectTo(TargetUrl As String)
        Response.Redirect(TargetUrl)
    End Sub
End Class