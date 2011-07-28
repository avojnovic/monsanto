<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Monsanto.Default" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     
     <div id="content" style=" height:100%;">

      <asp:Panel runat="server" ID="panel1" Visible="true" >
        
            <br />
            <h1 class="lineas" ></h1>
            <asp:Panel runat="server" ID="paneCentrServ" Visible="true"  Width="100%" class="background_color_generic" >
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr style="height:5px" >
                    <td>

                    </td>
                 </tr>
                <tr>
                <td style=" width:400px ">
                    &nbsp<asp:Label runat="server" ID="lblCentroServ" Text="Centro de Servicio"></asp:Label>
                    <asp:DropDownList ID="ddlCentroDeServicio" runat="server" Width="200px" OnSelectedIndexChanged="ddlCentroDeServicio_modified" AutoPostBack="true"> </asp:DropDownList>
                </td>
                <td>
                
                </td>
                <td align="right"  style=" width:200px;">
                     <asp:ImageButton ID="BtnAceptar" Width="32px" Height="32px" ImageUrl="~/Images/save.png" runat="server" onclick="BtnGuardar_Click" ToolTip="Guardar" />
                     <asp:ImageButton ID="BtnCancelar" Width="32px" Height="32px" ImageUrl="~/Images/return.png" runat="server" onclick="BtnCancelar_Click"  ToolTip="Cancelar" />
             
                </td>
                 <td style=" width:10px;">

                </td>

                </tr>
                </table>
            </asp:Panel>
            <h1 class="lineas" ></h1>
       
             <br />

        <h1 class="lineas" ></h1>
         <asp:Panel runat="server" ID="PanelTabs" Visible="true"  Width="100%" class="background_color_generic"  >
            <br />
           <asp:TabContainer runat="server" Width="950px" >
            <asp:TabPanel runat="server" HeaderText="Exactitud">

                <ContentTemplate>
                   <ctrl:BulkEditGridView ID="GridViewExactitud" runat="server" AutoGenerateColumns="False" GridLines="None"
                    AllowPaging="true" HorizontalAlign="Center" Width="100%" PageSize="15" EnableViewState="true" 
                      CssClass="mGrid"  PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt"  OnPageIndexChanging="gridExactitud_OnPageIndexChanging" 
                      DataKeyNames="Id">
                <PagerSettings PageButtonCount="5" />
                <Columns>
                    
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="Numero" HeaderText="Numero" ReadOnly="True" SortExpression="numero" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="fecha" />
                    

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
            </ctrl:BulkEditGridView>

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

             <br />

          </asp:Panel>
           <h1 class="lineas" ></h1>

    </asp:Panel>
    </div>

</asp:Content>
