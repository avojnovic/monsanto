<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Monsanto.Default" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     
     <div id="content" style=" height:100%;">
      <asp:Panel runat="server" ID="panel1" Visible="true" >
        
            <br />
            <asp:Panel runat="server" ID="paneCentrServ" Visible="true"  Width="100%" style="background-color:#F2F7D4">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td style=" width:400px ">
                    <asp:Label runat="server" ID="lblCentroServ" Text="Centro de Servicio"></asp:Label>
                    <asp:DropDownList ID="ddlCentroDeServicio" runat="server" Width="200px" OnSelectedIndexChanged="ddlCentroDeServicio_modified" AutoPostBack="true"> </asp:DropDownList>
                </td>
                <td>
                
                </td>
                <td align="right" style=" width:100px;">
                     <asp:ImageButton ID="BtnAceptar" Width="32px" Height="32px" ImageUrl="~/Images/save.png" runat="server" onclick="BtnGuardar_Click" ToolTip="Guardar" />
                     <asp:ImageButton ID="BtnCancelar" Width="32px" Height="32px" ImageUrl="~/Images/return.png" runat="server" onclick="BtnCancelar_Click"  ToolTip="Cancelar" />
             
                </td>
                </tr>
                </table>
            </asp:Panel>
            <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="paneCentrServ"
                    Radius="8" Color="#F2F7D4" Corners="All" Enabled="true">
            </asp:RoundedCornersExtender>
            
       
             <br />

        <h1 style="border-bottom: 4px solid #BD9A72; font-size: 0pt;"></h1>
         <asp:Panel runat="server" ID="PanelTabs" Visible="true"  Width="100%" style="background-color:#F2F7D4;"  >
    
           <asp:TabContainer runat="server" Width="950px" >
            <asp:TabPanel runat="server" HeaderText="Exactitud">

                <ContentTemplate>
                   <asp:GridView ID="GridViewExactitud" runat="server" AutoGenerateColumns="False" GridLines="None"
                    AllowPaging="true" HorizontalAlign="Center" Width="100%" PageSize="20"
                      CssClass="mGrid"  PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt"  OnPageIndexChanging="gridExactitud_OnPageIndexChanging"  >
                <PagerSettings PageButtonCount="5" />
                <Columns>
                    <asp:BoundField DataField="Numero" HeaderText="Numero" ReadOnly="True" SortExpression="numero" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="fecha" />
                    

                     <asp:TemplateField HeaderText="Exceptuado" HeaderStyle-Width="20px"  >
                        <ItemTemplate>
                            <center>
                                <asp:CheckBox ID="CheckBoxExcep" runat="server" Checked='<%# Convert.ToBoolean(Eval("Exceptuado")) %>'  />
                            </center>
                        </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Observación" ControlStyle-Width="100%">
                        <ItemTemplate>
                            <asp:Textbox ID="TxtObservacion" runat="server"  Text='<%# Eval("Observacion") %>'  />
                        </ItemTemplate>
                     </asp:TemplateField>

                     <%--<asp:TemplateField  ItemStyle-Width="25px">
                         <ItemTemplate>  
                            <a href="Edit_Proyecto.aspx?id=<%# Eval("id") %>" >
                                <img alt="Abrir" src="../images/File-Open-icon.png" border="0"  width="16px" height="16px"/>
                              </a>
                          </ItemTemplate>
                     </asp:TemplateField>--%>

                </Columns>
            <SelectedRowStyle BackColor="Silver" />
            </asp:GridView>

                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="Claridad">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="Autonomia">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
             <asp:TabPanel runat="server" HeaderText="Remitos">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
             <asp:TabPanel runat="server" HeaderText="Contratos">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
             <asp:TabPanel runat="server" HeaderText="Utilizacion MATE">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
             <asp:TabPanel runat="server" HeaderText="Cheques">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="Inventario">
                <ContentTemplate>
                    ...
                </ContentTemplate>
            </asp:TabPanel>
            </asp:TabContainer>

          </asp:Panel>
            <asp:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" TargetControlID="PanelTabs"
                    Radius="8" Color="#F2F7D4" Corners="All" Enabled="true">
            </asp:RoundedCornersExtender>

    </asp:Panel>
    </div>

</asp:Content>
