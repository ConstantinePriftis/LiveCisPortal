Imports Microsoft.VisualBasic
Imports System
Imports System.Web.Security
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Data
Imports System.Data.SqlClient
Imports AjaxControlToolkit
Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Imports System.Security.Cryptography
Imports System.Web.UI.Page



Public Class LPVARS
    Public Shared cnxstring As String ' = "server=GORMIR-PC\SQR2;uid=sa;pwd=clroot;database=ComVoiceMaster"
    Public Shared dbcnxstring As String
    Public Shared SCn As New SqlConnection
    Public Structure lpComboxEdiform
        Public Sql As String
        Public Mode As Int32
    End Structure

    Public Shared Function newguid() As String
        Dim RandomClass As New Random()
        newguid = Format(Now, "yyyyddMMhhmmss") & RandomClass.Next()
    End Function

    Public Shared Function fixsDAte(ByVal periex As String) As String
        If IsDate(periex) Then

            If Trim(periex) = "" Then
                fixsDAte = Format(Now, "yyyy-MM-dd")
            Else

                fixsDAte = Format(CDate(periex), "yyyy-MM-dd")
            End If
        Else
            fixsDAte = Format(Now, "yyyy-MM-dd")
        End If
    End Function
    Public Shared Function fixsnDAte(ByVal periex As String) As String
        If IsDate(periex) Then

            If periex = "" Then
                fixsnDAte = "Null"
            Else

                fixsnDAte = "'" & Format(CDate(periex), "yyyy-MM-dd") & "'"
            End If
        Else
            fixsnDAte = Format(Now, "yyyy-MM-dd")
        End If
    End Function


    'Public Shared Sub FixMaster(mst As MasterPage, perigrafi As String, idxac As Integer, conString As String)

    '    Dim ac1 As Accordion = mst.FindControl("Accordion1")
    '    ac1.SelectedIndex = idxac

    '    Dim cn As New SqlConnection()
    '    Dim cs As String = "Select top 1 isnull(Companyname,'') from company"
    '    Dim cm As New SqlCommand(cs, cn)
    '    Dim CompanyName As Object
    '    If conString = "" Then
    '        CompanyName = ""
    '    Else
    '        cn.ConnectionString = conString
    '        cn.Open()
    '        CompanyName = cm.ExecuteScalar()
    '        cn.Close()
    '    End If

    '    Dim lang As String = String.Empty
    '    Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("CaltureName")
    '    If cookie IsNot Nothing Then
    '        If cookie.Value IsNot DBNull.Value Then
    '            lang = cookie.Value
    '        End If
    '    End If
    '    If lang = "EN-US" Then
    '        If perigrafi = "Αρχική Σελίδα" Then
    '            perigrafi = "Home"
    '        ElseIf perigrafi = "Σχετικα" Then
    '            perigrafi = "About"
    '        ElseIf perigrafi = "Επικοινωνία" Then
    '            perigrafi = "Communication"
    '        ElseIf perigrafi = "Πελάτης" Then
    '            perigrafi = "Customers"
    '        ElseIf perigrafi = "Προμηθευτής" Then
    '            perigrafi = "Suppliers"
    '        ElseIf perigrafi = "Είδος" Then
    '            perigrafi = "Items"
    '        ElseIf perigrafi = "Υπηρεσία" Then
    '            perigrafi = "Services"
    '        ElseIf perigrafi = "Χρηματικό" Then
    '            perigrafi = "Cash"
    '        ElseIf perigrafi = "Αξιογραφα" Then
    '            perigrafi = "Securities"
    '        ElseIf perigrafi = "Τιμοκατάλογος" Then
    '            perigrafi = "Price Lists"
    '        ElseIf perigrafi = "ΠΩΛΗΣΕΙΣ" Then
    '            perigrafi = "Sales"
    '        ElseIf perigrafi = "ΑΓΟΡΕΣ" Then
    '            perigrafi = "Purchases"
    '        ElseIf perigrafi = "ΕΙΣΠΡΑΞΕΙΣ" Then
    '            perigrafi = "Proceeds"
    '        ElseIf perigrafi = "ΠΛΗΡΩΜΕΣ" Then
    '            perigrafi = "Payments"
    '        ElseIf perigrafi = "ΧΡΕΟΠΙΣΤΩΣΗ" Then
    '            perigrafi = "Debit Credit"
    '        ElseIf perigrafi = "Εκτυπώσεις" Then
    '            perigrafi = "Reports"
    '        ElseIf perigrafi = "Γραφήματα" Then
    '            perigrafi = "Graphs"
    '        ElseIf perigrafi = "Λογαριασμοί Γέφυρας" Then
    '            perigrafi = "Bridges accounts"
    '        ElseIf perigrafi = "Συντήρηση" Then
    '            perigrafi = "Maintenance"
    '        ElseIf perigrafi = "Αλλαγή Password" Then
    '            perigrafi = "Password change"
    '        ElseIf perigrafi = "Γέφυρες Λογιστικής" Then
    '            perigrafi = "Accounting bridges"
    '        ElseIf perigrafi = "Αποσύνδεση" Then
    '            perigrafi = "Logout"
    '        End If
    '        If perigrafi.Contains("Παραμετροποίηση") Then
    '            perigrafi = perigrafi.Replace("Παραμετροποίηση", "Customization")
    '        End If
    '    End If
    '    Dim lb1 As HtmlGenericControl = mst.FindControl("Label1")
    '    lb1.InnerHtml = IIf(CompanyName = "", "", CompanyName + "-") + "<span style='color:#FFFFCC;'>" + perigrafi + "</span>"
    '    'lb1.InnerHtml = "<img src='Images/LiveCIS.png' style='margin-top:15px' onclick=""window.location.href = 'http://www.livecis.gr';""/> " + IIf(CompanyName = "", "", CompanyName) + " " + "<span style='color:#FFFFCC;'>" + perigrafi + "</span>"
    '    'lb1.InnerHtml = "<img src='Images/LiveCIS.jpg' style='margin-top:15px'/>  Live C.i.S. - " + IIf(CompanyName = "", "", CompanyName + " - ") + "<span style='color:#FFFFCC;'>" + perigrafi + "</span>"
    'End Sub



    Public Shared Function fixDateToString(ByVal periex As Date) As String

        Try
            Return Format(periex, "yyyy-MM-dd").ToString
        Catch
            Return Format(Now, "yyyy-MM-dd")
        End Try
    End Function
    Public Shared Function fixsnum(ByVal periex As String) As String
        fixsnum = "0"
        If IsNumeric(periex) Then


            If periex = "" Then
                fixsnum = "0"
            Else
                fixsnum = Replace(periex, ",", ".")
            End If
        Else
            fixsnum = "0"
        End If
    End Function

    Public Shared Function ExeQuer(querys As String, constring As String) As Integer
        On Error GoTo erh
        Dim cn As New SqlConnection

        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand(querys, cn)
        ExeQuer = sqcm.ExecuteNonQuery()
        'sqcm.e()
        cn.Close()
        Exit Function
erh:
        ExeQuer = -1
    End Function
    Public Shared Function ExeQuerR(querys As String, constring As String, Optional ByRef Retmsg As String = "") As Integer
        On Error GoTo erh
        Dim cn As New SqlConnection

        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand(querys, cn)
        ExeQuerR = sqcm.ExecuteNonQuery()
        cn.Close()
        Retmsg = "OK"
        Exit Function
erh:
        Retmsg = Err.Description
        ExeQuerR = -1
    End Function
    Public Shared Function SelQuerS(querys As String, constring As String) As String
        On Error GoTo erh
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand(querys, cn)
        sqcm.CommandText = querys
        dtr = sqcm.ExecuteReader()
        dtr.Read()

        SelQuerS = dtr.Item(0).ToString
        'SelQuerS = Format(dtr.Item(0), "0.00")
        cn.Close()
        Exit Function
erh:
        SelQuerS = ""
    End Function

    Public Shared Function SelQuerFS(querys As String, constring As String) As String
        On Error GoTo erh
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand(querys, cn)
        sqcm.CommandText = querys
        dtr = sqcm.ExecuteReader()
        'dtr.Read()
        Dim RetS As String = ""

        If dtr.HasRows Then
            Do While dtr.Read()
                RetS += dtr.Item(0).ToString
            Loop
        Else
            Console.WriteLine("No rows found.")
        End If

        dtr.Close()

        Return RetS
        'SelQuerS = Format(dtr.Item(0), "0.00")
        cn.Close()
        Exit Function
erh:
        Return ""
    End Function
    Public Shared Function Getfpa(itemcode As String, PersonFpa As String, constring As String, Optional WorkDate As String = "1999-01-01") As Double
        On Error GoTo erh
        Dim itemfpa As String
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        Dim dtr1 As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        If WorkDate = "1999-01-01" Then WorkDate = Format(Now, "yyyy-MM-dd")
        sqcm = New SqlCommand(" select fpa from material where code = '" & itemcode & "'", cn)
        dtr = sqcm.ExecuteReader()
        dtr.Read()
        itemfpa = dtr.Item(0).ToString
        dtr.Close()

        Dim sqcmc As SqlCommand
        sqcmc = New SqlCommand("Select (case when '" & WorkDate & "' < wdate then OVat else vat end) vat from VatCategory where vatperson = '" & PersonFpa & "' and vatitem ='" & itemfpa & "'", cn)
        dtr1 = sqcmc.ExecuteReader()
        dtr1.Read()
        Getfpa = Val(Replace(dtr1.Item(0).ToString, ",", ".")) / 100.0
        'SelQuerS = Format(dtr.Item(0), "0.00")
        cn.Close()
        Exit Function
erh:
        Getfpa = 0.0
    End Function



    Public Shared Sub FComboFill(Constr As String, dplist As DropDownList, selsql As String, bindfield As String)
        Dim dsl As New SqlDataSource
        dsl.ConnectionString = Constr
        dsl.SelectCommand = selsql
        dsl.DataSourceMode = SqlDataSourceMode.DataSet
        dsl.DataBind()
        dplist.Items.Clear()
        dplist.Items.Add("")
        dplist.DataSource = dsl
        dplist.DataValueField = bindfield
        dplist.DataTextField = bindfield
        dplist.DataBind()
    End Sub

    Public Shared Sub Ngridpop(Constr As String, LP_grid As DevExpress.Web.ASPxGridView.ASPxGridView, Selsql As String, Optional Delsql As String = "", Optional namestring As String = "")
        Dim dsl As New SqlDataSource

        Dim crb As Boolean = True
        If LP_grid.Columns.Count = 0 Then
            crb = True
        Else
            crb = False
        End If
        dsl.ConnectionString = Constr
        dsl.SelectCommand = Selsql
        dsl.DataSourceMode = SqlDataSourceMode.DataSet
        dsl.DataBind()
        LP_grid.AutoGenerateColumns = True
        LP_grid.DataSource = dsl
        LP_grid.DataBind()
        If crb Then
            Dim i As Integer
            Dim nmt() As String = Split(namestring, ",")
            For i = 1 To LP_grid.Columns.Count - 1
                LP_grid.Columns(i).VisibleIndex = i + 1
                LP_grid.Columns(i).Name = LP_grid.Columns(i).Caption
                If i <= UBound(nmt) Then
                    LP_grid.Columns(i).Caption = nmt(i - 1).ToString
                End If
            Next i
            LP_grid.Columns(1).Visible = False
            LP_grid.Columns(1).Width = 0
            LP_grid.Columns(0).Width = 70
            LP_grid.KeyFieldName = "aa"
            Dim nc As New DevExpress.Web.ASPxGridView.GridViewCommandColumn
            nc.EditButton.Visible = True
            nc.ButtonType = ButtonType.Image
            nc.EditButton.Image.Url = "~/images/searchMed.png"
            nc.EditButton.Text = "Επιλογή"
            nc.Caption = "Επιλογές"
            nc.FixedStyle = DevExpress.Web.ASPxGridView.GridViewColumnFixedStyle.Left
            LP_grid.ClientSideEvents.CustomButtonClick = "function(s, e) {s.PerformCallback(e.visibleIndex);}"
            LP_grid.Columns.Add(nc)
            nc.VisibleIndex = 1
        End If
    End Sub
    Public Shared Sub Mgridpop(Constr As String, LP_grid As DevExpress.Web.ASPxGridView.ASPxGridView, Selsql As String, Optional Delsql As String = "", Optional namestring As String = "")
        Dim dsl As New SqlDataSource

        Dim crb As Boolean = True
        If LP_grid.Columns.Count = 0 Then
            crb = True
        Else
            crb = False
        End If
        dsl.ConnectionString = Constr
        dsl.SelectCommand = Selsql
        dsl.DataSourceMode = SqlDataSourceMode.DataSet
        dsl.DataBind()
        LP_grid.AutoGenerateColumns = True
        LP_grid.DataSource = dsl
        LP_grid.DataBind()
        If crb Then
            Dim i As Integer
            Dim nmt() As String = Split(namestring, ",")
            For i = 1 To LP_grid.Columns.Count - 1
                LP_grid.Columns(i).VisibleIndex = i + 1
                LP_grid.Columns(i).Name = LP_grid.Columns(i).Caption
                If i <= UBound(nmt) Then
                    LP_grid.Columns(i).Caption = nmt(i - 1).ToString
                End If
            Next i
            LP_grid.Columns(1).Visible = False
            LP_grid.Columns(1).Width = 0
            LP_grid.Columns(0).Width = 70
            LP_grid.KeyFieldName = "aa"
            Dim nc As New DevExpress.Web.ASPxGridView.GridViewCommandColumn
            nc.EditButton.Visible = True
            nc.ButtonType = ButtonType.Image
            nc.EditButton.Image.Url = "~/images/searchMed.png"
            nc.EditButton.Text = "Επιλογή"
            nc.ShowSelectCheckbox = True
            nc.Caption = "Επιλογές"
            nc.FixedStyle = DevExpress.Web.ASPxGridView.GridViewColumnFixedStyle.Left
            LP_grid.ClientSideEvents.CustomButtonClick = "function(s, e) {s.PerformCallback(e.visibleIndex);}"
            LP_grid.Columns.Add(nc)
            nc.VisibleIndex = 1
        End If
    End Sub
    Public Shared Sub hideCells(page As Page, controlsByComma As String)
        Dim hideArray() As String = controlsByComma.Split(",")
        For i As Integer = 0 To hideArray.Length - 1
            If page.Form.FindControl("MainContent").FindControl(hideArray(i)) IsNot Nothing Then
                page.Form.FindControl("MainContent").FindControl(hideArray(i)).Visible = False
                If page.Form.FindControl("MainContent").FindControl("lbl" & hideArray(i)) IsNot Nothing Then
                    page.Form.FindControl("MainContent").FindControl("lbl" & hideArray(i)).Visible = False
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Constr"></param>
    ''' <param name="LP_grid"></param>
    ''' <param name="Selsql"></param>
    ''' <param name="Delsql"></param>
    ''' <param name="namestring"></param>
    ''' <remarks></remarks>
    Public Shared Sub Fgridpop(Constr As String, LP_grid As DevExpress.Web.ASPxGridView.ASPxGridView, Selsql As String, Optional Delsql As String = "", Optional namestring As String = "")
        Dim dsl As New SqlDataSource

        Dim crb As Boolean = True
        If LP_grid.Columns.Count = 0 Then
            crb = True
        Else
            crb = False
        End If
        dsl.ConnectionString = Constr
        dsl.SelectCommand = Selsql
        LP_grid.EnableCallBacks = True
        dsl.DataSourceMode = SqlDataSourceMode.DataSet
        If Delsql <> "" Then
            dsl.DeleteCommand = Delsql
            dsl.DeleteParameters.Add("@aa", "")
        End If
        'dsl.DeleteCommandType = SqlDataSourceCommandType.Text
        dsl.DataBind()
        'LP_grid.Columns.Clear()
        LP_grid.AutoGenerateColumns = True
        LP_grid.DataSource = dsl
        LP_grid.DataBind()
        If crb Then
            Dim commandCol As New DevExpress.Web.ASPxGridView.GridViewCommandColumn()
            commandCol.ButtonType = ButtonType.Link
            'commandCol.UpdateButton.Visible = True
            ' commandCol.ShowSelectCheckbox = True
            commandCol.SelectButton.Text = "Ε"
            commandCol.SelectButton.Image.Url = "~/images/GLOBES_BLUEs.png"
            commandCol.SelectButton.Visible = True
            If Delsql <> "" Then
                commandCol.DeleteButton.Text = "Δ"
                commandCol.DeleteButton.Visible = True

            End If
            commandCol.Caption = "Επιλογή"
            commandCol.VisibleIndex = 0
            LP_grid.Columns.Insert(0, commandCol)
        End If
        Dim i As Integer
        Dim nmt() As String = Split(namestring, ",")
        For i = 1 To LP_grid.Columns.Count - 1
            LP_grid.Columns(i).VisibleIndex = i + 1
            LP_grid.Columns(i).Name = LP_grid.Columns(i).Caption
            If i <= UBound(nmt) Then
                LP_grid.Columns(i).Caption = nmt(i - 1).ToString
            End If
        Next i
        LP_grid.Columns(1).Visible = False
        LP_grid.Columns(1).Width = 0
        LP_grid.Columns(0).Width = 70
        LP_grid.KeyFieldName = "aa"
    End Sub

    Public Shared Sub KPGridPop(Constr As String, LP_grid As DevExpress.Web.ASPxGridView.ASPxGridView, Selsql As String, Optional Delsql As String = "", Optional namestring As String = "")
        'Dim SortJs = "<script type='text/javascript'>" & vbCrLf
        'SortJs = SortJs & "                 var order;" & vbCrLf
        'SortJs = SortJs & "                 var SetOrder = {" & vbCrLf
        'SortJs = SortJs & "                     onSorting: function (s, e) {" & vbCrLf
        'SortJs = SortJs & "                         order = order == 'ASC' ? 'DESC' : 'ASC';" & vbCrLf
        'SortJs = SortJs & "                         e.cancel = true;" & vbCrLf
        'SortJs = SortJs & "                         s.PerformCallback(order + ',' + e.column.fieldName);" & vbCrLf
        'SortJs = SortJs & "                     }" & vbCrLf
        'SortJs = SortJs & "                 };" & vbCrLf
        'SortJs = SortJs & "         </script> "





        '_ClientScript.RegisterStartupScript("KPGridSort", SortJs)
        ' LP_grid.ClientSideEvents.ColumnSorting = "SetOrder.onSorting"
        '<ClientSideEvents ColumnSorting="SetOrder.onSorting" />
        Dim dsl As New SqlDataSource
        Dim crb As Boolean = True
        If LP_grid.Columns.Count = 0 Then
            crb = True
        Else
            crb = False
        End If
        dsl.ConnectionString = Constr
        dsl.SelectCommand = Selsql
        LP_grid.EnableCallBacks = True

        dsl.DataSourceMode = SqlDataSourceMode.DataSet
        If Delsql <> "" Then
            dsl.DeleteCommand = Delsql
            dsl.DeleteParameters.Add("@aa", "")
        End If
        'dsl.DeleteCommandType = SqlDataSourceCommandType.Text
        dsl.DataBind()
        'LP_grid.Columns.Clear()
        LP_grid.AutoGenerateColumns = True
        LP_grid.EnableCallBacks = False
        LP_grid.DataSource = dsl
        LP_grid.DataBind()
        If crb Then
            Dim commandCol As New DevExpress.Web.ASPxGridView.GridViewCommandColumn()
            commandCol.ButtonType = ButtonType.Image
            commandCol.SelectButton.Text = "Ε"
            'EXPERIMENTAL Part
            'CALLBACK
            AddHandler LP_grid.CustomCallback, Sub(O As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs)
                                                   If e.Parameters.ToUpper() = "TRUE" Or e.Parameters.ToUpper() = "FALSE" Then
                                                       Dim isSelected As Boolean = Convert.ToBoolean(e.Parameters)
                                                       If isSelected Then
                                                           CType(O, DevExpress.Web.ASPxGridView.ASPxGridView).Selection.SelectAll()
                                                       Else
                                                           CType(O, DevExpress.Web.ASPxGridView.ASPxGridView).Selection.UnselectAll()
                                                       End If
                                                   ElseIf e.Parameters.ToUpper().Substring(0, 3) = "ASC" Or e.Parameters.ToUpper().Substring(0, 3) = "DES" Then
                                                       Dim nn = HttpContext.Current.Session("uname") + "_" + HttpContext.Current.Request.QueryString("tp") ' + opsi
                                                       Dim ar = e.Parameters.Split(",")
                                                       Dim order As DevExpress.Data.ColumnSortOrder = If(ar(0) = "ASC", DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Data.ColumnSortOrder.Descending)
                                                       LP_grid.SortBy(LP_grid.Columns(ar(1)), order)
                                                   Else
                                                       Dim GridPageSize = Integer.Parse(e.Parameters)
                                                       LP_grid.SettingsPager.PageSize = GridPageSize
                                                       LP_grid.DataBind()
                                                   End If
                                               End Sub
            'EXPERIMENTAL PART

            commandCol.SelectButton.Image.Url = "~/images/searchMed.png"
            commandCol.SelectButton.Visible = True
            'commandCol.Width = 50
            If Delsql <> "" Then
                commandCol.DeleteButton.Text = "Επιλογή"
                commandCol.DeleteButton.Visible = True
            End If

            commandCol.Caption = "Επιλογή"
            commandCol.VisibleIndex = 0
            LP_grid.Columns.Insert(0, commandCol)
        End If

        Try
            Dim i As Integer
            Dim nmt() As String = Split(namestring, ",")
            For i = 1 To LP_grid.Columns.Count - 1
                LP_grid.Columns(i).VisibleIndex = i + 1
                LP_grid.Columns(i).Name = LP_grid.Columns(i).Caption
                If i <= UBound(nmt) Then
                    LP_grid.Columns(i).Caption = nmt(i - 1).ToString
                Else
                    LP_grid.Columns(LP_grid.Columns.Count - 2).Caption = nmt(UBound(nmt)).ToString()
                End If
            Next i
        Catch ex As Exception

        End Try

        'LP_grid.Columns(0).Visible = False
        'LP_grid.Columns(0).Width = 0
        LP_grid.Columns(0).Width = 70
        'LP_grid.Columns(1).Visible = False
        LP_grid.KeyFieldName = "aa"
        Try
            If LP_grid.Visible = True Then
                LP_grid.Columns("aa").Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function CtoOlecon(ss As String) As String
        'Dim ss As String = "server=GORMIR-PC\SQR2;uid=sa;pwd=clroot;database=ComVoiceMaster"
        'Provider=SQLOLEDB.1;Password=clroot;Persist Security Info=True;User ID=sa;Initial Catalog=ComVoiceDemo;Data Source=gormir-pc\sqr2
        Dim oleco As String
        Dim i As Integer
        Dim sqlitems() As String
        Dim temteb() As String
        Dim Sqlprops(4, 2) As String
        sqlitems = Split(ss, ";")
        For i = 0 To 3
            temteb = Split(sqlitems(i).ToString, "=")
            Sqlprops(i, 0) = temteb(0)
            Sqlprops(i, 1) = temteb(1)
        Next i
        oleco = "Provider=SQLOLEDB.1;Password=" & Sqlprops(2, 1).ToString & ";Persist Security Info=True;User ID=" & Sqlprops(1, 1).ToString & ";Initial Catalog=" & Sqlprops(3, 1).ToString & ";Data Source=" & Sqlprops(0, 1).ToString & ""
        CtoOlecon = oleco
    End Function

    ''' <summary>
    ''' Παραγωγή Άρθρου για Παραστατικό. Τα αποτελέσματα προστίθενται στον Πίνακα 'BBridgeArticles'
    ''' </summary>
    ''' <param name="DocAA">Δώσε το πεδίο AA του Παραστατικού</param>
    ''' <param name="Constr">Δώσε το Connection String για σύνδεση στην Βάση</param>
    ''' <remarks></remarks>
    Public Shared Function DocToArticle(DocAA As Integer, Constr As String) As String
        On Error GoTo errc
        Dim PRK As String
        Dim cs As String = ""
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet
        Dim _CodeModel As String = ""
        Dim EntityParatirisi As String
        cn.ConnectionString = Constr
        cm.Connection = cn
        '-------Load Document Header
        cs = String.Format("select * from Document where aa = {0}", DocAA.ToString())
        cm.CommandText = cs
        If ds.Tables.Contains("DocHeader") Then
            ds.Tables.Remove("DocHeader")
        End If
        cn.Open()
        da.Fill(ds, "DocHeader")
        cn.Close()
        '-------Load Document Date
        cs = String.Format("select DocDate from Document where aa = {0}", DocAA.ToString())
        cm.CommandText = cs
        cn.Open()
        Dim _DocDate As DateTime = cm.ExecuteScalar()
        cn.Close()
        '-------Load Document Code
        cs = String.Format("select Code from Document where aa = {0}", DocAA.ToString())
        cm.CommandText = cs
        cn.Open()
        Dim _DocCode As String = cm.ExecuteScalar()
        cn.Close()
        '-------Load Document Lines
        cs = String.Format("select * from DocLines where DocAA= {0}", DocAA.ToString())
        cm.CommandText = cs
        If ds.Tables.Contains("DocLines") Then
            ds.Tables.Remove("DocLines")
        End If
        cn.Open()
        da.Fill(ds, "DocLines")
        cn.Close()
        '-------Load PersonType
        cs = String.Format("select PersonType from Person where code= '{0}'", ds.Tables("DocHeader").Rows(0)("PersonCode"))
        cm.CommandText = cs
        cn.Open()
        Dim _PersonType As String = cm.ExecuteScalar()
        cn.Close()
        '-------Load VatPerson
        cs = String.Format("select fpa from Person where code= '{0}'", ds.Tables("DocHeader").Rows(0)("PersonCode"))
        cm.CommandText = cs
        cn.Open()
        Dim _VatPerson As String = cm.ExecuteScalar()
        cn.Close()
        '-------Load Model Code
        cs = String.Format("select dt.CodeModel from Document as d inner join DocType as dt on dt.Code = d.DocType where d.aa = {0}", DocAA.ToString())
        cm.CommandText = cs
        cn.Open()
        _CodeModel = cm.ExecuteScalar()
        cn.Close()
        '-------Load Model Lines
        cs = String.Format("select * from BBridgeModelLines where CodeModel = '{0}' order by Source", _CodeModel)
        cm.CommandText = cs
        If ds.Tables.Contains("ModelLines") Then
            ds.Tables.Remove("ModelLines")
        End If
        cn.Open()
        da.Fill(ds, "ModelLines")
        cn.Close()
        '-------UID
        Dim _UID As Guid = System.Guid.NewGuid()

        For Each row As DataRow In ds.Tables("ModelLines").Rows
            EntityParatirisi = row.Item("paratirisi")
            If row.Item("Source") = 0 Then 'DocHeader
                For i As Integer = 0 To ds.Tables("DocHeader").Rows.Count - 1
                    Dim _Source = row.Item("Source")
                    Dim _CrDb As Integer = row.Item("CrDb")
                    cs = row.Item("ValueSQL").ToString().Replace("@DocAA", DocAA.ToString())
                    cm.CommandText = cs
                    cn.Open()
                    Dim _ValueSQL As Decimal = cm.ExecuteScalar()
                    cn.Close()
                    cs = row.Item("AccountSQL").ToString().
                                    Replace("@PersonCode", ds.Tables("DocHeader").Rows(0)("PersonCode").ToString()).
                                    Replace("@PersonType", _PersonType).
                                    Replace("@KratCode", ds.Tables("DocHeader").Rows(0)("KratCode").ToString()).
                                    Replace("@Fpa", ds.Tables("DocHeader").Rows(0)("Fpa").ToString()).
                                    Replace("@CodeModel", _CodeModel).
                                    Replace("@DocAA", DocAA.ToString())
                    cm.CommandText = cs
                    cn.Open()
                    Dim _AccountSQL = cm.ExecuteScalar()
                    If _AccountSQL Is Nothing Or _AccountSQL Is DBNull.Value Then
                        _AccountSQL = ""
                    End If
                    cn.Close()
                    cs = row.Item("Commentsql").ToString().Replace("@DocAA", DocAA.ToString()).
                                    Replace("@PersonCode", ds.Tables("DocHeader").Rows(0)("PersonCode").ToString()).
                                    Replace("@PersonType", _PersonType).
                                    Replace("@KratCode", ds.Tables("DocHeader").Rows(0)("KratCode").ToString()).
                                    Replace("@Fpa", ds.Tables("DocHeader").Rows(0)("Fpa").ToString()).
                                    Replace("@CodeModel", _CodeModel)
                    cm.CommandText = cs
                    cn.Open()
                    Dim _Commentsql = cm.ExecuteScalar()
                    cn.Close()
                    If _Commentsql Is Nothing Or _Commentsql Is DBNull.Value Then
                        _Commentsql = ""
                    End If
                    cs = "insert into BBridgeArticles ([UID],[RDateTime],[DocAA],[DocDate],[Journal],[DocCode],[HeadCmmnt],[AcountCode],[CrDb],[Value],[LineComment],EntityType) values (@UID,@RDateTime,@DocAA,@DocDate,@Journal,@DocCode,@HeadCmmnt,@AcountCode,@CrDb,@Value,@LineComment,@EntityType)"
                    cm.CommandText = cs
                    cm.Parameters.Clear()
                    cm.Parameters.Add("@UID", SqlDbType.UniqueIdentifier).Value = _UID
                    cm.Parameters.Add("@RDateTime", SqlDbType.DateTime).Value = Year(Now()).ToString("D4") + "-" + Month(Now()).ToString("D2") + "-" + Day(Now()).ToString("D2")
                    cm.Parameters.Add("@DocAA", SqlDbType.Int).Value = Convert.ToInt32(DocAA.ToString())
                    cm.Parameters.Add("@DocDate", SqlDbType.DateTime).Value = Year(_DocDate).ToString("D4") + "-" + Month(_DocDate).ToString("D2") + "-" + Day(_DocDate).ToString("D2")
                    cm.Parameters.Add("@Journal", SqlDbType.NVarChar).Value = ""
                    cm.Parameters.Add("@DocCode", SqlDbType.NVarChar).Value = _DocCode
                    cm.Parameters.Add("@HeadCmmnt", SqlDbType.NVarChar).Value = _Commentsql
                    cm.Parameters.Add("@AcountCode", SqlDbType.NVarChar).Value = _AccountSQL
                    cm.Parameters.Add("@CrDb", SqlDbType.Int).Value = _CrDb
                    cm.Parameters.Add("@Value", SqlDbType.Decimal).Value = _ValueSQL
                    cm.Parameters.Add("@LineComment", SqlDbType.NVarChar).Value = ""
                    cm.Parameters.Add("@EntityType", SqlDbType.NVarChar).Value = EntityParatirisi
                    cn.Open()
                    cm.ExecuteNonQuery()
                    cn.Close()
                Next
            End If
            If row.Item("Source") = 1 Then 'DocLine
                For i As Integer = 0 To ds.Tables("DocLines").Rows.Count - 1
                    Dim _lineAA As Integer = 0

                    Dim _Source = row.Item("Source")
                    Dim _CrDb As Integer = row.Item("CrDb")
                    cs = row.Item("ValueSQL").ToString().Replace("@LineAA", ds.Tables("DocLines").Rows(i)("AA"))
                    _lineAA = ds.Tables("DocLines").Rows(i)("AA")
                    Dim _lineVat As Single
                    _lineVat = ifnull(ds.Tables("DocLines").Rows(i)("Vat"), 0)
                    cm.CommandText = cs
                    cn.Open()
                    Dim _ValueSQL As Decimal = cm.ExecuteScalar()
                    cn.Close()
                    cs = row.Item("AccountSQL").ToString().
                                        Replace("@CodeModel", _CodeModel).
                                        Replace("@VatPerson", _VatPerson).
                                        Replace("@PersonCode", ds.Tables("DocHeader").Rows(0)("PersonCode").ToString()).
                                        Replace("@PersonType", _PersonType).
                                        Replace("@DocAA", DocAA.ToString()).
                                        Replace("@DocType", ds.Tables("DocHeader").Rows(0)("DocType").ToString()).
                                        Replace("@Fpa", ds.Tables("DocHeader").Rows(0)("Fpa").ToString()).
                                        Replace("@KratCode", ds.Tables("DocHeader").Rows(0)("KratCode").ToString()).
                                        Replace("@ItemCode", ds.Tables("DocLines").Rows(i)("ItemCode").ToString()).
                                        Replace("@LineAA", ds.Tables("DocLines").Rows(i)("AA")).
                                        Replace("@LineType", ifnull(ds.Tables("DocLines").Rows(i)("LineType"), " "))
                    cm.CommandText = cs
                    cn.Open()
                    Dim _AccountSQL = cm.ExecuteScalar()
                    If _AccountSQL Is Nothing Or _AccountSQL Is DBNull.Value Then
                        _AccountSQL = ""
                    End If
                    cn.Close()
                    cs = row.Item("Commentsql").ToString().Replace("@DocAA", DocAA.ToString()).
                                        Replace("@CodeModel", _CodeModel).
                                        Replace("@VatPerson", _VatPerson).
                                        Replace("@PersonCode", ds.Tables("DocHeader").Rows(0)("PersonCode").ToString()).
                                        Replace("@PersonType", _PersonType).
                                        Replace("@DocAA", DocAA.ToString()).
                                        Replace("@DocType", ds.Tables("DocHeader").Rows(0)("DocType").ToString()).
                                        Replace("@Fpa", ds.Tables("DocHeader").Rows(0)("Fpa").ToString()).
                                        Replace("@KratCode", ds.Tables("DocHeader").Rows(0)("KratCode").ToString()).
                                        Replace("@ItemCode", ds.Tables("DocLines").Rows(i)("ItemCode").ToString()).
                                        Replace("@LineAA", ds.Tables("DocLines").Rows(i)("AA")).
                                        Replace("@LineType", ifnull(ds.Tables("DocLines").Rows(i)("LineType"), " "))
                    cm.CommandText = cs
                    cn.Open()
                    Dim _Commentsql = cm.ExecuteScalar()
                    cn.Close()
                    If _Commentsql Is Nothing Or _Commentsql Is DBNull.Value Then
                        _Commentsql = ""
                    End If
                    cs = "insert into BBridgeArticles ([UID],[RDateTime],[DocAA],[DocDate],[Journal],[DocCode],[HeadCmmnt],[AcountCode],[CrDb],[Value],[LineComment],LineAA,LineVat,EntityType) values (@UID,@RDateTime,@DocAA,@DocDate,@Journal,@DocCode,@HeadCmmnt,@AcountCode,@CrDb,@Value,@LineComment,@LineAA,@LineVat,@EntityType)"
                    cm.CommandText = cs
                    cm.Parameters.Clear()
                    cm.Parameters.Add("@UID", SqlDbType.UniqueIdentifier).Value = _UID
                    cm.Parameters.Add("@RDateTime", SqlDbType.DateTime).Value = Year(Now()).ToString("D4") + "-" + Month(Now()).ToString("D2") + "-" + Day(Now()).ToString("D2")
                    cm.Parameters.Add("@DocAA", SqlDbType.Int).Value = Convert.ToInt32(DocAA.ToString())
                    cm.Parameters.Add("@DocDate", SqlDbType.DateTime).Value = Year(_DocDate).ToString("D4") + "-" + Month(_DocDate).ToString("D2") + "-" + Day(_DocDate).ToString("D2")
                    cm.Parameters.Add("@Journal", SqlDbType.NVarChar).Value = ""
                    cm.Parameters.Add("@DocCode", SqlDbType.NVarChar).Value = _DocCode
                    cm.Parameters.Add("@HeadCmmnt", SqlDbType.NVarChar).Value = ""
                    cm.Parameters.Add("@AcountCode", SqlDbType.NVarChar).Value = _AccountSQL
                    cm.Parameters.Add("@CrDb", SqlDbType.Int).Value = _CrDb
                    cm.Parameters.Add("@Value", SqlDbType.Decimal).Value = _ValueSQL
                    cm.Parameters.Add("@LineComment", SqlDbType.NVarChar).Value = _Commentsql
                    cm.Parameters.Add("@LineAA", SqlDbType.Decimal).Value = _lineAA
                    cm.Parameters.Add("@LineVat", SqlDbType.NVarChar).Value = _lineVat
                    cm.Parameters.Add("@EntityType", SqlDbType.NVarChar).Value = EntityParatirisi
                    cn.Open()
                    cm.ExecuteNonQuery()
                    cn.Close()
                Next
            End If
        Next

        Dim erom As String = ""
        ExeQuer("delete from BBridgeArticles where ISNULL(value,0) =0 and docaa = " & DocAA, Constr)

        Dim re As String = SelQuerS("select count(AcountCode) n from BBridgeArticles where (AcountCode ='' or AcountCode is null) and docaa = " & DocAA, Constr)
        If re <> "0" Then
            If currentCulture() = "EL-GR" Then
                erom = "Δέν Βρέθηκε Λογαριασμός σε " & re & " Γραμμές" & vbCrLf
            ElseIf currentCulture() = "EN-US" Then
                erom = "Account not found in " & re & " Lines" & vbCrLf
            End If
        End If
        'Dim ra As String = SelQuerS("select count(value) n from BBridgeArticles where (value =0 or value is null) and docaa = " & DocAA, Constr)
        Dim ra As String = SelQuerS("select count(value) n from BBridgeArticles where value is null and docaa = " & DocAA, Constr)
        If ra <> "0" Then
            If currentCulture() = "EL-GR" Then
                erom = erom & "Δέν Βρέθηκε Ποσό σε " & ra & " Γραμμές" & vbCrLf
            ElseIf currentCulture() = "EN-US" Then
                erom = erom & "Amount Not Found in " & ra & " Lines" & vbCrLf
            End If

        End If

        Dim rb As String = SelQuerS(" select case when sum(case crdb when 0 then  value else - value end)<>0 then 'Ασυμφωνία Χρέωσης-Πίστωσης' else '' end  from BBridgeArticles  where docaa = " & DocAA, Constr)
        If rb <> "" Then
            Dim difrv = SelQuerS(" select  sum(case crdb when 0 then  value else - value end)  from BBridgeArticles  where docaa = " & DocAA, Constr)
            If Math.Abs(Val(difrv)) > 0.020000000000000011 Then
                erom = erom & rb & vbCrLf
            Else
                Dim ArtlineAA = SelQuerS("SELECT max(ΑΑ) FROM BBridgeArticles where   value <>0 and crdb=1 and docaa = " & DocAA, Constr)
                ExeQuer("update BBridgeArticles set  value =  " & Replace(difrv, ",", ".") & " + value   where αα =  " & ArtlineAA, Constr)
            End If
        End If

        If erom <> "" Then
            If SelQuerS("select isnull(Value,'') as Value from PARAMS where PARAMID='debugBridge'", Constr) = "" Then
                ExeQuer("delete from BBridgeArticles where docaa = " & DocAA, Constr)
            End If
            Dim msg As String = ""
            If currentCulture() = "EL-GR" Then
                msg = "Λάθος " & erom
            ElseIf currentCulture() = "EN-US" Then
                msg = "Error " & erom
            End If
            Return msg
        Else
            Return "OK"
        End If
        Exit Function
errc:
        Return Err.Description
    End Function

    Public Shared Function ifnull(inVal As Object, nval As String) As String
        If inVal Is DBNull.Value Then
            ifnull = nval
        Else
            Return inVal
        End If
    End Function
    Public Shared Function ifnullN(inVal As Object, nval As Single) As Single
        If inVal Is DBNull.Value Then
            ifnullN = nval
        Else
            Return inVal
        End If
    End Function
    Public Shared Function CompanyName(Constr As String) As String
        Dim cn As New SqlConnection()
        Dim cs As String = "Select top 1 isnull(CallCenterName,'') from company"
        Dim cm As New SqlCommand(cs, cn)
        Dim CName As String = ""
        If Constr = "" Then
            CompanyName = ""
        Else
            cn.ConnectionString = Constr
            cn.Open()
            CName = cm.ExecuteScalar()
            cn.Close()
        End If
        Return CName
    End Function

    ''' <summary>
    ''' Αποστολή SMS
    ''' </summary>
    ''' <param name="UserName">Δώσε Όνομα Χρήστη LiveCIS. 'Session("uname")'</param>
    ''' <param name="fromName">Δώσε Όνομα Αποστολέα</param>
    ''' <param name="messageText">Δώσε Κείμενο SMS</param>
    ''' <param name="toMobilePhone">Δώσε κινητό τηλέφωνο Παραλήπτη</param>
    ''' <param name="chargeDatabase">Δώσε Database για Χρέωση</param>
    ''' <param name="Constr">Δώσε Connection String με την ComvoiceMaster. 'LPVARS.cnxstring'</param>
    ''' <returns>True,False</returns>
    ''' <remarks></remarks>
    Public Shared Function sendSMS(UserName As String, fromName As String, messageText As String, toMobilePhone As String, chargeDatabase As String, Constr As String) As Boolean
        Dim str As String = ""
        Dim cs As String = ""
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet
        cn.ConnectionString = Constr
        cm.Connection = cn
        Try
            Dim uName, uPass As String
            uName = "goldens"
            uPass = "solut"
            Dim wc As New WebClient()
            If toMobilePhone <> "" And messageText <> "" And messageText.Length < 151 And fromName <> "" Then
                Dim data As Stream = wc.OpenRead("Http:" & "//api2.amdtelecom.net:8208/?username=" & uName & "&password=" & uPass & "&from=" & fromName & "&to=+30" & toMobilePhone & "&text=" & messageText.ToUpper) '& "&coding=2"
                Using sr As New StreamReader(data)
                    str = sr.ReadToEnd()
                    data.Close()
                End Using
                Dim answer As Boolean = IIf(str.Substring(0, 5).ToUpper = "ERROR", False, True)
                cs = "insert into [SMSRepository] ([Database],[UserName],[SMSfrom],[SMSTo],[SMSDate],[SMSText],[ApiAnswer]) values (@Database,@UserName,@SMSfrom,@SMSTo,@SMSDate,@SMSText,@ApiAnswer)"
                cm.CommandText = cs
                cm.Parameters.Clear()
                cm.Parameters.Add("Database", SqlDbType.VarChar).Value = chargeDatabase
                cm.Parameters.Add("UserName", SqlDbType.VarChar).Value = UserName
                cm.Parameters.Add("SMSfrom", SqlDbType.VarChar).Value = fromName
                cm.Parameters.Add("SMSTo", SqlDbType.VarChar).Value = "+30" & toMobilePhone
                cm.Parameters.Add("SMSDate", SqlDbType.VarChar).Value = Year(Now()).ToString() + "-" + Month(Now()).ToString() + "-" + Day(Now()).ToString() + " " + Hour(Now()).ToString() + ":" + Minute(Now()).ToString() + ":" + Second(Now()).ToString()
                cm.Parameters.Add("SMSText", SqlDbType.VarChar).Value = messageText
                cm.Parameters.Add("ApiAnswer", SqlDbType.VarChar).Value = str.Replace(vbCrLf, "").Replace("<br />", "")
                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()
                Return answer
            Else
                Return False
            End If
        Catch ex As SqlException
            Return IIf(str.Substring(0, 5).ToUpper = "ERROR", False, True)
        Catch ex1 As Exception
            Return False
        End Try
    End Function

    Public Shared Sub fixUserFieldsDescription(tp As String, page As Page, Constr As String)
        Dim cs As String = ""
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet
        cn.ConnectionString = Constr
        cm.Connection = cn

        cs = String.Format("select entity,labelindex,description from labels where entity='{0}'", tp)
        cm.CommandText = cs
        If ds.Tables.Contains("Labels") Then
            ds.Tables.Remove("Labels")
        End If
        cn.Open()
        da.Fill(ds, "Labels")
        cn.Close()
        If ds.Tables("Labels").Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables("Labels").Rows.Count - 1
                Dim tt As Label = page.Controls(0).Controls(3).FindControl("MainContent").FindControl("TabContainer1").FindControl("TabPanel4").FindControl(ds.Tables("Labels").Rows(i)("labelindex"))
                If tt IsNot Nothing Then
                    tt.Text = ds.Tables("Labels").Rows(i)("description")
                End If
            Next
        End If
    End Sub

    Public Shared Function currentCulture() As String
        Dim lang As String = String.Empty
        Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("CaltureName")
        If cookie IsNot Nothing Then
            If cookie.Value IsNot DBNull.Value Then
                lang = cookie.Value
            End If
        End If
        Return lang
    End Function
    Public Shared Sub RightsAcord(mst As MasterPage, RightString As String)
        Dim Rght() As String
        Dim i As Int32 = 0

        Rght = Split(RightString, ";")
        For i = 1 To 23
            If Rght(i) = 1 Then
                Select Case i
                    Case 1
                        mst.FindControl("Accordion1").FindControl("Status").Visible = False
                    Case 2
                        mst.FindControl("Accordion1").FindControl("Communicate").Visible = False
                    Case 3
                        mst.FindControl("Accordion1").FindControl("Pelates").Visible = False
                    Case 4
                        mst.FindControl("Accordion1").FindControl("Promitheytes").Visible = False
                    Case 5
                        mst.FindControl("Accordion1").FindControl("Eidi").Visible = False
                    Case 6
                        mst.FindControl("Accordion1").FindControl("Ypiresies").Visible = False
                    Case 7
                        mst.FindControl("Accordion1").FindControl("XrDiathesima").Visible = False
                    Case 8
                        mst.FindControl("Accordion1").FindControl("Axiografa").Visible = False
                    Case 9
                        mst.FindControl("Accordion1").FindControl("Timokatalogoi").Visible = False
                    Case 10
                        mst.FindControl("Accordion1").FindControl("Poliseis").Visible = False
                    Case 11
                        mst.FindControl("Accordion1").FindControl("AgoresDapanes").Visible = False
                    Case 12
                        mst.FindControl("Accordion1").FindControl("Eispraxeis").Visible = False
                    Case 13
                        mst.FindControl("Accordion1").FindControl("Pliromes").Visible = False
                    Case 14
                        mst.FindControl("Accordion1").FindControl("Xreopistosis").Visible = False
                    Case 15
                        mst.FindControl("Accordion1").FindControl("Ektyposeis").Visible = False
                    Case 16
                        mst.FindControl("Accordion1").FindControl("Cube").Visible = False
                    Case 17
                        mst.FindControl("Accordion1").FindControl("Link1").Visible = False
                    Case 18
                        mst.FindControl("Accordion1").FindControl("TreeView1").Visible = False
                    Case 19
                        mst.FindControl("Accordion1").FindControl("Link2").Visible = False
                    Case 20
                        mst.FindControl("Accordion1").FindControl("Maintainance").Visible = False
                    Case 21
                        mst.FindControl("Accordion1").FindControl("ChangePassword").Visible = False
                    Case 22
                        mst.FindControl("Accordion1").FindControl("imBtnImportFile").Visible = False
                    Case 23
                        mst.FindControl("Accordion1").FindControl("GefyresLogistikis").Visible = False
                End Select
            End If
        Next i
    End Sub

    Public Shared Function SendTCP(Root As String, FName As String, IPAdrress As String, PortN As Int32) As Boolean
        Dim rertyCount = 0
start:  Dim BufferSize As Integer = 2048
        Dim SendingBuffer As Byte() = Nothing
        Dim client As TcpClient = Nothing
        'lblStatus.Text = ""
        Dim netstream As NetworkStream = Nothing
        Try
            client = New TcpClient(IPAdrress, PortN)
            'lblStatus.Text = "Connected to the Server..." & vbLf
            Dim FullPath = Root & "\" & FName
            Dim Fs As New FileStream(FullPath, FileMode.Open, FileAccess.Read)
            Dim dd As [Byte]() = System.Text.ASCIIEncoding.ASCII.GetBytes("File" + FName & ":" & Fs.Length)
            client.Client.Send(dd)
            netstream = client.GetStream()
            Dim NoOfPackets As Integer = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)))
            'ProgressBar1.Maximum = NoOfPackets
            Dim TotalLength As Integer = CInt(Fs.Length), CurrentPacketLength As Integer, counter As Integer = 0
            For i As Integer = 0 To NoOfPackets - 1
                If TotalLength > BufferSize Then
                    CurrentPacketLength = BufferSize
                    TotalLength = TotalLength - CurrentPacketLength
                Else
                    CurrentPacketLength = TotalLength
                End If
                SendingBuffer = New Byte(CurrentPacketLength - 1) {}
                Fs.Read(SendingBuffer, 0, CurrentPacketLength)
                netstream.Write(SendingBuffer, 0, CInt(SendingBuffer.Length))
                Dim returndata As String = ""
                Do
                    Dim bytesGo As [Byte]() = New Byte(client.ReceiveBufferSize - 1) {}
                    netstream.Read(bytesGo, 0, CInt(client.ReceiveBufferSize))
                    returndata = Encoding.UTF8.GetString(bytesGo)
                Loop While returndata.Substring(0, 6) <> "GoGoGo"

                'If ProgressBar1.Value >= ProgressBar1.Maximum Then
                '    ProgressBar1.Value = ProgressBar1.Minimum
                'End If
                'ProgressBar1.PerformStep()
            Next
            'progressBar1.Value = 100;
            'lblStatus.Text = lblStatus.Text + "Sent " & Fs.Length.ToString() & " bytes to the server"
            Fs.Close()

            Dim ee As [Byte]() = System.Text.ASCIIEncoding.ASCII.GetBytes("TransferComplete")
            client.Client.Send(ee)

            Dim returndataEnd As [String] = ""
            Do
                Dim bytes As [Byte]() = New Byte(client.ReceiveBufferSize - 1) {}
                netstream.Read(bytes, 0, CInt(client.ReceiveBufferSize))
                returndataEnd = Encoding.UTF8.GetString(bytes)
            Loop While (returndataEnd.Substring(0, 8) <> "To peira" And returndataEnd.Substring(0, 9) <> "KsanaDose")
            netstream.Close()
            client.Close()
            If returndataEnd.Substring(0, 8) = "To peira" Then
                rertyCount = 0
            End If
            If returndataEnd.Substring(0, 9) = "KsanaDose" Then
                rertyCount += 1
                If rertyCount > 3 Then
                    Return False
                Else
                    GoTo start
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function GetQuery(QueryID As String, constring As String, Optional ReplaceCretString As String = "") As String
        On Error GoTo erh
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand("Select Query from Queries where id = '" & QueryID & "'", cn)
        sqcm.CommandText = "Select Query from Queries where id = '" & QueryID & "'"
        dtr = sqcm.ExecuteReader()
        dtr.Read()
        Dim QueryStrin As String
        QueryStrin = dtr.Item(0).ToString
        If ReplaceCretString <> "" Then
            Dim vlus() As String = Split(ReplaceCretString, ";")
            QueryStrin = Replace(QueryStrin, "[CRETER]", vlus(0).ToString)
            For i = 0 To vlus.Length - 1
                QueryStrin = Replace(QueryStrin, "[CRETER" & i.ToString & "]", vlus(i).ToString)
            Next

        End If
        GetQuery = QueryStrin
        'SelQuerS = Format(dtr.Item(0), "0.00")
        cn.Close()
        Exit Function
erh:
        GetQuery = ""
    End Function

    Public Shared Function GetDocsXon(CompanyCon As String) As Integer
        Dim cn As New SqlConnection()

        Dim cs As String = ""
        Dim cm As New SqlCommand(cs, cn)
        Dim ds As DataSet = New DataSet()
        Dim da As New SqlDataAdapter(cm)
        Dim ticketsBuyed As Integer
        cn.ConnectionString = CompanyCon
        'cs = String.Format("Use ComvoiceMaster; select Ticket from tickets where substring(Ticket,1,{0}) = '{1}'", cn.Database.Length, cn.Database)
        'cs = String.Format("Use ComvoiceMaster; select dbname,Cnt,Dte,Typos from TicketsB where dbname = '{0}' and typos = 'Docs' and DateAdd(day,365,Dte) >= getDate()", cn.Database)
        'cm.CommandText = cs
        'If ds.Tables.Contains("Tickets") Then
        '    ds.Tables.Remove("Tickets")
        'End If
        cn.Open()
        ticketsBuyed = SelQuerS("select isnull(sum(Cnt),0) cnt from TicketsB where dbname = '" & cn.Database & "' and typos = 'Docs' and DateAdd(day,365,Dte) >= getDate()", LPVARS.cnxstring)
        'MsgBox(ticketsBuyed)

        'da.Fill(ds, "Tickets")
        'cn.Close()
        'ticketsBuyed = 0
        'If ds.Tables("Tickets").Rows.Count > 0 Then
        '    For i As Integer = 0 To ds.Tables("Tickets").Rows.Count - 1
        '        ticketsBuyed += ds.Tables("Tickets").Rows(i)("Cnt")
        '    Next
        'End If




        cs = String.Format("SELECT count(*) FROM Document inner join Person on Person.Code = Document.PersonCode and Person.PersonType = Document.PersonType inner join doctype on doctype.code = document.DocType where Working = 0 and doctype.type = 'ΠΩΛΗΣΕΙΣ' and doctype.team = 'ΤΙΜΟΛΟΓΙΟ' and  isnull(doctype.RetailCharge,0) = 0 and Document.Docdate between (select DateAdd(day,-1,min(dte)) from ComvoiceMaster.dbo.TicketsB where dbname = '{0}' and Typos = 'Docs' and dateadd(day,-365,getdate()) <= dte) and (select DateAdd(day,366,max(dte)) from ComvoiceMaster.dbo.TicketsB where dbname = '{0}' and Typos = 'Docs' and dateadd(day,-365,getdate()) <= dte)", cn.Database)
        cm.CommandText = cs
        'cn.Open()
        Dim TicketsUsed As Integer = cm.ExecuteScalar()
        cn.Close()
        Dim RetainTickets As Integer = ticketsBuyed - TicketsUsed

        GetDocsXon = RetainTickets
    End Function

    'Public Shared Function GetDocsXon(CompanyCon As String, Optional ByRef RefDay As Date = #1/1/2016#) As Integer
    '    Dim cn As New SqlConnection()
    '    Dim cs As String = ""
    '    Dim cm As New SqlCommand(cs, cn)
    '    Dim ds As DataSet = New DataSet()
    '    Dim da As New SqlDataAdapter(cm)
    '    Dim ticketsBuyed As Integer
    '    cn.ConnectionString = CompanyCon
    '    'cs = String.Format("Use ComvoiceMaster; select Ticket from tickets where substring(Ticket,1,{0}) = '{1}'", cn.Database.Length, cn.Database)
    '    cs = String.Format("Use ComvoiceMaster; select dbname,Cnt,Dte,Typos,DateAdd(day,365,Dte) RefrDt from TicketsB where dbname = '{0}' and typos = 'Docs' and DateAdd(day,365,Dte) >= getDate()", cn.Database)
    '    cm.CommandText = cs
    '    If ds.Tables.Contains("Tickets") Then
    '        ds.Tables.Remove("Tickets")
    '    End If
    '    cn.Open()
    '    da.Fill(ds, "Tickets")
    '    cn.Close()
    '    ticketsBuyed = 0
    '    RefDay = ds.Tables("Tickets").Rows(0)("RefrDt")
    '    'MsgBox(RefDay)
    '    If ds.Tables("Tickets").Rows.Count > 0 Then
    '        For i As Integer = 0 To ds.Tables("Tickets").Rows.Count - 1
    '            ticketsBuyed += ds.Tables("Tickets").Rows(i)("Cnt")
    '        Next
    '    End If
    '    cs = String.Format("SELECT count(*) FROM Document inner join Person on Person.Code = Document.PersonCode and Person.PersonType = Document.PersonType inner join doctype on doctype.code = document.DocType where Working = 0 and doctype.type = 'ΠΩΛΗΣΕΙΣ' and doctype.team = 'ΤΙΜΟΛΟΓΙΟ' and  isnull(doctype.RetailCharge,0) = 0 and Document.Docdate between (select DateAdd(day,-1,min(dte)) from ComvoiceMaster.dbo.TicketsB where dbname = '{0}' and Typos = 'Docs' and dateadd(day,-365,getdate()) <= dte) and (select DateAdd(day,366,max(dte)) from ComvoiceMaster.dbo.TicketsB where dbname = '{0}' and Typos = 'Docs' and dateadd(day,-365,getdate()) <= dte)", cn.Database)
    '    cm.CommandText = cs
    '    cn.Open()
    '    Dim TicketsUsed As Integer = cm.ExecuteScalar()
    '    cn.Close()
    '    Dim RetainTickets As Integer = ticketsBuyed - TicketsUsed

    '    GetDocsXon = RetainTickets
    'End Function

    Public Shared Function GetDocsLian(CompanyCon As String) As Integer
        Dim cn As New SqlConnection()
        Dim cs As String = ""
        Dim cm As New SqlCommand(cs, cn)
        Dim ds As DataSet = New DataSet()
        Dim da As New SqlDataAdapter(cm)
        Dim tickets1Buyed As Integer
        cn.ConnectionString = CompanyCon
        'cs = String.Format("Use ComvoiceMaster; select Ticket from tickets1 where substring(Ticket,1,{0}) = '{1}'", cn.Database.Length, cn.Database)
        'cs = String.Format("Use ComvoiceMaster; select dbname,Cnt,Dte,Typos from TicketsB where dbname = '{0}' and typos = 'Retail' and DateAdd(day,365,Dte) >= getDate()", cn.Database)
        'cm.CommandText = cs
        'If ds.Tables.Contains("Tickets1") Then
        '    ds.Tables.Remove("Tickets1")
        'End If
        cn.Open()
        'da.Fill(ds, "Tickets1")

        tickets1Buyed = 0
        'If ds.Tables("Tickets1").Rows.Count > 0 Then
        '    For i As Integer = 0 To ds.Tables("Tickets1").Rows.Count - 1
        '        tickets1Buyed += ds.Tables("Tickets1").Rows(i)("Cnt")
        '    Next
        'End If

        cs = String.Format("select isnull(sum(Cnt),0) from TicketsB where dbname = '{0}' and typos = 'Retail' and DateAdd(day,365,Dte) >= getDate()", cn.Database)
        tickets1Buyed = SelQuerS(cs, LPVARS.cnxstring)
        cn.Close()
        cs = String.Format("SELECT isnull(count(*),0) FROM Document inner join Person on Person.Code = Document.PersonCode and Person.PersonType = Document.PersonType inner join doctype on doctype.code = document.DocType where Working = 0 and doctype.type = 'ΠΩΛΗΣΕΙΣ' and doctype.team = 'ΤΙΜΟΛΟΓΙΟ' and  isnull(doctype.RetailCharge,0) = 1 and Document.Docdate between (select DateAdd(day,-1,min(dte)) from ComvoiceMaster.dbo.TicketsB where dbname = '{0}' and Typos = 'Retail' and dateadd(day,-365,getdate()) <= dte) and (select DateAdd(day,366,max(dte)) from ComvoiceMaster.dbo.TicketsB where dbname = '{0}' and Typos = 'Retail' and dateadd(day,-365,getdate()) <= dte)", cn.Database)
        cm.CommandText = cs
        cn.Open()
        Dim Tickets1Used As Integer = cm.ExecuteScalar()
        cn.Close()
        Dim Retain1Tickets As Integer = tickets1Buyed - Tickets1Used
        GetDocsLian = Retain1Tickets
    End Function

    Public Shared Function Encrypt(s As String) As String
        Try
            Dim plainText As String = s
            Dim A_ES As New System.Security.Cryptography.RijndaelManaged
            Dim enrypted As String = ""
            A_ES.KeySize = 256
            A_ES.BlockSize = 128
            A_ES.Key = System.Text.ASCIIEncoding.ASCII.GetBytes("!&!(!&!(!&!(!&!(!&!(!&!(!&!(!&!(")
            A_ES.IV = System.Text.ASCIIEncoding.ASCII.GetBytes("!&!(!&!(!&!(!&!(")
            A_ES.Mode = System.Security.Cryptography.CipherMode.CBC
            A_ES.Padding = PaddingMode.None
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = A_ES.CreateEncryptor
            Dim BufferTemp As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plainText)
            Dim Buffer1(63) As Byte
            '= System.Text.ASCIIEncoding.ASCII.GetBytes(plainText)
            For i As Integer = 0 To 63
                If BufferTemp.Length > i Then
                    Buffer1(i) = BufferTemp(i)
                Else
                    Buffer1(i) = 0
                End If
            Next
            enrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer1, 0, Buffer1.Length))
            Return enrypted
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Shared Function GetList(Entity As String, Subentity As String, constring As String, Optional ReplaceCretString As String = "", Optional ByRef ListDescr As String = "") As String
        On Error GoTo erh
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand("Select substring(dbsql,0,8000) + ' ' +  isnull(ordby,' ') from lists where dbentity = '" & Entity & "' and isnull(subentity,'') like '" & Subentity & "'", cn)
        sqcm.CommandText = "Select substring(dbsql,0,8000) + ' ' +  isnull(ordby,' '),dbDescr from lists where dbentity = '" & Entity & "' and isnull(subentity,'') like '" & Subentity & "'"
        dtr = sqcm.ExecuteReader()
        dtr.Read()
        Dim QueryStrin As String
        QueryStrin = dtr.Item(0).ToString
        ListDescr = dtr.Item(1).ToString()
        If ReplaceCretString <> "" Then
            Dim vlus() As String = Split(ReplaceCretString, ";")
            QueryStrin = Replace(QueryStrin, "[CRETER]", vlus(0).ToString)
            For i = 0 To vlus.Length - 1
                QueryStrin = Replace(QueryStrin, "[CRETER" & i.ToString & "]", vlus(i).ToString)
            Next

        End If
        GetList = QueryStrin
        'SelQuerS = Format(dtr.Item(0), "0.00")
        cn.Close()
        Exit Function
erh:
        GetList = ""
    End Function
    Public Shared Function Decrypt(s As String) As String
        Dim sChars As String = " "
        Dim encryptedText As String = s.Replace(" ", "+")
        '"MDC7yavES2GqtRrpA7XfmQ=="
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim decrypted As String = ""
        AES.KeySize = 256
        AES.BlockSize = 128
        AES.Key = System.Text.ASCIIEncoding.ASCII.GetBytes("!&!(!&!(!&!(!&!(!&!(!&!(!&!(!&!(")
        AES.IV = System.Text.ASCIIEncoding.ASCII.GetBytes("!&!(!&!(!&!(!&!(")
        AES.Mode = System.Security.Cryptography.CipherMode.CBC
        AES.Padding = System.Security.Cryptography.PaddingMode.None
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        Try
            Dim Buffer As Byte() = Convert.FromBase64String(encryptedText)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Dim darray As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(decrypted)
            For i As Integer = 0 To darray.Length - 1
                If darray(i) <= 10 Then
                    darray(i) = 10
                End If
            Next
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(darray)
            Return decrypted.Trim
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Shared Function CnxstrFromUname(uName As String) As String
        Dim cs As String = ""
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet
        Try

            'If LPVARS.cnxstring = "" Then
            '    LPVARS.cnxstring = "server=localhost;uid=sa;pwd=clroot;database=ComVoiceMaster"
            'End If
            cn.ConnectionString = LPVARS.cnxstring '"server=server\live;uid=sa;pwd=clroot;database=ComVoiceMaster" 'LPVARS.cnxstring
            cm.Connection = cn
            cs = String.Format("select isnull(cnxstr,'') from users where UserName = '{0}'", uName)
            cm.CommandText = cs
            cn.Open()
            Dim answer = cm.ExecuteScalar()
            cn.Close()
            Return answer
        Catch ex As Exception
            cn.Close()
            Return ""
        End Try
    End Function
    Public Shared Function CnxstrFromSessID(SessID As String) As String
        Dim cs As String = ""
        Dim cn As New SqlConnection()
        Dim cm As New SqlCommand()
        Dim da As New SqlDataAdapter(cm)
        Dim ds As New DataSet
        Try

            'If LPVARS.cnxstring = "" Then
            '    LPVARS.cnxstring = "server=localhost;uid=sa;pwd=clroot;database=ComVoiceMaster"
            'End If
            cn.ConnectionString = LPVARS.cnxstring '"server=server\live;uid=sa;pwd=clroot;database=ComVoiceMaster" 'LPVARS.cnxstring
            cm.Connection = cn
            cs = String.Format("select top 1 isnull(Constr,'') from Sessions where Sessid = '{0}'", SessID)
            cm.CommandText = cs
            cn.Open()
            Dim answer = cm.ExecuteScalar()
            cn.Close()
            Return answer
        Catch ex As Exception
            cn.Close()
            Return ""
        End Try
    End Function
    '' Example
    ''    Dim f(5) As String, v(5) As String, d(5) As String
    ''    f(0) = "Code" : v(0) = "TEST"
    ''    f(1) = "Descr" : v(1) = "Mitsos"
    ''    f(2) = "TIMI" : v(2) = "35,2" : d(2) = "N"
    ''    f(3) = "Category" : v(3) = "null"
    ''    f(4) = "DT" : v(4) = "01/03/2014" : d(4) = "D"
    ''    TextBox1.Text = CrUpdate(f, v, d, "Person", "Where AA = " & "1")
    Public Shared Function CrUpdate(FieldsArray() As String, ValueArray() As String, DatatypeArray() As String, Tablename As String, WhereStatement As String) As String
        Dim rets As String
        rets = " Update " & Tablename & vbCrLf & " set " & vbCrLf
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter("c:\steps.txt", True)


        For i = 0 To FieldsArray.GetUpperBound(0) - 1
            'file.Write(FieldsArray(i) & "----" & DatatypeArray(i) & "---" & ValueArray(i))
            If FieldsArray(i) <> "" Then
                If String.IsNullOrEmpty(ValueArray(i)) Then ValueArray(i) = "NULL"
                If DatatypeArray(i) = "" Or DatatypeArray(i) = "S" Then
                    If ValueArray(i).ToUpper = "NULL" Then
                        rets = rets & " " & FieldsArray(i) & " = null ," & vbCrLf
                    Else
                        rets = rets & " " & FieldsArray(i) & " = '" & Replace(ValueArray(i), "'", "`") & "'," & vbCrLf
                    End If
                End If
                If DatatypeArray(i) = "N" Then
                    rets = rets & " " & FieldsArray(i) & " = " & fixsnum(ValueArray(i)) & "," & vbCrLf
                End If
                If DatatypeArray(i) = "C" Then
                    rets = rets & " " & FieldsArray(i) & " = " & fixsnum(ValueArray(i)) & "," & vbCrLf
                End If
                If DatatypeArray(i) = "D" Then
                    If ValueArray(i) = "" Then
                        rets = rets & " " & FieldsArray(i) & " = null," & vbCrLf
                    Else
                        rets = rets & " " & FieldsArray(i) & " = '" & fixsDAte(ValueArray(i)) & "'," & vbCrLf
                    End If

                End If
            End If
        Next i

        rets = Left(rets, Len(rets) - 3) & vbCrLf
        rets = rets & WhereStatement
        Return rets

        'file.Close()
    End Function
    Public Shared Function CrInsert(FieldsArray() As String, ValueArray() As String, DatatypeArray() As String, Tablename As String) As String
        Dim rets As String
        rets = "insert into " & Tablename & vbCrLf & "(" & vbCrLf

        For i = 0 To FieldsArray.GetUpperBound(0) - 1
            If FieldsArray(i) <> "" Then
                rets = rets & " " & FieldsArray(i) & "," & vbCrLf
            End If
        Next i

        rets = Left(rets, Len(rets) - 3) & ")" & vbCrLf & " Values ("

        For i = 0 To FieldsArray.GetUpperBound(0) - 1
            If String.IsNullOrEmpty(ValueArray(i)) Then ValueArray(i) = "NULL"
            If FieldsArray(i) <> "" Then
                If DatatypeArray(i) = "" Or DatatypeArray(i) = "S" Then
                    If ValueArray(i).ToUpper = "NULL" Then
                        rets = rets & "null ," & vbCrLf
                    Else
                        rets = rets & "'" & Replace(ValueArray(i), "'", "`") & "'," & vbCrLf
                    End If
                End If
                If DatatypeArray(i) = "N" Then
                    rets = rets & "" & fixsnum(ValueArray(i)) & "," & vbCrLf
                End If
                If DatatypeArray(i) = "C" Then
                    rets = rets & "" & fixsnum(ValueArray(i)) & "," & vbCrLf
                End If
                If DatatypeArray(i) = "D" Then
                    If ValueArray(i) = "" Then
                        rets = rets & "null ," & vbCrLf
                    Else
                        rets = rets & "'" & fixsDAte(ValueArray(i)) & "'," & vbCrLf
                    End If

                End If
            End If
        Next i
        rets = Left(rets, Len(rets) - 3) & ")"

        Return rets
    End Function






    Public Shared Function SelQDS(SQls As String, cnxstr As String) As DataTable
        Dim cn As New SqlConnection
        Dim Dsa As New DataSet("Selqds")
        cn.ConnectionString = cnxstr
        cn.Open()
        'Dim sqcm As SqlCommand
        'sqcm = New SqlCommand(SQls, cn)
        'sqcm.CommandText = "Select * from person where afm = '" & UserName.Text & "'"
        Dim Datad As New SqlDataAdapter(SQls, cn)
        'Dim dsPubs As New DataSet("Pubs")

        Datad.FillSchema(Dsa, SchemaType.Source, "Selqds")
        Datad.Fill(Dsa, "Selqds")

        Dim tblSelqds As DataTable
        tblSelqds = Dsa.Tables("Selqds")
        Return tblSelqds
        ' dtr.Close()
    End Function
    Public Shared Function SelQDefn(SQls As String, cnxstr As String) As DataSet
        Dim cn As New SqlConnection
        Dim Dsa As New DataSet("Selqds")
        cn.ConnectionString = cnxstr
        cn.Open()
        'Dim sqcm As SqlCommand
        'sqcm = New SqlCommand(SQls, cn)
        'sqcm.CommandText = "Select * from person where afm = '" & UserName.Text & "'"
        Dim Datad As New SqlDataAdapter(SQls, cn)
        'Dim dsPubs As New DataSet("Pubs")

        Datad.FillSchema(Dsa, SchemaType.Source, "Selqds")
        Datad.Fill(Dsa, "Selqds")
        Return Dsa
        'Dim tblSelqds As DataTable
        'tblSelqds = Dsa.Tables("Selqds")
        'Return tblSelqds
        ' dtr.Close()
    End Function
    Public Shared Function SplitToCollection(inString As String) As Collection
        Dim hideArray() As String = inString.Split(",")
        Dim Cole As New Collection
        For i As Integer = 0 To hideArray.Length - 1
            Cole.Add(hideArray(i))
        Next
        Return Cole
    End Function
    Public Shared Function SelQuerSST(querys As String, constring As String) As String()
        On Error GoTo erh
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand(querys, cn)
        sqcm.CommandText = querys
        dtr = sqcm.ExecuteReader()

        Dim Retb(100) As String
        Dim i As Integer = 0

        Do While dtr.Read()
            If i Mod 99 = 0 Then
                ReDim Preserve Retb(i + 99)
            End If
            Retb(i) = dtr.Item(0).ToString
            i = i + 1
        Loop
        ReDim Preserve Retb(i)
        cn.Close()
        Return Retb
        Exit Function
erh:
        Dim EmptT(0) As String
        Return EmptT
    End Function

    Public Shared Function SelQuerSST2D(querys As String, constring As String) As String()
        On Error GoTo erh
        Dim cn As New SqlConnection
        Dim dtr As SqlDataReader
        cn.ConnectionString = constring
        cn.Open()
        Dim sqcm As SqlCommand
        sqcm = New SqlCommand(querys, cn)
        sqcm.CommandText = querys
        dtr = sqcm.ExecuteReader()

        Dim Retb() As String
        Dim i As Integer = 0

        Do While dtr.Read()
            If i Mod 100 = 0 Then
                ReDim Preserve Retb(i + 99)
            End If
            Retb(i) = dtr.Item(0).ToString
            Retb(i + 1) = dtr.Item(1).ToString
            i = i + 2
        Loop
        ReDim Preserve Retb(i - 1)
        cn.Close()
        Return Retb
        Exit Function
erh:
        Dim EmptT(0) As String
        Return EmptT
    End Function
    Public Shared Function LoadMainConnection() As String
        Dim RetCon As String
        If LPVARS.cnxstring = "" Then
            Dim objReader As New StreamReader(System.Web.HttpContext.Current.Request.MapPath("~\\Constr.ini"))
            Dim Istr As String = objReader.ReadLine
            If Left(Istr, 6) = "server" Then
                LPVARS.cnxstring = Istr
            Else
                LPVARS.cnxstring = LPVARS.AES_DecryptHexnk(Istr)
            End If

            RetCon = LPVARS.cnxstring
        Else
            RetCon = LPVARS.cnxstring
        End If
        Return RetCon
    End Function

    Public Shared Function AES_EncryptHexnk(ByVal input As String) As String
        Return AES_EncryptHex(input, "LiveSecuredKey!!612kasope")
    End Function

    Public Shared Function AES_DecryptHexnk(ByVal input As String) As String

        ' MsgBox(HttpContext.Current.Server.MapPath("/"))

        Return AES_DecryptHex(input, "LiveSecuredKey!!612kasope")

    End Function
    Public Shared Function AES_EncryptHex(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged

        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor

            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

            Return StringToHex(encrypted)
            'Return StringToHex(encrypted)
        Catch ex As Exception
            Return "error"
        End Try
    End Function

    Public Shared Function AES_DecryptHex(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        input = HexToString(input)
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Public Shared Function StringToHex(ByVal text As String) As String
        Dim hex As String = ""
        For i As Integer = 0 To text.Length - 1
            hex &= Asc(text.Substring(i, 1)).ToString("x").ToUpper
        Next
        Return hex
    End Function
    Public Shared Function HexToString(ByVal hex As String) As String
        Dim text As New System.Text.StringBuilder(hex.Length \ 2)
        For i As Integer = 0 To hex.Length - 2 Step 2
            text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
        Next
        Return text.ToString
    End Function

    Public Shared Function jqgrid() As String
        Dim JQScr As String = " $(function () {" & vbCrLf
        JQScr = JQScr & "         $('#grid').w2grid({" & vbCrLf
        JQScr = JQScr & "             name: 'grid'," & vbCrLf
        JQScr = JQScr & "             show: {" & vbCrLf
        JQScr = JQScr & "                 toolbar: true," & vbCrLf
        JQScr = JQScr & "                 footer: true" & vbCrLf
        JQScr = JQScr & "             }," & vbCrLf
        JQScr = JQScr & "             multiSearch: true," & vbCrLf
        JQScr = JQScr & "             searches: [" & vbCrLf
        JQScr = JQScr & "                 { field: 'recid', caption: 'ID ', type: 'int' }," & vbCrLf
        JQScr = JQScr & "                 { field: 'lname', caption: 'Last Name', type: 'text' }," & vbCrLf
        JQScr = JQScr & "                 { field: 'fname', caption: 'First Name', type: 'text' }," & vbCrLf
        JQScr = JQScr & "                 { field: 'email', caption: 'Email', type: 'list', options: { items: ['peter@gmail.com', 'jim@gmail.com', 'jdoe@gmail.com'] } }," & vbCrLf
        JQScr = JQScr & "                 { field: 'sdate', caption: 'Start Date', type: 'date' }" & vbCrLf
        JQScr = JQScr & "             ]," & vbCrLf
        JQScr = JQScr & "             columns: [" & vbCrLf
        JQScr = JQScr & "                 { field: 'recid', caption: 'ID', size: '50px', sortable: true, attr: 'align=center' }," & vbCrLf
        JQScr = JQScr & "                 { field: 'lname', caption: 'Last Name', size: '30%', sortable: true }," & vbCrLf
        JQScr = JQScr & "                 { field: 'fname', caption: 'First Name', size: '30%', sortable: true }," & vbCrLf
        JQScr = JQScr & "                 { field: 'email', caption: 'Email', size: '40%' }," & vbCrLf
        JQScr = JQScr & "                 { field: 'sdate', caption: 'Start Date', render: 'date:dd/mm/yyyy', size: '120px', sortable: true }," & vbCrLf
        JQScr = JQScr & "             ]," & vbCrLf
        JQScr = JQScr & "             records: [" & vbCrLf
        JQScr = JQScr & "                 { recid: 1, fname: 'Jane', lname: 'Doe', email: 'jdoe@gmail.com', sdate: '01/03/2014' }," & vbCrLf
        JQScr = JQScr & "                 { recid: 2, fname: 'Stuart', lname: 'Motzart', email: 'jdoe@gmail.com', sdate: 1384052583664 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 3, fname: 'Jin', lname: 'Franson', email: 'peter@gmail.com', sdate: 1383620688314 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 4, fname: 'Susan', lname: 'Ottie', email: 'jim@gmail.com', sdate: 1384052463664 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 5, fname: 'Kelly', lname: 'Silver', email: 'peter@gmail.com', sdate: 1383793476323 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 6, fname: 'Francis', lname: 'Gatos', email: 'jdoe@gmail.com', sdate: 1383620688314 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 7, fname: 'Mark', lname: 'Welldo', email: 'jim@gmail.com', sdate: 1383361499126 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 8, fname: 'Thomas', lname: 'Bahh', email: 'jdoe@gmail.com', sdate: 1383793476323 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 9, fname: 'Sergei', lname: 'Rachmaninov', email: 'jdoe@gmail.com', sdate: 1383620688314 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 20, fname: 'Jill', lname: 'Doe', email: 'jdoe@gmail.com', sdate: 1383361499126 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 21, fname: 'Frank', lname: 'Motzart', email: 'jdoe@gmail.com', sdate: 1384052383664 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 22, fname: 'Peter', lname: 'Franson', email: 'jdoe@gmail.com', sdate: 1383793476323 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 23, fname: 'Andrew', lname: 'Ottie', email: 'jdoe@gmail.com', sdate: 1384054483664 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 24, fname: 'Manny', lname: 'Silver', email: 'jdoe@gmail.com', sdate: 1383361499126 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 25, fname: 'Ben', lname: 'Gatos', email: 'peter@gmail.com', sdate: 1383793476323 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 26, fname: 'Doer', lname: 'Welldo', email: 'jdoe@gmail.com', sdate: 1383361499126 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 27, fname: 'Shashi', lname: 'Bahh', email: 'jim@gmail.com', sdate: 1384052483664 }," & vbCrLf
        JQScr = JQScr & "                 { recid: 28, fname: 'Av', lname: 'Rachmaninov', email: 'jim@gmail.com', sdate: 1383620688314 }" & vbCrLf
        JQScr = JQScr & "             ]" & vbCrLf
        JQScr = JQScr & "         });" & vbCrLf
        JQScr = JQScr & "     }); "
        Return JQScr
    End Function
    'Public Shared Function JQScriAutoCompLaspx(UserName As String, QueryID As String, UnID As String, T1 As ASPxTextBox, Optional T2 As ASPxTextBox = Nothing, Optional T3 As Object = Nothing, Optional T4 As Object = Nothing) As String
    '    Dim JQAC As String = "<script type=""text/javascript""> " & vbCrLf
    '    JQAC = JQAC & "          $(document).ready(function () { " & vbCrLf
    '    JQAC = JQAC & "              var prm = Sys.WebForms.PageRequestManager.getInstance(); " & vbCrLf
    '    JQAC = JQAC & "              prm.add_initializeRequest(InitializeRequest" & UnID & "); " & vbCrLf
    '    JQAC = JQAC & "              prm.add_endRequest(EndRequest" & UnID & "); " & vbCrLf
    '    JQAC = JQAC & "              InitAutoCompl" & UnID & "(); " & vbCrLf
    '    JQAC = JQAC & "          }); " & vbCrLf
    '    JQAC = JQAC & "          function InitializeRequest" & UnID & "(sender, args) { " & vbCrLf
    '    JQAC = JQAC & "          } " & vbCrLf
    '    JQAC = JQAC & "          function EndRequest" & UnID & "(sender, args) { " & vbCrLf
    '    JQAC = JQAC & "              InitAutoCompl" & UnID & "(); " & vbCrLf
    '    JQAC = JQAC & "          } " & vbCrLf
    '    JQAC = JQAC & "          function InitAutoCompl" & UnID & "() { " & vbCrLf
    '    JQAC = JQAC & "              $.ajax({ " & vbCrLf
    '    JQAC = JQAC & "                  type: ""POST"", " & vbCrLf
    '    JQAC = JQAC & "                  url: ""Livecis.asmx/GetLookupAC"", " & vbCrLf
    '    JQAC = JQAC & "                  dataType: ""json"", " & vbCrLf
    '    JQAC = JQAC & "                  data: ""{uname:'" & UserName & "',LookUPID:'" & QueryID & "'}"", " & vbCrLf
    '    JQAC = JQAC & "              contentType: ""application/json; charset=utf-8"", " & vbCrLf
    '    JQAC = JQAC & "              success: function (data) { " & vbCrLf
    '    JQAC = JQAC & "                  $(""#" & T1.ClientID & """).autocomplete({ " & vbCrLf
    '    JQAC = JQAC & "                              minLength: 0, " & vbCrLf
    '    JQAC = JQAC & "                              source: data.d, " & vbCrLf
    '    JQAC = JQAC & "                              focus: function (event, ui) { " & vbCrLf
    '    JQAC = JQAC & "                                  $(""" & T1.ClientID & """).val(ui.item.kodik); " & vbCrLf
    '    JQAC = JQAC & "                                  return false; " & vbCrLf
    '    JQAC = JQAC & "                              }, " & vbCrLf
    '    JQAC = JQAC & "                              select: function (event, ui) { " & vbCrLf
    '    JQAC = JQAC & "                                  $(""#" & T1.ClientID & """).val(ui.item.kodik); " & vbCrLf
    '    If Not IsNothing(T2) Then
    '        JQAC = JQAC & "                                  $(""#" & T2.ClientID & """).val(ui.item.Descr); " & vbCrLf
    '    End If
    '    If Not IsNothing(T3) Then
    '        If TypeOf T3 Is Infragistics.WebUI.WebDataInput.WebNumericEdit Then
    '            JQAC = JQAC & "                                  $(""#igtxt" & T3.ClientID & """).val(ui.item.Field1); " & vbCrLf
    '        Else
    '            JQAC = JQAC & "                                  $(""#" & T3.ClientID & """).val(ui.item.Field1); " & vbCrLf
    '        End If
    '    End If
    '    If Not IsNothing(T4) Then
    '        If TypeOf T4 Is Infragistics.WebUI.WebDataInput.WebNumericEdit Then
    '            JQAC = JQAC & "                                  $(""#igtxt" & T4.ClientID & """).val(ui.item.Field2); " & vbCrLf
    '        Else
    '            JQAC = JQAC & "                                  $(""#" & T4.ClientID & """).val(ui.item.Field2); " & vbCrLf
    '        End If
    '    End If
    '    JQAC = JQAC & "                                  return false; " & vbCrLf
    '    JQAC = JQAC & "                              } " & vbCrLf
    '    JQAC = JQAC & "                          }); " & vbCrLf
    '    JQAC = JQAC & "                      }, " & vbCrLf
    '    JQAC = JQAC & "                          error: function (XMLHttpRequest, textStatus, errorThrown) { " & vbCrLf
    '    JQAC = JQAC & "                              alert(textStatus); " & vbCrLf
    '    JQAC = JQAC & "                          } " & vbCrLf
    '    JQAC = JQAC & "                      });             " & vbCrLf
    '    JQAC = JQAC & "                  } " & vbCrLf
    '    JQAC = JQAC & "      </script>  "
    '    Return JQAC
    'End Function
    Public Shared Function JQPopupGrid(TableID As String, DivID As String, LookupID As String, Username As String, FillTextID As String, ButtonClickID As String, ReturnFieldID As String, Optional PostBackCommand As String = "", Optional SQlCret As String = "") As String
        'Page Defs
        '<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        '<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
        '<link href="Styles/themes/base/jquery-ui.css" rel="stylesheet" />
        '<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.css" />
        '<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid-theme.min.css" /> 
        '<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.js"></script>
        Dim JQ As String = ""
        'Diavazoume To ConString Vasi Tou Xristi
        Dim cnxstrt = CnxstrFromUname(Username)

        'Fortonoume To Lookup Sql Gia na ftiaksoume Ta pedia To jquery
        Dim SQS As String = SelQuerS("Select ssql from lookup where sid ='" & LookupID & "'", cnxstrt)
        Dim dase As New DataSet
        'MsgBox(SQS)
        dase = SelQDefn(SQS & " and 1 =2", cnxstrt)


        Dim i As Integer
        Dim JquFieldDefs As String = ""

        For i = 0 To dase.Tables(0).Columns.Count - 1
            JquFieldDefs = JquFieldDefs & "{ name: '" & dase.Tables(0).Columns(i).ColumnName & "', type: 'text'}," & vbCrLf
        Next
        JquFieldDefs = Left(JquFieldDefs, Len(JquFieldDefs) - 3)
        'Afto Periexei Tous Orismous Ton Pedion


        JQ = "<script>" & vbCrLf
        JQ = JQ & " $(function () {" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "         $('#" & TableID & "').jsGrid({" & vbCrLf
        JQ = JQ & "             height: 'auto'," & vbCrLf
        JQ = JQ & "             width: '80%'," & vbCrLf
        'JQ = JQ & "             width: '105%'," & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "             sorting: true," & vbCrLf
        JQ = JQ & "             paging: false," & vbCrLf
        JQ = JQ & "             autoload: true," & vbCrLf
        JQ = JQ & "             filtering: true," & vbCrLf
        JQ = JQ & "             pageSize: 10," & vbCrLf
        JQ = JQ & "             pageButtonCount: 5," & vbCrLf
        JQ = JQ & "             controller: {" & vbCrLf
        JQ = JQ & "                 loadData: function (filter) {" & vbCrLf
        JQ = JQ & "                     return $.ajax({" & vbCrLf
        JQ = JQ & "                         type: 'POST'," & vbCrLf
        JQ = JQ & "                         url: 'JSGridDataFeed.aspx?' + 'unum=" & Username & "&' + 'quid=" & LookupID & "&sqcret=" & WebUtility.UrlEncode(SQlCret) & "'," & vbCrLf
        JQ = JQ & "                         data: filter," & vbCrLf
        JQ = JQ & "                         dataType: 'json'" & vbCrLf
        JQ = JQ & "                         " & vbCrLf
        JQ = JQ & "                     });" & vbCrLf
        JQ = JQ & "                 }" & vbCrLf
        JQ = JQ & "             },    " & vbCrLf
        JQ = JQ & "             rowClick: function (args) {" & vbCrLf
        JQ = JQ & "                 //alert(args.item.Code);" & vbCrLf
        JQ = JQ & "                 $('#" & FillTextID & "').val(args.item." & ReturnFieldID & ");" & vbCrLf
        JQ = JQ & "                 $('#" & DivID & "').dialog('close');" & vbCrLf
        If PostBackCommand <> "" Then
            JQ = JQ & PostBackCommand & vbCrLf
        End If
        JQ = JQ & "             }," & vbCrLf
        JQ = JQ & "             fields: [" & vbCrLf
        JQ = JQ & JquFieldDefs
        'JQ = JQ & "                 { name: 'Code', type: 'text'}," & vbCrLf
        'JQ = JQ & "                 { name: 'Descr', type: 'text' }," & vbCrLf
        'JQ = JQ & "                 { name: 'Field1', type: 'text'}," & vbCrLf
        'JQ = JQ & "                 { name: 'Field2', type: 'text'}" & vbCrLf
        JQ = JQ & "                 " & vbCrLf
        JQ = JQ & "             ]" & vbCrLf
        JQ = JQ & "         });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "         $('.config-panel input[type=checkbox]').on('click', function() {" & vbCrLf
        JQ = JQ & "             var $cb = $(this);" & vbCrLf
        JQ = JQ & "             $('#" & TableID & "').jsGrid('option', $cb.attr('id'), $cb.is(':checked'));" & vbCrLf
        JQ = JQ & "         });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "     });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "     $(function () {" & vbCrLf
        JQ = JQ & "         $('#" & DivID & "').dialog({" & vbCrLf
        JQ = JQ & "             autoOpen: false," & vbCrLf
        JQ = JQ & "             width: '500px'," & vbCrLf
        JQ = JQ & "             height: 500," & vbCrLf
        JQ = JQ & "             maxHeight: 500" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "         });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "         $('#" & ButtonClickID & "').on('click', function () {" & vbCrLf
        JQ = JQ & "             $('#" & DivID & "').dialog('open').css('font-size', '10px');" & vbCrLf
        JQ = JQ & "         });" & vbCrLf
        JQ = JQ & "     });" & vbCrLf
        JQ = JQ & "   </script> "
        Return JQ
    End Function


    Public Shared Function filterSQL(inss As String) As String
        inss = Replace(Replace(Replace(inss, "'", ""), "Drop", "Drop."), "truncate", "trun cate")

        Return inss
    End Function


    Public Shared Sub debugprint(msg As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(HttpRuntime.AppDomainAppPath & "DebugInfo.txt", True)
        file.WriteLine(msg)
        file.WriteLine("-----------------------" & Now & "--------------------")
        file.Close()
    End Sub


    Public Shared Function JQFillGrid(TableID As String, LookupID As String, Username As String, FillTextID As String, ButtonClickID As String, ReturnFieldID As String, Optional PostBackCommand As String = "", Optional SQlCret As String = "") As String
        'Page Defs
        '<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        '<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
        '<link href="Styles/themes/base/jquery-ui.css" rel="stylesheet" />
        '<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.css" />
        '<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid-theme.min.css" /> 
        '<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.js"></script>
        Dim JQ As String = ""
        'Diavazoume To ConString Vasi Tou Xristi
        Dim cnxstrt = CnxstrFromUname(Username)

        'Fortonoume To Lookup Sql Gia na ftiaksoume Ta pedia To jquery
        Dim SQS As String = SelQuerS("Select ssql from lookup where sid ='" & LookupID & "'", cnxstrt)
        Dim dase As New DataSet
        'MsgBox(SQS)
        dase = SelQDefn(SQS & " and 1 =2", cnxstrt)


        Dim i As Integer
        Dim JquFieldDefs As String = ""

        For i = 0 To dase.Tables(0).Columns.Count - 1
            JquFieldDefs = JquFieldDefs & "{ name: '" & dase.Tables(0).Columns(i).ColumnName & "', type: 'text'}," & vbCrLf
        Next
        JquFieldDefs = Left(JquFieldDefs, Len(JquFieldDefs) - 3)
        'Afto Periexei Tous Orismous Ton Pedion


        JQ = "<script>" & vbCrLf
        JQ = JQ & " $(function () {" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "         $('#" & TableID & "').jsGrid({" & vbCrLf
        JQ = JQ & "             height: 'auto'," & vbCrLf
        JQ = JQ & "             width: '80%'," & vbCrLf
        'JQ = JQ & "             width: '105%'," & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "             sorting: true," & vbCrLf
        JQ = JQ & "             paging: true," & vbCrLf
        JQ = JQ & "             autoload: true," & vbCrLf
        JQ = JQ & "             filtering: true," & vbCrLf
        JQ = JQ & "             pageSize: 10," & vbCrLf
        JQ = JQ & "             pageButtonCount: 5," & vbCrLf
        JQ = JQ & "             controller: {" & vbCrLf
        JQ = JQ & "                 loadData: function (filter) {" & vbCrLf
        JQ = JQ & "                     return $.ajax({" & vbCrLf
        JQ = JQ & "                         type: 'POST'," & vbCrLf
        JQ = JQ & "                         url: 'JSGridDataFeed.aspx?' + 'unum=" & Username & "&' + 'quid=" & LookupID & "&sqcret=" & WebUtility.UrlEncode(SQlCret) & "'," & vbCrLf
        JQ = JQ & "                         data: filter," & vbCrLf
        JQ = JQ & "                         dataType: 'json'" & vbCrLf
        JQ = JQ & "                         " & vbCrLf
        JQ = JQ & "                     });" & vbCrLf
        JQ = JQ & "                 }" & vbCrLf
        JQ = JQ & "             },    " & vbCrLf
        JQ = JQ & "             rowClick: function (args) {" & vbCrLf
        JQ = JQ & "                 //alert(args.item.Code);" & vbCrLf
        JQ = JQ & "                 $('#" & FillTextID & "').val(args.item." & ReturnFieldID & ");" & vbCrLf
        'JQ = JQ & "                 $('#" & DivID & "').dialog('close');" & vbCrLf
        If PostBackCommand <> "" Then
            JQ = JQ & PostBackCommand & vbCrLf
        End If
        JQ = JQ & "             }," & vbCrLf
        JQ = JQ & "             fields: [" & vbCrLf
        JQ = JQ & JquFieldDefs
        JQ = JQ & "                 " & vbCrLf
        JQ = JQ & "             ]" & vbCrLf
        JQ = JQ & "         });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "         $('.config-panel input[type=checkbox]').on('click', function() {" & vbCrLf
        JQ = JQ & "             var $cb = $(this);" & vbCrLf
        JQ = JQ & "             $('#" & TableID & "').jsGrid('option', $cb.attr('id'), $cb.is(':checked'));" & vbCrLf
        JQ = JQ & "         });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "     });" & vbCrLf
        JQ = JQ & " " & vbCrLf
        'JQ = JQ & "     $(function () {" & vbCrLf
        'JQ = JQ & "         $('#" & DivID & "').dialog({" & vbCrLf
        'JQ = JQ & "             autoOpen: false," & vbCrLf
        'JQ = JQ & "             width: '500px'," & vbCrLf
        'JQ = JQ & "             height: 500," & vbCrLf
        'JQ = JQ & "             maxHeight: 500" & vbCrLf
        'JQ = JQ & " " & vbCrLf
        'JQ = JQ & "         });" & vbCrLf
        'JQ = JQ & " " & vbCrLf
        'JQ = JQ & "         $('#" & ButtonClickID & "').on('click', function () {" & vbCrLf
        'JQ = JQ & "             $('#" & DivID & "').dialog('open').css('font-size', '10px');" & vbCrLf
        'JQ = JQ & "         });" & vbCrLf
        'JQ = JQ & "     });" & vbCrLf
        JQ = JQ & "   </script> "
        Return JQ
    End Function

    Public Shared Function GetParam(ParamID As String, constr As String, Optional RetifNull As String = "") As String
        'UseMinAgric
        Dim reval As String = ""
        reval = SelQuerS("Select Value from params where paramid = '" & filterSQL(ParamID) & "'", constr)
        If RetifNull <> "" And reval = "" Then
            Return RetifNull
        Else
            Return reval
        End If
    End Function
    Public Shared Function SetParam(ParamID As String, ParamVAl As String, constr As String) As Integer
        'UseMinAgric
        Dim reval As String = ""

        Dim S As String = ""
        S = " IF NOT EXISTS (SELECT * FROM PARAMS where  PARAMID = '" & ParamID & "') " & vbCrLf & _
           " BEGIN " & vbCrLf & _
            " INSERT INTO PARAMS(PARAMID,VALUE )   VALUES ('" & ParamID & "', '" & ParamVAl & "')" & vbCrLf & _
            " End" & vbCrLf & _
            " Else" & vbCrLf & _
            "    BEGIN" & vbCrLf & _
            " update PARAMS set VALUE = '" & ParamVAl & "' where PARAMID = '" & ParamID & "'" & vbCrLf & _
            "    End" & vbCrLf



        Return ExeQuer(S, constr)
    End Function
End Class
