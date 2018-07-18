<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteSide.Master" CodeBehind="Lists.aspx.vb" Inherits="LiveCisPortal.Lists" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        .HeightClass {
            height: 10px;
        }

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <header>
       <%-- <h5 runat="server" id="HTitle">
            <asp:Label ID="lblTitle" runat="server" Text="Label" Font-Size="Larger"></asp:Label>
        </h5>--%>
    </header>
    <div id="dxExporter">
        <br />
        <dx:ASPxGridViewExporter runat="server" ID="DxExporter" GridViewID="MainGrid"></dx:ASPxGridViewExporter>
        <!-- Element Showed -->
        <table>
            <tr>
                <td style="width: 35px"><b>Κατέβασμα λίστας σε μορφή Excell : </b>&nbsp
                    <asp:ImageButton ID="imgExport" runat="server" ImageUrl="~/Images/Excel.jpg" />
                </td>
            </tr>
        </table>
    </div>
    <div runat="server" style="width: 95%" id="GridDiv">
        <dx:ASPxGridView Settings-UseFixedTableLayout="true" Theme="Glass" Border-BorderStyle="None" ID="MainGrid" runat="server" Width="100%" EnableCallBacks="False">
            <%--<Border BorderStyle="None"></Border>--%>
            <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
            <ClientSideEvents CustomButtonClick="function(s, e) 
{
	s.PerformCallback(e.visibleIndex);
}"
                RowClick="function(s, e) 
{
	s.PerformCallback(e.visibleIndex);
}" />
            <SettingsBehavior SortMode="Value" />
            <SettingsPager PageSize="20"></SettingsPager>
            <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
            <Styles>
                <FilterRow CssClass="HeightClass">
                </FilterRow>
                <FilterCell CssClass="HeightClass">
                </FilterCell>
                <InlineEditRow CssClass="HeightClass">
                </InlineEditRow>
            </Styles>
            <StylesEditors>
                <TextBox CssClass="HeightClass">
                </TextBox>
            </StylesEditors>

            <Border BorderStyle="None"></Border>
        </dx:ASPxGridView>
    </div>
    <script type="text/javascript">
        function RedirectPage() {
            window.location.href = 'Orders.aspx?_pagePurpose=create&aa=something';
        }
    </script>
</asp:Content>
