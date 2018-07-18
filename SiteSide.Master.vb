Imports LiveCisPortal
Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient

Public Class SiteSide
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim counter As Int32 = 0
        Dim SideNavCont As LiveCisPortal.SideNavClass = New LiveCisPortal.SideNavClass
        Dim dt As DataTable
        If (Session("pType").ToString() = "0") Then
            dt = SelQDS("Select Type,Code,Descr,Url,Header from PortalMenu where PType='0' order by Ord", Session("CompanyCon"))
        Else
            dt = SelQDS("Select Type,Code,Descr,Url,Header from PortalMenu where PType='1' order by Ord", Session("CompanyCon"))
        End If

        Dim header As String = ""
        For Each d As DataRow In dt.Rows
            SideNavCont.Type = d("Type").ToString()
            SideNavCont.Code = d("Code").ToString()
            SideNavCont.Descr = d("Descr").ToString()
            SideNavCont.Url = d("Url").ToString().Replace(".aspx", String.Empty)
            If (header <> d("Header").ToString()) Then
                header = d("Header").ToString()
                Dim TopDivLi As HtmlGenericControl = New HtmlGenericControl("li")
                Dim TopDivDiv As HtmlGenericControl = New HtmlGenericControl("div")
                TopDivDiv.Attributes.Add("class", "divider")
                TopDivLi.Controls.Add(TopDivDiv)
                slideOut.Controls.Add(TopDivLi)
                Dim headLi As HtmlGenericControl = New HtmlGenericControl("li")
                Dim headAnchor As HtmlGenericControl = New HtmlGenericControl("a")
                headAnchor.Attributes.Add("class", "subheader")
                headAnchor.InnerText = d("Header").ToString()
                headLi.Controls.Add(headAnchor)
                slideOut.Controls.Add(headLi)
                Dim BotDivLi As HtmlGenericControl = New HtmlGenericControl("li")
                Dim BotDivDiv As HtmlGenericControl = New HtmlGenericControl("div")
                BotDivDiv.Attributes.Add("class", "divider")
                BotDivLi.Controls.Add(BotDivDiv)
                slideOut.Controls.Add(BotDivLi)
            End If
            Dim li As HtmlGenericControl = New HtmlGenericControl("li")
            Dim anchor As HtmlGenericControl = New HtmlGenericControl(SideNavCont.Type)
            anchor.Attributes.Add("href", SideNavCont.Url)
            anchor.InnerText = SideNavCont.Descr
            li.Controls.Add(anchor)
            slideOut.Controls.Add(li)
        Next

        'Populating NavBar With Client Information
        Dim _client As Person = DirectCast(Session("LoggedInPerson"), Person)
        spanClientName.InnerText = _client.Name.ToString()
        spanClientEmail.InnerText = _client.Email.ToString()

    End Sub
    Public Sub LogoutRedirect()
        If (Not IsPostBack) Then
            Response.Redirect("LogoutHandler.aspx")
        End If
    End Sub
    Public Function ReturnCompany() As String
        Dim CompanyName As String = String.Empty
        Dim sqlNavBar = "Select * from Company"
        Using con As New SqlConnection(Session("CompanyCon"))
            con.Open()
            Dim cm As New SqlCommand(sqlNavBar, con)
            Dim _dataReader As SqlDataReader = cm.ExecuteReader()
            _dataReader.Read()
            If _dataReader("Companyname") IsNot Nothing Then
                CompanyName = _dataReader("Companyname").ToString()
            End If
        End Using
        Return CompanyName
    End Function
End Class