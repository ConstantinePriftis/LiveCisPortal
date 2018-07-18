Imports LiveCisPortal
Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Data

Public Class TestingOrders
    Inherits System.Web.UI.Page
    Dim anotherSql As String = "Select LineSql from DocType where Code ='" & Session("OrderDocType").ToString & "'"
    Dim DocAA As String = String.Empty
    Dim DocUid As String = String.Empty
    Dim _pagePurpose As String = String.Empty
    Dim EditAA As String = String.Empty
    Dim _selectedDate As String = String.Empty
    Dim _selectedAA As String = String.Empty

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            'Dim x = hdDocAA.Value.ToString()
            'Me.OnInit(e)
            'Dim _scriptManager = ScriptManager.
            'Perimenoume 2 stoixeia apo to QueryString
            '1)DocAA 2)Purpose
            'To 2o stoixeio kathorizei an Tha "ftiaxtei" Kainourgio parastatiko Paraggelias
            'H an tha parametropoihthei to sygkekrimeno yparxwn Parastatiko
            If Not IsPostBack Then
                Try
                    If Not String.IsNullOrEmpty(Request.QueryString("_pagePurpose").ToString()) Then
                        _pagePurpose = Request.QueryString("_pagePurpose").ToString()
                    End If
                    If (Not String.IsNullOrEmpty(Request.QueryString("aa").ToString())) Then
                        EditAA = Request.QueryString("aa").ToString()
                        hdDocAA.Value = EditAA
                    End If
                Catch ex As Exception

                End Try
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SelSql As String = String.Empty
        Try
            If (_pagePurpose = "create") Then
                If Not (IsPostBack) Then
                    InsertEmptyDocRow()
                    SelSql = "Select aa,DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa from Document where aa ='" & hdDocAA.Value & "'"
                    PopulatePanel(SelSql)
                End If
            Else
                If Not (IsPostBack) Then
                    If EditAA IsNot Nothing Or Not String.IsNullOrEmpty(EditAA) Then
                        Try
                            SelSql = "Select DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa,Comment from Document where aa = '" & EditAA & "'"
                            PopulatePanel(SelSql)
                            KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", "")
                            MainGrid.Visible = True
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If IsPostBack Then
                    If IsPostBackValid() Then
                        Dim PostBackSelect As String = "Select DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa from Document where aa='" & hdDocAA.Value.ToString() & "'"
                        KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", "")
                        MainGrid.Visible = True
                    Else
                        Dim PostBackSelect As String = "Select DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa from Document where aa='" & hdDocAA.Value.ToString() & "'"
                        KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", "")
                        MainGrid.Visible = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub InsertEmptyDocRow()
        Dim tmpId As String = newguid().ToString()
        DocUid = tmpId.ToString()
        Dim SqlDR As SqlDataReader
        Dim _client As Person = DirectCast(Session("LoggedInPerson"), Person)
        Dim ds As New DataTable
        Using con As New SqlConnection(Session("CompanyCon"))
            con.Open()
            Dim sqCm As New SqlCommand("Insert into document(UID,working) values ('" & tmpId.ToString() & "','1')", con)
            sqCm.ExecuteNonQuery()
            sqCm = New SqlCommand("select aa from document where uid='" & tmpId & "'", con)
            SqlDR = sqCm.ExecuteReader()
            SqlDR.Read()
            DocAA = SqlDR.Item("aa").ToString()
            hdDocAA.Value = DocAA
            SqlDR.Close()
            Dim sqCm2 As New SqlCommand("Update document Set DocType = '" & Session("OrderDocType").ToString & "' where aa ='" & DocAA.ToString() & "'", con)
            sqCm2.ExecuteNonQuery()
            sqCm = New SqlCommand("exec UpDoc " & DocAA.ToString(), con)
            sqCm.ExecuteNonQuery()
            Dim sqcm3 As New SqlCommand("Update document Set PersonCode='" & _client.Code.ToString() & "' where aa ='" & DocAA.ToString() & "'", con)
            sqcm3.ExecuteNonQuery()
            sqCm = New SqlCommand("exec UpDoc " & DocAA.ToString(), con)
            sqCm.ExecuteNonQuery()
        End Using
    End Sub

    Protected Sub PopulatePanel(DocSqlSelect As String)
        Try
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim sqlCM As New SqlCommand(DocSqlSelect, con)
                Dim DR As SqlDataReader = sqlCM.ExecuteReader()
                DR.Read()
                txtDocType.Text = DR.Item("DocType").ToString()
                txtPersonCode.Text = DR.Item("PersonCode").ToString()
                txtDocDescr.Text = DR.Item("DocDescr").ToString()
                txtPersname.Text = DR.Item("Persname").ToString()
                txtCode.Text = DR.Item("Code").ToString()
                If (String.IsNullOrEmpty(DR.Item("DocDate").ToString())) Then
                    DateDD.Text = Format(DateAndTime.Now.Date, "yyyy-MM-dd")
                Else
                    Dim tempDate = DirectCast(DR.Item("DocDate"), Date)
                    DateDD.Text = Format(tempDate, "dd/MM/yyyy")
                End If
                txtFpa.Text = DR.Item("fpa").ToString()
                Dim tempMemo = DR.Item("Comment").ToString()
                If Not String.IsNullOrEmpty(tempMemo.ToString()) Then
                    AspMemo.Text = tempMemo
                Else
                    AspMemo.Text = String.Empty
                End If

            End Using
        Catch ex As Exception

        End Try

    End Sub

    'Private Function PopulateDate() As String
    '    Dim x = DateDD.Text.ToString()
    '    If (DateDD.Text.ToString() <> Nothing) Then
    '        _selectedDate = Format(CDate(Date.Parse(DateDD.Text.ToString())), "yyyy-MM-dd").ToString()
    '    End If
    '    Return _selectedDate
    'End Function

    Protected Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If IsPostBack Then
            AddRowInGrid()
        End If
    End Sub

    Public Sub AddRowInGrid()

        Using con As New SqlConnection(Session("CompanyCon"))
            con.Open()
            If Not String.IsNullOrEmpty(ASPxComboBox1.Value) And Not String.IsNullOrEmpty(ASPxTextBox3.Text) Then
                Dim InDocSql As String = "exec InDocLine '" & ASPxComboBox1.Value.ToString() & "','" & ASPxTextBox3.Text & "','" & "0" & "','" & hdDocAA.Value & "','" & "0" & "','" & " " & "','" & "0" & "','" & "0" & "','" & " " & "','" & " " & "','" & "0" & "','" & "0" & "','" & " " & "','" & " " & "'"
                Dim cm As New SqlCommand(InDocSql, con)
                cm.ExecuteNonQuery()
            End If

        End Using
        KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", "")
        MainGrid.Visible = True
        ASPxComboBox1.Text = String.Empty
        ASPxComboBox1.Value = String.Empty
        ASPxTextBox3.Text = String.Empty
        ASPxTextBox3.Value = String.Empty
    End Sub

    Public Sub UpdateDoc()
        Try
            Dim client As Person = Session("LoggedInPerson")
            Dim UpdateSql As String = String.Empty
            Dim Comm = AspMemo.Text.ToString()
            Dim tempDate = Format(CDate(Date.Parse(DateDD.Text.ToString())), "yyyy-MM-dd").ToString()
            UpdateSql = "Update Document set DocDescr = '" & txtDocDescr.Text.ToString() & "' ,Comment = '" & AspMemo.Text.ToString() & "', Persname = '" & txtPersname.Text.ToString() & "', Code='" & txtCode.Text.ToString() & "',Docdate= '" & tempDate & "',fpa = '" & txtFpa.Text.ToString() & "' where aa= '" & hdDocAA.Value.ToString() & "'"
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim cm As New SqlCommand(UpdateSql, con)
                cm.ExecuteNonQuery()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Function IsPostBackValid() As Boolean
        Dim IsValid As Boolean = False
        If IsPostBack Then
            Dim test As String = Request.Form("__EVENTTARGET")
            If (Not String.IsNullOrEmpty(test)) Then
                Dim PostBackOwner As Control = Me.FindControl(test)
                Dim y = PostBackOwner.ToString()
            Else
                For Each key In Page.Request.Form.AllKeys
                    Dim c As Control = Me.FindControl(key)
                Next
            End If
            Dim ControlPostName As String = GetPostBackControlName(Me.Page)
            If ControlPostName.Contains(btnSubmit.ClientID.ToString()) Then
                IsValid = True
            End If
        End If
        Return IsValid
    End Function

    Public Sub LoadExistingOrders()
        Try
            If (Not (String.IsNullOrEmpty(_selectedAA))) Then
                Using con As New SqlConnection(Session("CompanyCon"))
                    con.Open()
                    Dim SelSql As String = "Select aa,DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa from Document where aa ='" & EditAA & "'"
                    PopulatePanel(SelSql)
                End Using
            Else
                Dim _errorMessage As String = "<script>alert('" + "Απέτυχε η φόρτωση στοιχείων λόγω προβλήματως του κωδικού Παραστατικού" + "');</script>"
                If (Not Page.IsStartupScriptRegistered("CustomErrorScript")) Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "CustomErrorScript", _errorMessage)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function GetPostBackControlName(page As Page) As String
        Dim postbackControlInstance As Control = Nothing
        Dim postbackControlName As String = page.Request.Params.Get("__EVENTTARGET")
        If postbackControlName IsNot Nothing AndAlso postbackControlName <> String.Empty Then
            postbackControlName = postbackControlName.Replace("$", "_")
            Return postbackControlName
        Else
            Return ""
        End If
        ' handle the ImageButton postbacks
    End Function

    Public Function FixSql(LineSql As String) As String
        Dim _client As Person = DirectCast(Session("LoggedInPerson"), Person)
        Dim ds As DataTable = SelQDS(LineSql, Session("CompanyCon"))
        Dim SqlReplaced = ds(0)("LineSql")
        If IsPostBack Then
            SqlReplaced = SqlReplaced.Replace("[CRETER]", "'" & hdDocAA.Value.ToString() & "'")
        Else
            SqlReplaced = SqlReplaced.Replace("[CRETER]", "'" & EditAA & "'")
        End If
        Return SqlReplaced
    End Function

    Protected Sub btnFinalSubmit_Click(sender As Object, e As EventArgs) Handles btnFinalSubmit.Click
        FinalSubmit()
    End Sub

    Public Sub FinalSubmit()
        Try
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim cm As New SqlCommand("exec UpDoc " & hdDocAA.Value.ToString(), con)
                cm.ExecuteNonQuery()
            End Using
            UpdateDoc()
        Catch ex As Exception

        End Try
        Dim NextUrl As String = "Lists?id=PortalOrders"
        Response.Redirect(NextUrl)
    End Sub

    Protected Sub MainGrid_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)

    End Sub
End Class

