Imports System.Data
Imports System.Data.SqlClient
Imports LiveCisPortal.LPVARS
Imports Yahoo.Yui.Compressor

Public Class Reports
    Inherits System.Web.UI.Page
    Dim Params As String = String.Empty
    Dim SqlStrToBeChanged As String = String.Empty
    Dim ReportFileName As String = String.Empty
    Dim ReportId As String = String.Empty
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ReportId = Request.QueryString("ReportID").ToString()
        Dim sqlSelect As String = "Select * from ReportsPortal where ReportID = '" & filterSQL(ReportId) & "'"
        Dim dt As DataTable = New DataTable
        Using con As New SqlConnection(Session("CompanyCon").ToString())
            con.Open()
            dt = SelQDS(sqlSelect, Session("CompanyCon").ToString())
            Params = dt.Rows(0)("params")
            SqlStrToBeChanged = dt.Rows(0)("SQL")
            ReportFileName = dt.Rows(0)("ReportFile")
            GenReportsCreteria(Creter, Params)
        End Using
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GenReportsCreteria(Creter, "Από_Ημ/νία DATE , Εως_Ημ/νία DATE ,Τυπος STRING # Select  Person.Code + char(13) + Person.name  value  from person where PersonType is not null, Υπολοιπα_Πελατών DDL # 0@Ολοι;1@Με Υπολοιπο")

    End Sub
    Private Sub CreateDT(ByRef HTMLTable As Table, ParamStr As String)
        ' HTMLTable.
        Dim Trow As New System.Web.UI.WebControls.TableRow
        Dim Cell0 As New System.Web.UI.WebControls.TableCell
        Dim Cell1 As New System.Web.UI.WebControls.TableCell
        Dim lbl As New System.Web.UI.WebControls.Label
        Dim Itm As New System.Web.UI.WebControls.TextBox
        Dim CrowNum As Integer = HTMLTable.Rows.Count() + 1
        Dim RoLi() As String = Split(ParamStr, " ")
        lbl.ID = "LB" & CrowNum
        lbl.Text = RoLi(0)
        Cell0.Controls.Add(lbl)
        Itm.ID = "FI" & CrowNum
        Itm.ToolTip = "[D]" & RoLi(0)
        Cell1.Controls.Add(Itm)
        Trow.Cells.Add(Cell0)
        Trow.Cells.Add(Cell1)
        HTMLTable.Rows.Add(Trow)
        ClientScript.RegisterStartupScript(Me.GetType(), "DePi" & Itm.ID, JSDateTPICK(Itm))
    End Sub


    Private Sub CreateTX(ByRef HTMLTable As Table, ParamStr As String)
        Dim Trow As New System.Web.UI.WebControls.TableRow
        Dim Cell0 As New System.Web.UI.WebControls.TableCell
        Dim Cell1 As New System.Web.UI.WebControls.TableCell
        Dim lbl As New System.Web.UI.WebControls.Label
        Dim Itm As New System.Web.UI.WebControls.TextBox
        Dim CrowNum As Integer = HTMLTable.Rows.Count() + 1
        Dim RoLi() As String = Split(ParamStr, " ")
        lbl.ID = "LB" & CrowNum
        lbl.Text = RoLi(0)
        Cell0.Controls.Add(lbl)

        Itm.ID = "FI" & CrowNum
        Itm.ToolTip = "[S]" & RoLi(0)
        Dim HashSplit() As String = Split(ParamStr, "#")
        If HashSplit.Length > 1 Then
            Itm.Attributes.Add("placeholder", "Πληκτρολογίστε Για Αναζήτηση")
        End If

        Dim DefaultValueTb() As String = Split(ParamStr, "|")
        If DefaultValueTb.Length > 1 Then
            Itm.Text = DefaultValueTb(1)
        End If

        Cell1.Controls.Add(Itm)
        Trow.Cells.Add(Cell0)
        Trow.Cells.Add(Cell1)
        HTMLTable.Rows.Add(Trow)
        'Edo Vazoume AutoCople an Exei #

        If HashSplit.Length > 1 Then
            Dim sqlToAutoCom As String = HashSplit(1)
            Dim _person As Person = DirectCast(Session("LoggedInPerson"), Person)
            sqlToAutoCom = sqlToAutoCom.Replace("[@UsID]", _person.Code)
            Dim jquac As String = AutoCom(Itm, sqlToAutoCom, Session("CompanyCon"))
            ClientScript.RegisterStartupScript(Me.GetType(), "AuCo" & Itm.ID, jquac)
        End If
        '' HTMLTable.
        'Dim Trow As New System.Web.UI.WebControls.TableRow
        'Dim Cell0 As New System.Web.UI.WebControls.TableCell
        'Dim Cell1 As New System.Web.UI.WebControls.TableCell
        'Dim lbl As New System.Web.UI.WebControls.Label
        'Dim Itm As New System.Web.UI.WebControls.TextBox
        'Dim CrowNum As Integer = HTMLTable.Rows.Count() + 1
        'Dim RoLi() As String = Split(ParamStr, " ")
        'lbl.ID = "LB" & CrowNum
        'lbl.Text = RoLi(0)
        'Cell0.Controls.Add(lbl)
        'Itm.ID = "FI" & CrowNum
        'Itm.ToolTip = "[S]" & RoLi(0)
        'Cell1.Controls.Add(Itm)
        'Trow.Cells.Add(Cell0)
        'Trow.Cells.Add(Cell1)
        'HTMLTable.Rows.Add(Trow)
        ''Edo Vazoume AutoCople an Exei #
        'Dim HashSplit() As String = Split(ParamStr, "#")
        'If HashSplit.Length > 1 Then
        '    Dim jquac As String = AutoCom(Itm, HashSplit(1), Session("CompanyCon"))
        '    ClientScript.RegisterStartupScript(Me.GetType(), "AuCo" & Itm.ID, jquac)
        'End If
    End Sub
    Private Sub CreateDL(ByRef HTMLTable As Table, ParamStr As String)
        ' HTMLTable.
        Dim Trow As New System.Web.UI.WebControls.TableRow
        Dim Cell0 As New System.Web.UI.WebControls.TableCell
        Dim Cell1 As New System.Web.UI.WebControls.TableCell
        Dim lbl As New System.Web.UI.WebControls.Label
        Dim Itm As New System.Web.UI.WebControls.DropDownList
        Dim CrowNum As Integer = HTMLTable.Rows.Count() + 1
        Dim RoLi() As String = Split(ParamStr, " ")
        lbl.ID = "LB" & CrowNum
        lbl.Text = RoLi(0)
        Cell0.Controls.Add(lbl)

        Itm.ID = "FI" & CrowNum
        Itm.ToolTip = "[L]" & RoLi(0)
        Dim HsplitV As String = Split(ParamStr, "#")(1)
        Dim csplitV() As String = Split(Trim(HsplitV), ";")
        Dim I As Integer = 0
        For I = 0 To csplitV.Length - 1
            Dim DDIt As New System.Web.UI.WebControls.ListItem
            DDIt.Value = Split(csplitV(I), "@")(0)
            DDIt.Text = Split(csplitV(I), "@")(1)
            Itm.Items.Add(DDIt)
        Next

        Cell1.Controls.Add(Itm)

        Trow.Cells.Add(Cell0)
        Trow.Cells.Add(Cell1)
        HTMLTable.Rows.Add(Trow)
    End Sub
    Private Function AutoCom(Tbox As TextBox, SelSQL As String, Cnsstr As String) As String
        Dim RC As Long, Fieldname As String = ""
        Dim DataString As String = GetLookupACSJ(SelSQL, Cnsstr, RC, Fieldname)
        Fieldname = "value"
        Dim JQAUC As String = ""
        ' JQAUC = "      <script>" & vbCrLf
        JQAUC = JQAUC & "           $(function () {" & vbCrLf
        JQAUC = JQAUC & " var AutoComData" & Tbox.ID.ToString & " = " & DataString & ";"
        JQAUC = JQAUC & " " & vbCrLf
        JQAUC = JQAUC & "               $('#" & Tbox.ClientID & "').autocomplete({" & vbCrLf
        JQAUC = JQAUC & "                   minLength: 0," & vbCrLf
        JQAUC = JQAUC & "                   source: AutoComData" & Tbox.ID.ToString & "," & vbCrLf
        JQAUC = JQAUC & "                   select: function (event, ui) {" & vbCrLf
        JQAUC = JQAUC & "                       $('#" & Tbox.ClientID & "').val(ui.item." & Fieldname & ".split(String.fromCharCode(13))[0]);" & vbCrLf
        JQAUC = JQAUC & "                       $('#" & Tbox.ClientID & "-id').val(ui.item." & Fieldname & ");" & vbCrLf
        JQAUC = JQAUC & "                       return false;" & vbCrLf
        JQAUC = JQAUC & "                   }" & vbCrLf
        JQAUC = JQAUC & "               })" & vbCrLf
        JQAUC = JQAUC & "               .autocomplete('instance')._renderItem = function (ul, item) {" & vbCrLf
        JQAUC = JQAUC & "                   var tb = item." & Fieldname & ".split(String.fromCharCode(13));" & vbCrLf
        JQAUC = JQAUC & "                   return $('<li>')" & vbCrLf
        JQAUC = JQAUC & "                     .append('<div>' + item." & Fieldname & ".split(String.fromCharCode(13))[0] + '<br>' + (tb.length >1  ? tb[1] : '')  + '</div>')" & vbCrLf
        JQAUC = JQAUC & "                     .appendTo(ul);" & vbCrLf
        JQAUC = JQAUC & "               };" & vbCrLf
        JQAUC = JQAUC & "           });" & vbCrLf
        If RC < 30 Then
            JQAUC = JQAUC & "$('#" & Tbox.ClientID & "').focus(function(event) {" & vbCrLf
            JQAUC = JQAUC & "        $(this).autocomplete( 'search' , '' );" & vbCrLf
            JQAUC = JQAUC & "      });" & vbCrLf
        End If
        ' JQAUC = JQAUC & "   </script> "
        'Dim JavaScriptCompressor As New Yahoo.Yui.Compressor.JavaScriptCompressor
        'JQAUC = JavaScriptCompressor.Compress(JQAUC)
        Return "<script>  " & JQAUC & "   </script> "
    End Function
    'Kodikas gia AytoComplete
    'Private Function AutoCom(Tbox As TextBox, SelSQL As String, Cnsstr As String) As String
    '    Dim RC As Long
    '    Dim DataString As String = GetLookupACSJ(SelSQL, Cnsstr, RC)

    '    Dim JQAUC As String = ""
    '    ' JQAUC = "      <script>" & vbCrLf
    '    JQAUC = JQAUC & "           $(function () {" & vbCrLf
    '    JQAUC = JQAUC & " var AutoComData" & Tbox.ID.ToString & " = " & DataString & ";"
    '    JQAUC = JQAUC & " " & vbCrLf
    '    JQAUC = JQAUC & "               $('#" & Tbox.ClientID & "').autocomplete({" & vbCrLf
    '    JQAUC = JQAUC & "                   minLength: 0," & vbCrLf
    '    JQAUC = JQAUC & "                   source: AutoComData" & Tbox.ID.ToString & "," & vbCrLf
    '    JQAUC = JQAUC & "                   select: function (event, ui) {" & vbCrLf
    '    JQAUC = JQAUC & "                       $('#" & Tbox.ClientID & "').val(ui.item.value.split(String.fromCharCode(13))[0]);" & vbCrLf
    '    JQAUC = JQAUC & "                       $('#" & Tbox.ClientID & "-id').val(ui.item.value);" & vbCrLf
    '    JQAUC = JQAUC & "                       return false;" & vbCrLf
    '    JQAUC = JQAUC & "                   }" & vbCrLf
    '    JQAUC = JQAUC & "               })" & vbCrLf
    '    JQAUC = JQAUC & "               .autocomplete('instance')._renderItem = function (ul, item) {" & vbCrLf
    '    JQAUC = JQAUC & "                   var tb = item.value.split(String.fromCharCode(13));" & vbCrLf
    '    JQAUC = JQAUC & "                   return $('<li>')" & vbCrLf
    '    JQAUC = JQAUC & "                     .append('<div>' + item.value.split(String.fromCharCode(13))[0] + '<br>' + (tb.length >1  ? tb[1] : '')  + '</div>')" & vbCrLf
    '    JQAUC = JQAUC & "                     .appendTo(ul);" & vbCrLf
    '    JQAUC = JQAUC & "               };" & vbCrLf
    '    JQAUC = JQAUC & "           });" & vbCrLf
    '    If RC < 30 Then
    '        JQAUC = JQAUC & "$('#" & Tbox.ClientID & "').focus(function(event) {" & vbCrLf
    '        JQAUC = JQAUC & "        $(this).autocomplete( 'search' , '' );" & vbCrLf
    '        JQAUC = JQAUC & "      });" & vbCrLf
    '    End If
    '    ' JQAUC = JQAUC & "   </script> "
    '    Dim JavaScriptCompressor As New Yahoo.Yui.Compressor.JavaScriptCompressor
    '    JQAUC = JavaScriptCompressor.Compress(JQAUC)
    '    Return "<script>  " & JQAUC & "   </script> "
    'End Function
    Function DatatblToJSON(ByVal dt As DataTable) As String
        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue

        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object) = Nothing
        Dim row2 As Dictionary(Of Integer, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            row2 = New Dictionary(Of Integer, Object)()
            For Each dc As DataColumn In dt.Columns
                row.Add(dc.ColumnName.Trim(), dr(dc))
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function
    Public Function GetLookupACSJ(SQLSEL As String, cnsstr As String, Optional ByRef RowsCount As Long = 0, Optional ByRef FieldName As String = "") As String
        Dim cnxstr = cnsstr
        Dim SQS As String = SQLSEL
        Dim cn As New SqlConnection
        Dim Dsa As New DataSet("Selqds")
        cn.ConnectionString = cnxstr
        cn.Open()
        'SQS = Replace(SQS, "[CRETER]", CreterReplace)

        Dim Datad As New SqlDataAdapter(SQS, cn)
        Datad.FillSchema(Dsa, SchemaType.Source, "Selqds")
        Datad.Fill(Dsa, "Selqds")
        Dim tblSelqds As DataTable

        tblSelqds = Dsa.Tables("Selqds")
        Dim DttSel As New DataTable
        'filterwhere = "Code like 'ΠΕ%'"

        'If Trim(filterwhere) = "" Then
        DttSel = tblSelqds
        'Else
        '    DttSel = tblSelqds.Select(filterwhere).AsEnumerable.CopyToDataTable
        'End If
        FieldName = DttSel.Columns(0).Caption
        Dim Retjson As String = DatatblToJSON(DttSel)

        Retjson = Replace(Retjson, """" & FieldName & """:", "")
        Retjson = Replace(Retjson, "{", "")
        Retjson = Replace(Retjson, "}", "")
        Retjson = Replace(Retjson, "null,", "")
        RowsCount = DttSel.Rows.Count
        Return Retjson



    End Function
    'Public Function GetLookupACSJ(SQLSEL As String, cnsstr As String, Optional ByRef RowsCount As Long = 0) As String
    '    Dim cnxstr = cnsstr
    '    Dim SQS As String = SQLSEL
    '    Dim cn As New SqlConnection
    '    Dim Dsa As New DataSet("Selqds")
    '    cn.ConnectionString = cnxstr
    '    cn.Open()

    '    'SQS = Replace(SQS, "[CRETER]", CreterReplace)
    '    Dim Datad As New SqlDataAdapter(SQS, cn)
    '    Datad.FillSchema(Dsa, SchemaType.Source, "Selqds")
    '    Datad.Fill(Dsa, "Selqds")

    '    Dim tblSelqds As DataTable

    '    tblSelqds = Dsa.Tables("Selqds")
    '    Dim DttSel As New DataTable
    '    'filterwhere = "Code like 'ΠΕ%'"

    '    'If Trim(filterwhere) = "" Then
    '    DttSel = tblSelqds
    '    'Else
    '    '    DttSel = tblSelqds.Select(filterwhere).AsEnumerable.CopyToDataTable
    '    'End If

    '    Dim Retjson As String = DatatblToJSON(DttSel)

    '    RowsCount = DttSel.Rows.Count
    '    Return Retjson


    'End Function



    Private Sub GenReportsCreteria(ByRef CreterHTMLTBL As Table, prm As String)
        'Dim prm = "Από_Ημ/νία DATE , Εως_Ημ/νία DATE ,Τυπος STRING # Select distinct Person.PersonType value  from person where PersonType is not null, Υπολοιπα_Πελατών DDL # 0@Ολοι;1@Με Υπολοιπο"
        prm = Replace(prm, "value", "value")
        prm = Replace(prm, "  ", " ")
        prm = Replace(prm, "  ", " ")
        prm = Replace(prm, ", ", ",")
        'Σπαμε Σε , και looparoume
        Dim RoAr() = Split(prm, ",")
        Dim i As Integer
        For i = 0 To RoAr.Length - 1
            'Spame ana keno kai kai pernoume to 2o stoixeio kai analoga kaloume Creates
            Dim RoLi() As String = Split(RoAr(i), " ")
            Select Case RoLi(1).ToUpper()
                Case "DATE".ToUpper()
                    CreateDT(CreterHTMLTBL, RoAr(i))
                Case "STRING".ToUpper()
                    CreateTX(CreterHTMLTBL, RoAr(i))
                Case "DDL".ToUpper()
                    CreateDL(CreterHTMLTBL, RoAr(i))
            End Select

        Next
    End Sub

    Private Function JSDateTPICK(Tbox As TextBox) As String
        Dim JSDTPick As String = ""
        JSDTPick = " <script>" & vbCrLf
        JSDTPick = JSDTPick & " $( function() {"
        JSDTPick = JSDTPick & " $( '#" & Tbox.ClientID & "' ).datepicker({"
        JSDTPick = JSDTPick & " changeMonth: true,"
        JSDTPick = JSDTPick & " changeYear: true,"
        JSDTPick = JSDTPick & " dateFormat: 'dd/mm/yy',"
        JSDTPick = JSDTPick & " });"
        JSDTPick = JSDTPick & " } );"
        JSDTPick = JSDTPick & " </script> "
        Return JSDTPick
    End Function


    Private Function GetPageRepPArams(HtmlTable As Table, ByVal SqlCret As String) As String
        For i = 0 To 20
            Dim Cont As Control = HtmlTable.FindControl("FI" & i)
            If Cont IsNot Nothing Then
                If TypeOf Cont Is TextBox Then
                    Dim textb As TextBox = TryCast(Cont, TextBox)
                    Dim Tp As String, VaRe As String, Periex As String
                    VaRe = Mid(textb.ToolTip, 4)
                    Tp = Left(textb.ToolTip, 3)
                    Periex = textb.Text
                    If Tp = "[D]" Then
                        If Periex = "" Then Periex = "Null" Else Periex = "'" & fixsDAte(textb.Text) & "'"
                        SqlCret = Replace(SqlCret, "[" & VaRe & "]", Periex)
                    ElseIf Tp = "[S]" Then
                        Periex = "'" & filterSQL(Periex) & "'"
                        SqlCret = Replace(SqlCret, "[" & VaRe & "]", Periex)
                    End If
                End If
                If TypeOf Cont Is DropDownList Then
                    Dim DDL As DropDownList = TryCast(Cont, DropDownList)
                    SqlCret = Replace(SqlCret, "[" & Mid(DDL.ToolTip, 4) & "]", "'" & DDL.Text & "'")
                End If
            End If
        Next
        Dim client As Person = Session("LoggedInPerson")
        SqlCret = SqlCret.Replace("[@ClientID]", client.Code)
        SqlCret = SqlCret.Replace("[@ClientAfm]", client.AFM)
        SqlCret = SqlCret.Replace("[@ClientName]", client.Name)
        Return SqlCret
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim SqlCret As String = "[Από_Ημ/νία] DATE , [Εως_Ημ/νία] DATE ,[Τυπος] STRING # Select distinct Person.PersonType code  from person, [Υπολοιπα_Πελατών] DDL # 0@Ολοι;1@Με Υπολοιπο"
        'Dim anotherSelect = "Απο_Ημνια DATE ,Εώς_Ημνια DATE, Συν/νος String # Select Person.Name as value from person, Τυπος STRING # Select distinct Person.PersonType as code from person where Person.PersonType is not null"
        'MsgBox(GetPageRepPArams(Creter, SqlStrToBeChanged))
        SqlStrToBeChanged = GetPageRepPArams(Creter, SqlStrToBeChanged)
        GenerateReport()
    End Sub
    Public Sub GenerateReport()
        Dim rname As Object = Guid.NewGuid()
        Dim SqlCommand As String = "INSERT INTO ReportsCache (UUID,SqlQ,Status) VALUES (@param1,@param2,0)"
        Try
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Dim cm As New SqlCommand(SqlStrToBeChanged, con)
                cm.CommandText = SqlCommand
                cm.Parameters.Add("@param1", SqlDbType.VarChar).Value = rname.ToString()
                cm.Parameters.Add("@param2", SqlDbType.VarChar).Value = HttpUtility.HtmlDecode(SqlStrToBeChanged)
                cm.ExecuteNonQuery()
                'PROCESS START
                Dim process1 As New System.Diagnostics.Process
                process1.StartInfo.WorkingDirectory = Request.MapPath("~/")
                process1.StartInfo.FileName = Request.MapPath("ReportPortal.exe")
                'Session("CompanyCon") is to be Session("uname")
                process1.StartInfo.Arguments = " " & rname.ToString() & "," & Session("DbName").ToString() & "," & ReportFileName & "," & Combo1.Text
                process1.Start()
                process1.WaitForExit()

                'Check File existance
                Dim fileExists As Object = System.IO.File.Exists(Server.MapPath("~") & "\html\" & rname.ToString() & "." & Combo1.Text)
                If fileExists Then
                    Dim ReportUrl = "html/" & rname.ToString() & "." & Combo1.Text
                    Dim popupScript = "window.open('" & ReportUrl & "');"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, Guid.NewGuid.ToString(), popupScript, True)
                End If

            End Using
        Catch ex As Exception
        End Try
    End Sub
End Class