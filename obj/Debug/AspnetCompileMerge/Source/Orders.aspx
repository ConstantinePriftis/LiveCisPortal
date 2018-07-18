<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Orders.aspx.vb" MasterPageFile="~/SiteSide.Master" Inherits="LiveCisPortal.Orders" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFormLayout" TagPrefix="dx1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <style>
        input[type=text] {
            width: 100%;
            transition: ease-in-out, width .35s ease-in-out;
            padding: 4px;
        }

        table thead tr {
            color: white;
            background-image: url(Images/1PFHyYy.jpg);
        }

        table tr {
            border: solid 1px #306969;
            text-align: left;
            text-shadow: 1px 1px 1px #fff;
        }


        table td {
            padding: 6px;
            text-shadow: 1px 1px 1px #fff;
        }

        table label {
            width: 50%;
        }

        #MainGrid {
            overflow: scroll;
        }

        .rcorners3 {
            border-radius: 30px;
            /*border: 2px solid #123b7c;*/
            padding: 5px;
            /*width: 50%;
            height: 80%;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 80%; margin-left: 10%; margin-top: 5%">
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%" Theme="Glass">
            <Items>
                <dx:LayoutGroup Caption="Πεδία Παραγγελίας" ColCount="2" Width="70%" GroupBoxDecoration="Box" HorizontalAlign="Center" VerticalAlign="Middle">
                    <Items>
                        <dx:LayoutItem FieldName="aa" Visible="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Τύπος">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtDocType" ReadOnly="true" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Κωδικός Πελάτη">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtPersonCode" ReadOnly="true" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Περιγρ" ColSpan="2" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtDocDescr" runat="server" Width="100%">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Ον/επών" ColSpan="2" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtPersname" runat="server" Width="100%">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Κωδικός">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtCode" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Ημ/νία" CaptionCellStyle-Paddings-PaddingLeft="1px">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxDateEdit runat="server" ID="DateDD"></dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                            <CaptionCellStyle>
                                <Paddings PaddingLeft="1px"></Paddings>
                            </CaptionCellStyle>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="ΦΠΑ">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtFpa" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ColSpan="2" Caption="Σχόλια">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxMemo ID="AspMemo" runat="server" Height="71px" Width="100%">
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
            <SettingsItems HorizontalAlign="Center" VerticalAlign="Middle" />
            <SettingsItemCaptions HorizontalAlign="Center" Location="Left" VerticalAlign="Middle" />
            <SettingsItemHelpTexts HorizontalAlign="Center" Position="Left" VerticalAlign="Middle" />
        </dx:ASPxFormLayout>

        <asp:HiddenField runat="server" ID="hdDocAA" />
    </div>
    <div style="width: 80%; margin-left: 10%">
        <asp:Panel ID="Panel1" runat="server" BorderColor="#8bc3c9" BorderStyle="None" Height="116px" Style="width: 100%;">
            <table runat="server" id="tblPAR">
                <thead>
                    <tr>
                        <td>
                            <asp:Label ID="lblEidos" runat="server" Text="Είδος"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPosothta" runat="server" Text="Ποσότητα"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblKataxorish" runat="server" Text="Καταχώρηση"></asp:Label>
                        </td>
                    </tr>
                </thead>
                <tr>
                    <td>
                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server"
                            DataTextField="Code" DataValueField="Code"
                            TabIndex="1" AppendDataBoundItems="true" EnableCallbackMode="True" CallbackPageSize="20"
                            IncrementalFilteringDelay="20" IncrementalFilteringMode="Contains"
                            TextField="Code" TextFormatString="{0}   {1}" ValueField="Code"
                            AutoResizeWithContainer="True" NullText="Πληκτρολογήστε Για Αναζήτηση"
                            Width="100%" DataSourceID="SqlDataSourceline" ValueType="System.String">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Code" Width="150px" />
                                <dx:ListBoxColumn FieldName="Descr" Width="400px" />
                                <dx:ListBoxColumn FieldName="Χονδρική" Width="100px" />
                                <dx:ListBoxColumn FieldName="Λιανική" Width="100px" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Height="40px" Width="100%">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSubmit" Height="40px" Text="Εισ.Γραμμής" OnClientClick="if(ValidateOrder()){__doPostBack('ctl00$MainContent$btnSubmit','');}else{return false;}" UseSubmitBehavior="false" OnClick="btnAddRow_Click" class="waves-effect waves-light btn-large" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <dx:ASPxGridView ID="MainGrid" OnRowCommand="MainGrid_RowCommand" runat="server" Theme="Glass" Width="100%" Visible="false">
                <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                <SettingsBehavior SortMode="Value" />
                <SettingsPager PageSize="10"></SettingsPager>
                <Settings ShowFilterRow="true" ShowFilterRowMenu="false" />
            </dx:ASPxGridView>
            <br />
            <asp:Button runat="server" ID="btnFinalSubmit" UseSubmitBehavior="false" CssClass="waves-effect waves-light btn-large" Text="Καταχώρηση παραγγελίας" />
        </asp:Panel>
        <br />
        <div id="modal1" class="modal rcorners">
            <div class="modal-content">
                <h4>Σφάλμα!</h4>
                <br />
                <br />
                <p>Πρίν την αποθήκευση πρέπει να επιλέξετε είδος και να εισάγετε ποσότητα!</p>
            </div>
            <div class="modal-footer">
                <a href="#!" class="modal-action modal-close ">Αποδοχή</a>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSourceline" runat="server"
        SelectCommand="SELECT [Code], [Descr] ,CONVERT(varchar, CAST(MatSums.Υπολοιπο AS decimal(9,2)), 1) Υπολοιπο, CONVERT(varchar, CAST(WSPPrice AS decimal(9,2)), 1) Χονδρική, CONVERT(varchar, CAST(RSPPrice AS decimal(9,2)), 1) Λιανική FROM [Material] left join MatSums on MatSums.Είδος = Material.Code WHERE [ItemType] = 'Είδος' and isnull(isValid,1)=1  ORDER BY [Code]"
        OldValuesParameterFormatString="original_{0}"></asp:SqlDataSource>

    <script type="text/javascript">
        function ValidateOrder() {
            var combo = document.getElementById('MainContent_ASPxComboBox1_I').value;
            var txt = document.getElementById('MainContent_ASPxTextBox3_I').value;
            if (!(combo == "" || combo == null) && !(txt == "" || txt == null)) {
                return true;
            }
            else {
                $('.modal').modal();
                $('#modal1').modal('open');
                $('.trigger-modal').modal();
                return false;
            }
        }
    </script>
</asp:Content>

