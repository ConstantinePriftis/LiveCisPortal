<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/SiteSide.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="LiveCisPortal._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        h5 {
            animation: move 6s;
            -webkit-animation: move 6s;
        }

        @keyframes move {
            from {
                margin-left: 100%;
                width: 300%;
            }

            to {
                margin-left: 0%;
                width: 100%;
            }
        }

        @-webkit-keyframes move {
            from {
                margin-left: 100%;
                width: 300%;
            }

            to {
                margin-left: 0%;
                width: 100%;
            }
        }

        .rcorners2 {
            border-radius: 25px;
            padding: 20px;
            width: 100%;
            height: 200px;
        }

        .rcorners3 {
            border-radius: 25px;
            padding: 2px;
            width: 50%;
            height: 80%;
        }

        .FixLabel {
            margin-left: 27%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    </div>
    <div style="margin-left: 30%; margin-top: 10%" class="rcorners3">
        <legend style="font-size: larger; width: 70%" class="rcorners3 pulse">
            <asp:Label runat="server" CssClass="FixLabel" ID="lblStoixeia"> <b style="align-self:center">Στοιχεία Συναλλασσόμενου </b></asp:Label>
            <fieldset style="width: 100%; color: white; background-image: url(Images/1PFHyYy.jpg)" class="rcorners2 cyan pulse z-depth-5 " runat="server" id="fsInfo" title="Στοιχεία Πελάτη">
                <table runat="server" id="tblBasicInfo">
                    <tr>
                        <td>Όνομα:
                    <asp:Label runat="server" ID="lblNAme"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Υπηρεσίες:
                    <asp:Label runat="server" ID="lblCmtp"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Διεύθυνση:
                    <asp:Label runat="server" ID="lblEaddress"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Πόλη:
                    <asp:Label runat="server" ID="lblEcity"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Είδος:
                    <asp:Label runat="server" ID="lblPersonType"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </legend>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.button-collapse').sideNav('show');
        });
    </script>

</asp:Content>
