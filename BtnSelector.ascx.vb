Imports LiveCisPortal.LPVARS
Imports System.Net
Imports System.Web

Public Class BtnSelector
    Inherits System.Web.UI.UserControl
    Dim SelSql As String = String.Empty


    Public Property lookupTable() As String
        Get
            Return _lookupTable
        End Get
        Set(ByVal value As String)
            _lookupTable = value
        End Set
    End Property
    Private _lookupTable As String

    Private _cssClass As String
    Public Property ButtonCssClass() As String
        Get
            Return _cssClass
        End Get
        Set(ByVal value As String)
            _cssClass = value
        End Set
    End Property

    Public Property TooltipText() As String
        Get
            Return _TooltipText
        End Get
        Set(ByVal value As String)
            _TooltipText = value

        End Set
    End Property
    Private _TooltipText As String

    Public Property DialogTitle() As String
        Get
            Return _DialogTitle
        End Get
        Set(ByVal value As String)
            _DialogTitle = value
        End Set
    End Property
    Private _DialogTitle As String
    Public Property PostAtOK() As Boolean
        Get
            Return _PostAtOK
        End Get
        Set(ByVal value As Boolean)

            _PostAtOK = value
        End Set
    End Property
    Private _PostAtOK As Boolean
    Public Property PostObject() As String
        Get
            Return _PostObject
        End Get
        Set(ByVal value As String)
            _PostObject = value
        End Set
    End Property
    Private _PostObject As String
    Private _classVlaue As String
    Public Property ClassValue() As String
        Get
            Return _classVlaue
        End Get
        Set(ByVal value As String)
            _classVlaue = value
        End Set
    End Property
    Private _text As String
    Public Property ButtonText() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Private _targetId As String
    Public Property TargetTextId() As String
        Get
            Return _targetId
        End Get
        Set(ByVal value As String)
            _targetId = value
        End Set
    End Property

    Private _sql As String
    Public Property Sql() As String
        Get
            Return _sql
        End Get
        Set(ByVal value As String)
            _sql = value
        End Set
    End Property

    Private _doPostBack As String
    Public Property DoPostBack() As String
        Get
            Return _doPostBack
        End Get
        Set(ByVal value As String)
            _doPostBack = value
        End Set
    End Property

    Private _creter As String
    Public Property CRETER() As String
        Get
            Return _creter
        End Get
        Set(ByVal value As String)
            _creter = value
        End Set
    End Property

    Private _backColor As String
    Public Property BackColor() As String
        Get
            Return _backColor
        End Get
        Set(ByVal value As String)
            _backColor = value
        End Set
    End Property
    Private _connStr As String
    Public Property ConnStr() As String
        Get
            Return _connStr
        End Get
        Set(ByVal value As String)
            _connStr = value
        End Set
    End Property






    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        'Dim BtnVerifyId As String = Guid.NewGuid().ToString()
        'Session(BtnVerifyId) = Me.Sql

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UrlEncodedSql As String = Server.UrlEncode(Me.Sql).ToString()
        SelSql = LPVARS.AES_EncryptHex(UrlEncodedSql, "as*&^%dff!@#$%34dsc12")

        'SelSql = LPVARS.AES_EncryptHex(Me.Sql, "Btn@!Sql69255645")

        Dim JQScrip As String = JQPopupGridL(Me.PopTBL.ClientID, pop.ClientID, "DocTypeXP", SelSql.ToString(), TargetTextId, divBtn.ClientID, "Code", DoPostBack.ToString()) ' "__doPostBack('" & Button8.ClientID & "','')", divBtn.ClientID ,) ''"__doPostBack('" & Button8.ClientID & "','');
        Page.RegisterStartupScript(Me.ClientID.ToString & "_ACPG", JQScrip)
        If Not (String.IsNullOrEmpty(ButtonCssClass)) Then
            divBtn.Attributes.Add("OnClientClick", "return false;")
            divBtn.Attributes.Add("class", ButtonCssClass)
            divBtn.Attributes.Add("BackColor", BackColor)
        End If




    End Sub
    Private Function JQPopupGridL(TableID As String, DivID As String, LookupID As String, Username As String, FillTextID As String, ButtonClickID As String, ReturnFieldID As String, Optional PostBackCommand As String = "", Optional SQlCret As String = "") As String
        'Page Defs
        '<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        '<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
        '<link href="Styles/themes/base/jquery-ui.css" rel="stylesheet" />
        '<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.css" />
        '<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid-theme.min.css" /> 
        '<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.js"></script>
        Dim JQ As String = ""
        'Diavazoume To ConString Vasi Tou Xristi
        Dim cnxstrt = ConnStr

        'Fortonoume To Lookup Sql Gia na ftiaksoume Ta pedia To jquery
        Dim SQS As String = Me.Sql '" SELECT Code ,description Περιγραφή,Type Τυπος,Team Ομαδα  FROM DocType   where 1=1 "
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
        'JQ = JQ & "             height: 'auto'," & vbCrLf
        JQ = JQ & "             width: '100%'," & vbCrLf
        'JQ = JQ & "             width: '105%'," & vbCrLf
        JQ = JQ & " " & vbCrLf
        JQ = JQ & "             sorting: true," & vbCrLf
        JQ = JQ & "             paging: true," & vbCrLf
        JQ = JQ & "             autoload: true," & vbCrLf
        JQ = JQ & "             filtering: true," & vbCrLf
        'To Be Removed
        JQ = JQ & "             gridview: true," & vbCrLf
        JQ = JQ & "             altRows: true," & vbCrLf
        JQ = JQ & "             forceFit: true," & vbCrLf
        JQ = JQ & "             Scrolling: false," & vbCrLf
        JQ = JQ & "             scrollOffset: 15," & vbCrLf
        'To Be Removed
        JQ = JQ & "             pageSize: 10," & vbCrLf
        JQ = JQ & "             pageButtonCount: 5," & vbCrLf
        JQ = JQ & "             controller: {" & vbCrLf
        JQ = JQ & "                 loadData: function (filter) {" & vbCrLf
        JQ = JQ & "                     return $.ajax({" & vbCrLf
        JQ = JQ & "                         type: 'POST'," & vbCrLf
        JQ = JQ & "                         url: 'BtnSelectorFeed.aspx?' + 'unum=" & Username & "&' + 'quid=" & LookupID & "&sqcret=" & WebUtility.UrlEncode(SQlCret) & "'," & vbCrLf
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


End Class