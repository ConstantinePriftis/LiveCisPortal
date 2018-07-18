<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginView.aspx.vb" Inherits="LiveCisPortal.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery.validate.min.js"></script>
    <%--<script type="text/javascript">                
        $(document).ready(function () {  
            $("#form1").validate({  
                rules: {  
                    //This section we need to place our custom rule   
                    //for the control.  
                    <%=UserName.UniqueID%> :{  
                        required:true  
                    },
                     <%=PassWord.UniqueID%>:{  
                         required:true  
                     },
                },  
                messages: {  
                    //This section we need to place our custom   
                    //validation message for each control.  
                    <%=UserName.UniqueID%>:{  
                        required: "Name is required."  
                    },
                     <%=PassWord.UniqueID%>:{  
                         required: "Name is required."  
                     },
                },  
            });  
        });         
    </script>--%>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 268435408px;
        }

        #modal {
            display: none;
            z-index: 15;
        }

        #Loginbtn {
            width: 50%;
        }

        #Button1 {
            width: 50%;
        }


        .showHideModal {
            position: absolute;
            top: 0px;
            left: 0px;
            background: rgba(0, 0, 0, .4);
            display: none;
            z-index: 10;
            width: 100vw;
            height: 100vh;
            cursor: pointer;
        }
    </style>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div align="center" class="container-fluid">
            <legend runat="server" id="Legend" style="background-image: url(Images/1PFHyYy.jpg); width: 100%; color: white" class="container-fluid text-center">Είσοδος</legend>
            <div style="margin-left:2%">
                <h3 style="margin-left: 3%">
                    <asp:Label runat="server" ID="lblCompany"></asp:Label>
                </h3>
                <div style="float: left">
                    <asp:Image runat="server" ID="LiveLogo" ImageUrl="~/Images/LiveCIS.png" />
                </div>
                <table class="table-hover" style="margin-right: 8%">
                    <tr>
                        <td></td>
                    </tr>
                    <tbody align="center">
                        <tr>
                            <td style="padding: 5px">
                                <asp:Label ID="Label1" runat="server">ΑΦΜ: </asp:Label>
                                <asp:TextBox CssClass="form-control text-primary" ID="UserName" OnTextChanged="UserName_TextChanged" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ForeColor="#ff0000" Text="Το πεδίο ΑΦΜ είναι υποχρεωτικό!"></asp:RequiredFieldValidator>

                            </td>
                            <td style="padding: 5px">
                                <asp:Label ID="Label2" runat="server">Κωδικός: </asp:Label>
                                <asp:TextBox CssClass="form-control text-primary" ID="PassWord"  TextMode="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PassWord" ForeColor="#ff0000" Text="Το πεδίο Κωδικός είναι υποχρεωτικό!"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <asp:Button class="form-control btn-primary" ID="Loginbtn" OnClick="Login_Click" runat="server" Text="Login" />
                                <br />
                                <asp:Label runat="server" ID="lblError" Text="" Visible="false" ForeColor="#ff0000"></asp:Label>
                                <input type="button" style="display: none" class="form-control btn-primary" id="Button1" value="Register" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br />
            <br />
            <div id="modal" class="col-xs-4 col-xs-offset-4  modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Register Form</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Enter UserName"></asp:Label>
                    <asp:TextBox runat="server" class="form-control" ID="txtUserReg"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Enter PassWord"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="txtPassReg"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn-primary form-control" ID="btnSave" Text="Save" OnClick="Register_Click" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <div class="showHideModal" style=""></div>
</body>
<script>
    $(document).ready(function () {
        $("#Button1").click(function () {
            $("#modal").show(300);
            $(".showHideModal").show();
        });

        $(".showHideModal").click(function () {
            $("#modal").hide(300);
            $(".showHideModal").hide();
        });
    });
</script>
<script>
    function loadDoc() {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                document.getElementById("demo").innerHTML = this.responsText
            }
        };
        xhttp.open("GET", "ajax_info", true);
        xhttp.send();
    }
</script>
</html>
