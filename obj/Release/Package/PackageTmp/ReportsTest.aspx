<%@ Page Language="vb" MasterPageFile="~/SiteSide.Master" AutoEventWireup="false" CodeBehind="ReportsTest.aspx.vb" Inherits="LiveCisPortal.ReportsTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style></style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="true" CombineScripts="false" EnablePageMethods="True">
    </asp:ToolkitScriptManager>
    <div>
        <div>
            <asp:GridView ID="Gv2" runat="server">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
