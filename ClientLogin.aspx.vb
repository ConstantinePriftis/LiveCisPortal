Imports LiveCisPortal.LPVARS
Imports System.Data
Imports System.Data.SqlClient

Public Class ClientLogin
    Inherits System.Web.UI.Page
    Dim SqlSelect As String = String.Empty

    Dim _dbName As String = String.Empty
    Dim _clientName As String = String.Empty
    Dim _dbPassWord As String = String.Empty
    Dim _clientPassWord As String = String.Empty

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Dim CompanyName As String = String.Empty
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'If Not IsPostBack Then
        '    bootalert.Visible = False
        'Else
        '    bootalert.Visible = True
        'End If

        Session("pType") = "0"


        Try
            If String.IsNullOrEmpty(Request.QueryString("d").ToString()) Then
                SqlSelect = "select DBNAME from ClientDBS where PortalUrl ='demo'"
            Else
                Dim EstablishedConnection As String = Request.QueryString("d").ToString()
                Session("SelectedConnection") = EstablishedConnection.ToString()
                SqlSelect = "select DBNAME from ClientDBS where PortalUrl ='demo'"
                SqlSelect = Replace(SqlSelect, "demo", EstablishedConnection)
            End If
        Catch ex As Exception
            SqlSelect = "select DBNAME from ClientDBS where PortalUrl ='demo'"
        End Try

        Dim something As String = LPVARS.LoadMainConnection()
        Try
            Using con As New SqlConnection(LPVARS.LoadMainConnection())
                con.Open()
                Using cmd As SqlCommand = New SqlCommand(SqlSelect, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If (Not String.IsNullOrEmpty(reader("DBNAME").ToString())) Then
                                Dim x = reader("DbName").ToString()
                                Session("DbName") = x
                                Session("CompanyCon") = something.Replace("ComVoiceMaster", x.ToString())
                            End If
                        End While
                    End Using
                End Using
            End Using
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

    Protected Sub Login_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        Dim SqlCheck As String = "SELECT aa,PersonType ,Code, Name,AFM,WebPass,Cmpt,Eaddress,Ecity,Email FROM Person where WebPass = '{0}' and AFM = '{1}'"
        If ((Not String.IsNullOrEmpty(UserName.Text.ToString())) Or (Not String.IsNullOrEmpty(PassWord.Text.ToString()))) Then
            SqlCheck = String.Format(SqlCheck, filterSQL(PassWord.Text), filterSQL(UserName.Text))
            Dim ds As DataTable = New DataTable
            Try
                Using con As New SqlConnection(Session("CompanyCon").ToString())
                    con.Open()
                    Using cmd As SqlCommand = New SqlCommand(SqlCheck, con)
                        ds = SelQDS(SqlCheck, Session("CompanyCon").ToString())
                        Dim human As Person = New Person
                        human.AA = ds.Rows(0)("aa").ToString()
                        human.PersonType = ds.Rows(0)("PersonType")
                        human.Code = ds.Rows(0)("Code")
                        human.Name = ds.Rows(0)("Name")
                        human.AFM = ds.Rows(0)("AFM")
                        human.WebPPass = ds.Rows(0)("WebPass")
                        If Not String.IsNullOrEmpty(ds.Rows(0)("Cmpt").ToString()) Then
                            human.Cmpt = ds.Rows(0)("Cmpt")
                        Else
                            human.Cmpt = "Δεν υπάρχει ονομασία!"
                        End If
                        human.Eaddress = ds.Rows(0)("Eaddress")
                        human.Ecity = ds.Rows(0)("Ecity")
                        human.PersonType = ds.Rows(0)("PersonType")
                        If String.IsNullOrEmpty(ds.Rows(0)("email").ToString()) Then
                            human.Email = "Δεν υπάρχει Email"
                        Else
                            human.Email = ds.Rows(0)("email").ToString()
                        End If
                        Session("LoggedInPerson") = human
                        Session("OrderDocType") = "ΠΑΡ"
                        Response.Redirect("Default")
                    End Using
                End Using
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "<script>$('#bootalert').removeAttr('style');$('#bootalert').fadeIn(5000);$('#bootalert').fadeOut(5000);</script>", False)
            End Try
        End If
    End Sub

    Public Function ValidateUserLogin() As Boolean
        Dim isValid As Boolean = False
        If Not (String.IsNullOrEmpty(_dbName) And String.IsNullOrEmpty(_dbPassWord)) Then
            If (_dbName <> UserName.Text.ToString() Or _dbPassWord <> PassWord.Text.ToString()) Then
                isValid = False
            Else
                isValid = True
            End If
        End If
        Return isValid
    End Function

    Protected Sub Register_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
    Protected Sub UserName_TextChanged(sender As Object, e As EventArgs) Handles UserName.TextChanged

    End Sub
    Public Function ValidateUser() As Boolean
        If IsPostBack Then
            If _dbName <> UserName.Text.ToString() Or _dbPassWord <> PassWord.Text.ToString Then
                Return False
            End If
        End If
    End Function
End Class