<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Procesamiento.aspx.cs" Inherits="Monsanto.Procesamiento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />

 
 
     <div id="content" style=" height:100%;">
       <h1 class="lineas" ></h1>
      <asp:Panel runat="server" ID="panel1" Visible="true" Width="100%" class="background_color_generic" >
             <br />
        <center>
            <table>
                <tr>
                    <td>
                        
                    <telerik:RadButton ID="btnBgrImg4" runat="server" Width="241px" Height="33px" Font-Size="Large" Text="PROCESAR"
                        ForeColor="#8E8E8E" HoveredCssClass="goButtonClassHov" OnClick="procesar_click" >
                        <Image ImageUrl="images/cb_square_empty.png" IsBackgroundImage="true" />
                    </telerik:RadButton>

                    </td>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text="Ultimo proceso: "></asp:Label> 
                        <asp:Label ID="lblUltProc" runat="server" Text=""></asp:Label> 
                    </td>        
                </tr>
                <tr style="height:20px;">
                    <td>

                    </td>    
                </tr>
                 <tr>
                    <td>
                        
                    <telerik:RadButton ID="RadButton1" runat="server" Width="241px" Height="33px"  Font-Size="Large" Text="ENVIAR EMAILS"
                        ForeColor="#8E8E8E" HoveredCssClass="goButtonClassHov" OnClick="email_click">
                        <Image ImageUrl="images/cb_square_empty.png" IsBackgroundImage="true" />
                    </telerik:RadButton>

                    </td>
                    <td align="left">
                     <asp:Label ID="Label2" runat="server" Text="Ultimo envio emails: "></asp:Label> 
                     <asp:Label ID="lblUltEnvEmails" runat="server" Text=""></asp:Label> 
                    </td>        
                </tr>
                        
            </table>
        
        </center>


       <br />
      </asp:Panel>
      <h1 class="lineas" ></h1>

    </div>

</asp:Content>
