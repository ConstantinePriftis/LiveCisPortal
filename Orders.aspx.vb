Imports LiveCisPortal
Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports System.Globalization
Imports System.Web.UI
Imports System.Web.DynamicData.DynamicDataExtensions


Public Class Orders
    Inherits System.Web.UI.Page

    Dim anotherSql As String ' = "Select LineSql from DocType where Code ='" & Session("OrderDocType").ToString & "'"
    Dim DocAA As String = String.Empty
    Dim DocUid As String = String.Empty
    Dim _pagePurpose As String = String.Empty
    Dim EditAA As String = String.Empty
    Dim _selectedDate As String = String.Empty
    Dim _selectedAA As String = String.Empty

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("pType") = 0 Then
            BtnSelector1.Visible = False
        End If
        'Dim x As New List(Of Control)
        'For Each c As Control In Me.Controls
        '    x.Add(c)
        '    Dim attr = c.NamingContainer
        'Next

        anotherSql = "Select LineSql from DocType where Code ='" & Session("OrderDocType").ToString & "'"
        Dim _person As Person = DirectCast(Session("LoggedInPerson"), Person)
        BtnSelector1.Sql = " SELECT Code,Name from Client where salesman='" & _person.Code & "'"
        BtnSelector1.ConnStr = Session("CompanyCon").ToString()
        Try
            SqlDataSourceline.ConnectionString = Session("CompanyCon")
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

        If (MainGrid.Visible = True) Then
            MainGrid.Columns("aa").Visible = False
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SelSql As String = String.Empty
        Try
            If (_pagePurpose = "create") Then
                If Not (IsPostBack) Then
                    InsertEmptyDocRow()
                    SelSql = "Select aa,DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa,Comment from Document where aa ='" & hdDocAA.Value & "'"
                    PopulatePanel(SelSql)
                End If
            Else
                If Not (IsPostBack) Then
                    If EditAA IsNot Nothing Or Not String.IsNullOrEmpty(EditAA) Then
                        Try
                            SelSql = "Select DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa,Comment from Document where aa = '" & EditAA & "'"
                            PopulatePanel(SelSql)
                            KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", InDocLineName())
                            MainGrid.Visible = True
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If IsPostBack Then
                    Dim PostBackSelect As String = "Select DocType,PersonCode,DocDescr,Persname,Code,DocDate,fpa,Comment from Document where aa='" & hdDocAA.Value.ToString() & "'"
                    If IsPostBackValid() Then
                        KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", InDocLineName())
                        MainGrid.Visible = True
                    Else
                        KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", InDocLineName())
                        MainGrid.Visible = True
                    End If
                    PopulatePanel(PostBackSelect)
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
            Dim sqCm2 As New SqlCommand("Update document Set DocType = '" & Session("OrderDocType") & "' where aa ='" & DocAA.ToString() & "'", con)
            sqCm2.ExecuteNonQuery()
            sqCm = New SqlCommand("exec UpDoc " & DocAA.ToString(), con)
            sqCm.ExecuteNonQuery()
            If (Session("pType") = 0) Then
                Dim sqcm3 As New SqlCommand("Update document Set PersonCode='" & _client.Code.ToString() & "' where aa ='" & DocAA.ToString() & "'", con)
                sqcm3.ExecuteNonQuery()
                sqCm = New SqlCommand("exec UpDoc " & DocAA.ToString(), con)
                sqCm.ExecuteNonQuery()
                'Else
                '    Dim sqcm3 As New SqlCommand("Update document Set PersonCode='" & _client.Code.ToString() & "' where aa ='" & DocAA.ToString() & "'", con)
                '    sqcm3.ExecuteNonQuery()
                '    sqCm = New SqlCommand("exec UpDoc " & DocAA.ToString(), con)
                '    sqCm.ExecuteNonQuery()
            End If
        End Using
    End Sub

    Protected Sub PopulatePanel(DocSqlSelect As String)

        Try
            If (Session("pType") = 0) Then
                ClientPopulateLayout(DocSqlSelect)
            Else
                SalesManPopulateLayout(DocSqlSelect)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SalesManPopulateLayout(SqlSelect As String)
        Try
            Dim _client As Person = DirectCast(Session("LoggedInPerson"), Person)
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim sqlCM As New SqlCommand(SqlSelect, con)
                Dim DR As SqlDataReader = sqlCM.ExecuteReader()
                DR.Read()
                'Type
                txtDocType.Text = DR.Item("DocType").ToString()
                'Description
                txtDocDescr.Text = DR.Item("DocDescr").ToString()
                'Person Code
                If (txtPersonCode.Text = _client.Code.ToString()) Then
                    txtPersonCode.Text = String.Empty
                Else
                    txtPersonCode.Text = DR.Item("PersonCode").ToString()
                End If
                'Date
                PopulateDate(DR)
                'Fpa and Person Name
                If Not (String.IsNullOrEmpty(txtPersonCode.Text)) Then
                    txtFpa.Text = DR.Item("fpa").ToString()
                    txtPersname.Text = DR.Item("Persname").ToString()
                Else
                    txtFpa.Text = String.Empty
                    txtPersname.Text = String.Empty
                End If
                'Code
                txtCode.Text = DR.Item("Code").ToString()
                'Comments
                If Not String.IsNullOrEmpty(DR.Item("Comment").ToString()) Then
                    If Not IsPostBack Then
                        If Not IsPostBackValid() Then
                            AspMemo.Text = DR.Item("Comment").ToString()
                        End If
                    End If
                Else
                    If IsPostBack Then
                        If Not (IsPostBackValid()) Then
                            If (String.IsNullOrEmpty(AspMemo.Text.ToString())) Then
                                AspMemo.Text = String.Empty
                            End If
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PopulateDate(DR As SqlDataReader)
        Dim tempDate
        If (String.IsNullOrEmpty(DateDD.Text)) Then
            If (String.IsNullOrEmpty(DR.Item("DocDate").ToString())) Then
                tempDate = Format(CDate(DateTime.Now.ToString()), "dd/MM/yyyy")
                DateDD.Text = tempDate.ToString()
            Else
                If DR.Item("DocDate").ToString() = DateDD.Text.ToString() Then
                    Dim Something = DR.Item("DocDate").ToString()
                    tempDate = DirectCast(DR.Item("DocDate"), Date)
                    DateDD.Text = Format(tempDate.ToString(), "dd/MM/yyyy")
                Else
                    DateDD.Text = Format(CDate(DR.Item("DocDate").ToString()), "dd/MM/yyyy")
                End If
            End If
        End If
    End Sub

    Private Sub ClientPopulateLayout(SqlSelect As String)
        Try
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim sqlCM As New SqlCommand(SqlSelect, con)
                Dim DR As SqlDataReader = sqlCM.ExecuteReader()
                DR.Read()
                txtDocType.Text = DR.Item("DocType").ToString()
                txtDocDescr.Text = DR.Item("DocDescr").ToString()
                txtPersonCode.Text = DR.Item("PersonCode").ToString()
                txtPersname.Text = DR.Item("Persname").ToString()
                txtCode.Text = DR.Item("Code")
                PopulateDate(DR)
                txtFpa.Text = DR.Item("fpa").ToString()
                If Not String.IsNullOrEmpty(DR.Item("Comment").ToString()) Then
                    If Not IsPostBack Then
                        If Not IsPostBackValid() Then
                            AspMemo.Text = DR.Item("Comment").ToString()
                        End If
                    End If
                Else
                    If IsPostBack Then
                        If Not (IsPostBackValid()) Then
                            If (String.IsNullOrEmpty(AspMemo.Text.ToString())) Then
                                AspMemo.Text = String.Empty
                            End If
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

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
        KPGridPop(Session("CompanyCon"), MainGrid, FixSql(anotherSql), "", InDocLineName())
        MainGrid.Visible = True
        ASPxComboBox1.Text = String.Empty
        ASPxComboBox1.Value = String.Empty
        ASPxTextBox3.Text = String.Empty
        ASPxTextBox3.Value = String.Empty
    End Sub

    Public Sub UpdateDoc()
        Dim client As Person = Session("LoggedInPerson")
        Dim UpdateSql As String = String.Empty
        Dim Comm = AspMemo.Text.ToString()
        Dim formatDate As String = "yyyy-MM-dd"
        'Dim SecondDate As Date = Date.ParseExact(DateDD.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture)

        Dim tempDate = CDate(DateDD.Value).ToString(formatDate)
        If Session("pType") = 0 Then
            Try

                UpdateSql = "Update Document set DocDescr = '" & txtDocDescr.Text.ToString() & "' ,Comment = '" & AspMemo.Text.ToString() & "', Persname = '" & txtPersname.Text.ToString() & "', Code='" & txtCode.Text.ToString() & "',Docdate= '" & tempDate & "',fpa = '" & txtFpa.Text.ToString() & "' where aa= '" & hdDocAA.Value.ToString() & "' "
                Using con As New SqlConnection(Session("CompanyCon"))
                    con.Open()
                    Dim cm As New SqlCommand(UpdateSql, con)
                    cm.ExecuteNonQuery()
                    cm = New SqlCommand("exec upDoc " & hdDocAA.Value.ToString(), con)
                    cm.ExecuteNonQuery()
                    cm = New SqlCommand("Update Document set Working = 0 where aa='" & hdDocAA.Value.ToString() & "'", con)
                    cm.ExecuteNonQuery()
                End Using
            Catch ex As Exception
            End Try
        Else
            Try
                If (Not String.IsNullOrEmpty(txtPersonCode.Text)) Then
                    UpdateSql = "Update Document set DocDescr = '" & txtDocDescr.Text.ToString() & "' ,Comment = '" & AspMemo.Text.ToString() & "', Persname = '" & txtPersname.Text.ToString() & "', Code='" & txtCode.Text.ToString() & "',Docdate= '" & tempDate & "',fpa = '" & txtFpa.Text.ToString() & "' where aa= '" & hdDocAA.Value.ToString() & "'"
                End If
                Using con As New SqlConnection(Session("CompanyCon"))
                    con.Open()
                    Dim cm As New SqlCommand(UpdateSql, con)
                    cm.ExecuteNonQuery()
                    cm = New SqlCommand("exec UpDoc " & hdDocAA.Value.ToString(), con)
                    cm.ExecuteNonQuery()
                    cm = New SqlCommand("Update Document set Working = 0 where aa='" & hdDocAA.Value.ToString() & "'", con)
                    cm.ExecuteNonQuery()
                End Using
            Catch ex As Exception
            End Try
        End If

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
            If ControlPostName.Contains(btnFinalSubmit.ClientID.ToString()) Then
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
    End Function

    Protected Sub txtPersonCode_TextChanged(sender As Object, e As EventArgs) Handles txtPersonCode.TextChanged
        Dim SelSql As String = "Select Name,fpa from Person where Code = '" & txtPersonCode.Text.ToString() & "'"
        '"Select DocType,DocDescr,Persname,Code,DocDate,fpa,Comment from Person where PersonCode='" & txtPersonCode.Text.ToString() & "'"
        Try
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim sqlCM As New SqlCommand(SelSql, con)
                Dim DR As SqlDataReader = sqlCM.ExecuteReader()
                'txtDocType.Text = DR.Item("DocType").ToString()
                Dim _client As Person = DirectCast(Session("LoggedInPerson"), Person)
                If (Session("pType") = 0) Then
                    txtPersonCode.Text = DR.Item("PersonCode").ToString()
                Else
                    If (txtPersonCode.Text = _client.Code.ToString()) Then
                        txtPersonCode.Text = String.Empty
                    End If
                End If
                DR.Close()
                Dim sqCm2 As New SqlCommand("Update document Set PersonCode = '" & txtPersonCode.Text.ToString() & "' where aa ='" & hdDocAA.Value.ToString() & "'", con)
                sqCm2.ExecuteNonQuery()
                sqCm2 = New SqlCommand("exec UpDoc " & hdDocAA.Value.ToString(), con)
                sqCm2.ExecuteNonQuery()
                sqCm2 = New SqlCommand("Select Persname,fpa from Document where aa= '" & hdDocAA.Value.ToString() & "'", con)

                DR = sqCm2.ExecuteReader()
                DR.Read()


                txtPersname.Text = DR.Item("Persname").ToString()
                txtFpa.Text = DR.Item("fpa").ToString()


            End Using
        Catch ex As Exception

        End Try
    End Sub

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
    Public Function InDocLineName()
        Dim SqlSelect As String = String.Empty
        Dim SqlNames As String = String.Empty
        Try
            SqlSelect = "Select LineNames from DocType where Code = '" & Session("OrderDocType").ToString() & "'"
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim cm As New SqlCommand(SqlSelect, con)
                Dim Dr As SqlDataReader = cm.ExecuteReader()
                Dr.Read()
                SqlNames = Dr.Item("LineNames").ToString()
                Return SqlNames
            End Using
        Catch ex As Exception
        End Try
        Return SqlNames
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
        Dim NextUrl As String = "OrdersView?id=PortalOrders"
        Response.Redirect(NextUrl)
    End Sub

    Protected Sub MainGrid_RowCommand(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs)

    End Sub


End Class