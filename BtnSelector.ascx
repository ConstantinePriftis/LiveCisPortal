<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BtnSelector.ascx.vb" Inherits="LiveCisPortal.BtnSelector" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%--<script type="text/javascript">
    $(function () {
        var url = 'LPBtnEditFeed.aspx?tbnam=<%=Me.lookupTable%>';
        var iframe = $('<div><iframe id="iframetestdialog" src=' + url + ' style="border: none;overflow-x:hidden; overflow-y:hidden;display: block;" height="450px" width="100%" marginheight="0" marginwidth="0" frameBorder="0" ></iframe>');
        $('#<%=pop.ClientID%>').dialog({
            width: 650, title: '<%= Me.DialogTitle%>', modal: true, buttons: {
                "OK": function () {
                    $(this).dialog("close");
                    if ('<%=Me.PostAtOK%>' == 'True') {
                        __doPostBack('<%=Me.PostObject%>', '')
                    }
                }
            }, autoOpen: false
        }); $('#<%=divBtn.ClientID%>').on("click", function () {
            //$('#<%=pop.ClientID%>').append(iframe).dialog('open')
            $('#<%=pop.ClientID%>').dialog('open')
        })
    });
</script>--%>
<%--<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.css" />
<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid-theme.min.css" />
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jsgrid/1.5.2/jsgrid.min.js"></script>--%>

<style type="text/css">
    .hoverMouse.hover {
        cursor: pointer;
    }

    .tableFix {
        width: 100%;
        /*margin-left: 5%;*/
        /*background-color: #CFD3FF;*/
    }
</style>

<p runat="server" style="width: 22px; height: 22px; margin-top: 0px; margin-bottom: 1px;">
    <div id="divBtn" class="hoverMouse" style="cursor: pointer" runat="server">
        <%= ClassValue.ToString() %>
    </div>
</p>
<div id="pop" style="display: none" runat="server">
    <div>
        <asp:Table CssClass="tableFix" ID="PopTBL" runat="server"></asp:Table>
    </div>
</div>
