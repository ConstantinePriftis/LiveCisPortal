<%@ Page Title="About" Language="VB" MasterPageFile="~/SiteSide.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="LiveCisPortal.About" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/BtnSelector.ascx" TagPrefix="LP" TagName="BtnSelector" %>
<asp:Content runat="server" ID="HeaderContent" ContentPlaceHolderID="HeaderContent">
    <style>
        .HoverClass {
            cursor: pointer;
        }
    </style>

</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <%--<br />
    <div id="HoverClass">
        <LP:BtnSelector runat="server" TargetTextId="icon_telephone" Sql="SELECT Code ,description Περιγραφή,Type Τυπος,Team Ομαδα  FROM DocType   where 1=1" ButtonCssClass="Large material-icons" ClassValue="account_box" ID="Dosomething" lookupTable="PerCategory" TooltipText="Έπεξεργασία πίνακα Κατηγορίας Συναλ/μένου" DialogTitle="Some Title" PostAtOK="True" />
    </div>
    <div id="Div1">
        <LP:BtnSelector runat="server" TargetTextId="icon_telephone" Sql=" SELECT Code,Name from Client where 1=1 " ButtonCssClass="Large material-icons" ClassValue="account_box" ID="BtnSelector1" lookupTable="PerCategory" TooltipText="Έπεξεργασία πίνακα Κατηγορίας Συναλ/μένου" DialogTitle="Some Title" PostAtOK="True" />

    </div>
    <br />
    <br />--%>
    <div style="width: 30%; float: left">
        <div style="width: 10%; float: left" class="input-field col s6">
            <LP:BtnSelector TargetTextId="RandomText" runat="server" Sql=" SELECT Code,Name from Client where 1=1 " ButtonCssClass="Large material-icons prefix" ClassValue="account_box" ID="BtnSelector2" lookupTable="PerCategory" TooltipText="Έπεξεργασία πίνακα Κατηγορίας Συναλ/μένου" DialogTitle="Some Title" PostAtOK="True" />
        </div>
        <div style="width: 85%; float: right; margin-right: 5%; margin-top: 8%" class="input-field col s6">
            <%--<i style="float: right; margin-left: 90%; margin-bottom: 10%" class="material-icons prefix">people</i>--%>
            <input id="RandomText" type="tel" class="validate">
        </div>
    </div>

    <%--    <asp:TextBox runat="server" ID="TargetFeed"></asp:TextBox>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
</asp:Content>
