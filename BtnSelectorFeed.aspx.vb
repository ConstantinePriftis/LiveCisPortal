Imports System.Data
Imports System.Data.SqlClient
Imports LiveCisPortal.LPVARS
Imports System.Web

Public Class BtnSelectorFeed
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        On Error GoTo erx
        Dim FLTR As String = ""
        Dim Username As String = ""
        Dim RequestQuery As String = ""
        Dim SqlCret As String = ""

        'Username = Request.QueryString("unum").ToString
        ' RequestQuery = Request.QueryString("quid").ToString
        'SqlCret = Request.QueryString("sqcret").ToString
        'For Each Gname As String In Request.QueryString
        '    ' MsgBox(Gname & Request.QueryString(Gname).ToString)
        'Next
        'MsgBox(Username & " " & RequestQuery)

        'Diabazoume Ta POSTDATA Gia Na Ftiajoume Filtro
        For Each name As String In Request.Form
            If Request.Form(name).ToString <> "" Then
                FLTR = FLTR & name & " Like '" & Request.Form(name).ToString & "%' And "
            End If
        Next

        'An To Filtro Keno Den Stelnoume Kati An OXi Ftiaxnoume To String
        If Len(FLTR) > 5 Then
            FLTR = Left(FLTR, Len(FLTR) - 4)
        Else
            FLTR = ""
        End If

        'MsgBox(SqlCret)
        'Response.Clear()
        'Response.ContentType = "application/x-www-form-urlencoded"
        Response.Write(GetLookupACSJ(Username, RequestQuery, FLTR, SqlCret))
        'Response.End()
        Exit Sub
erx:
        Response.Write("Error " & Err.Number & " " & Err.Description & " ")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        ' Response.ContentType = "text/plain"
        Response.ContentType = "application/json"
    End Sub

    'Diabazei To query Apo Ton Pinaka Lookup kai Dimiourgei Sxima kai DataTable
    Public Function GetLookupACSJ(uname As String, LookUPID As String, Optional filterwhere As String = "", Optional CreterReplace As String = "") As String
        Dim EncryptedSqS As String = Request.QueryString("unum").ToString()
        Dim cnxstr = Session("CompanyCon")
        ' Dim SQS As String = SelQuerS("Select ssql from lookup where sid ='" & LookUPID & "'", cnxstr)
        Dim UrlDecodedString As String = LPVARS.AES_DecryptHex(EncryptedSqS, "as*&^%dff!@#$%34dsc12")
        Dim SQS As String = Server.UrlDecode(UrlDecodedString)  '" SELECT Code ,description Περιγραφή,Type Τυπος,Team Ομαδα  FROM DocType   where 1=1 "
        'Session.Remove(SessionName)
        Dim cn As New SqlConnection
        Dim Dsa As New DataSet("Selqds")
        cn.ConnectionString = cnxstr
        cn.Open()

        SQS = Replace(SQS, "[CRETER]", CreterReplace)
        Dim Datad As New SqlDataAdapter(SQS, cn)
        Datad.FillSchema(Dsa, SchemaType.Source, "Selqds")
        Datad.Fill(Dsa, "Selqds")

        Dim tblSelqds As DataTable

        tblSelqds = Dsa.Tables("Selqds")
        Dim DttSel As New DataTable
        'filterwhere = "Code like 'ΠΕ%'"

        If Trim(filterwhere) = "" Then
            DttSel = tblSelqds
        Else
            DttSel = tblSelqds.Select(filterwhere).AsEnumerable.CopyToDataTable
        End If

        Dim Retjson As String = DatatblToJSON(DttSel)


        Return Retjson


    End Function

    'Metatropi DataTable Se Json String!!
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


End Class