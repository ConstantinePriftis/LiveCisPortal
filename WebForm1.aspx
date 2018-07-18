<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="LiveCisPortal.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="Div2" runat="server" style="width: 350px; height: 220px; display: none; background-color: #edf5ff;">
                <table style="margin-left: 13px; margin-top: 20px">
                    <tr>
                        <td colspan="2" style="height: 50px; text-align: center">
                            <span style="font-size: 12pt; font-weight: 700">
                                <asp:Label ID="lblTtl" runat="server" Text="Τίτλος Προτύπου Παραστατικού" meta:resourcekey="lblTtlResource1"></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Τίτλος" Width="140px" meta:resourcekey="Label1Resource2"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="150px" Font-Names="Courier New" meta:resourcekey="txtTitleResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Enabled="False" ControlToValidate="txtTitle" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 50px">

                            <asp:Label ID="Label4" runat="server" Font-Names="Courier New" Font-Size="Small" Height="100%" Width="100%" meta:resourcekey="Label4Resource1"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="btnCancel1" runat="server" Text="Ακύρωση" Width="100px" CausesValidation="False" meta:resourcekey="btnCancel1Resource1" />
                            <asp:Button ID="btnFinal1" runat="server" ToolTip="Έναρξη Μετασχηματισμού" Text="Έναρξη" Width="100px" meta:resourcekey="btnFinal1Resource1" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Button ID="btnSomething" runat="server" Text="Press me" />

            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Div1" BackgroundCssClass="backgroundColor" DropShadow="True" TargetControlID="Button4" CancelControlID="btnCancel" DynamicServicePath="" Enabled="True">
            </asp:ModalPopupExtender>
        </div>
    </form>
</body>

<script type="text/javascript">

</script>
</html>
