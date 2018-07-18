<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteSide.Master" CodeBehind="Reports.aspx.vb" Inherits="LiveCisPortal.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <style>
        .DivCreterClass {
            width: 50%;
            margin-left: 20%;
            margin-top: 10%;
        }

        .CreterClass {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            font: normal 16px arial, sans-serif;
            font-weight: 600;
        }

            .CreterClass tr {
                background-color: #b3ccff;
                border: solid 1px #306969;
                color: #336B6B;
                padding: 10px;
                text-align: left;
                text-shadow: 1px 1px 1px #fff;
            }

            .CreterClass td {
                border: solid 1px #306969;
                color: #333;
                padding: 10px;
                text-shadow: 1px 1px 1px #fff;
            }

            .CreterClass th {
                color: white;
                background-image: url(Images/1PFHyYy.jpg);
                font-weight: 400;
                font-size: large;
                height: 50px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="CretDiv" class="DivCreterClass">
        <asp:Table ID="Creter" CssClass="CreterClass" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2">
                    <div style="float:left;margin-left:20%">Κριτήριο</div>
                       <div style="float:right;margin-right:25%">Περιεχόμενο</div>                    
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <asp:Button ID="Button1" class="waves-effect waves-light btn-large" runat="server" Text="Εκτέλεση Εκτυπωσης" />
        <asp:DropDownList ID="Combo1" runat="server" Width="50%" Height="30px" Visible="True">
            <asp:ListItem meta:resourcekey="ListItemResource1" Text="html"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource2" Text="xls"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource3" Text="pdf"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource4" Text="doc"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource5" Text="txt"></asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource6" Text="rpt"></asp:ListItem>
        </asp:DropDownList>
    </div>

</asp:Content>
