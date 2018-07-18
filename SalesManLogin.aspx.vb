Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient

Public Class SalesManLogin
    Inherits System.Web.UI.Page
    Dim SqlSelect As String = String.Empty
    Dim DBREF As String

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Session("pType") = "1"
        DBREF = Request.QueryString("d").ToString()
        Try
            If String.IsNullOrEmpty(Request.QueryString("d").ToString()) Then
            Else
                Session("SelectedConnection") = DBREF
                SqlSelect = "select DBNAME from ClientDBS where PortalUrl ='" & filterSQL(DBREF) & "'"
            End If
        Catch ex As Exception
            SqlSelect = "select DBNAME from ClientDBS where PortalUrl ='demo'"
        End Try

        Dim MainConStr As String = LPVARS.LoadMainConnection()
        Try
            Dim CliDBNam As String = SelQuerS(SqlSelect, LPVARS.LoadMainConnection())
            Session("CompanyCon") = MainConStr.Replace("ComVoiceMaster", CliDBNam)
            Session("DbName") = CliDBNam
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim SqlCheck As String = "SELECT CompanyName FROM Company"
            Using con As New SqlConnection(Session("CompanyCon"))
                con.Open()
                Using cmd As SqlCommand = New SqlCommand(SqlCheck, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If (Not String.IsNullOrEmpty(reader("CompanyName").ToString())) Then
                                lblCompany.Text = reader("CompanyName").ToString()
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub UserName_TextChanged(sender As Object, e As EventArgs) Handles UserName.TextChanged

    End Sub
    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        Dim _person As Person = New Person
        Try
            Dim SqlCheck As String = "SELECT aa,Code,Name,WebPass FROM SalesMan where WebPass = '{0}' and Code = '{1}'"
            SqlCheck = String.Format(SqlCheck, filterSQL(PassWord.Text), filterSQL(UserName.Text))
            Dim ds As DataTable = New DataTable
            ds = SelQDS(SqlCheck, Session("CompanyCon").ToString())
            _person.AA = ds.Rows(0)("aa").ToString()
            _person.Code = ds.Rows(0)("Code").ToString()
            _person.Name = ds.Rows(0)("Name").ToString()
            _person.WebPPass = ds.Rows(0)("WebPass").ToString()
            _person.Email = "Δεν υπάρχει Email"
            Session("LoggedInPerson") = _person
            Session("OrderDocType") = "ΠΑΡ"
            Server.Transfer("Default.aspx")
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "<script>$('#bootalert').removeAttr('style');$('#bootalert').fadeIn(5000);$('#bootalert').fadeOut(5000);</script>", False)
        End Try
    End Sub
    Protected Sub Register_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class