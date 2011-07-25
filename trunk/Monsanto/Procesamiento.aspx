<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Procesamiento.aspx.cs" Inherits="Monsanto.Procesamiento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
     <div id="content" style=" height:100%;">
      <asp:Panel runat="server" ID="panel1" Visible="true" >
        
        <br />
        <br />
        <br />
        <br />
        <center>
            <table>
                <tr>
                    <td>
                        
                    <telerik:RadButton ID="btnBgrImg4" runat="server" Width="203px" Height="46px" Font-Size="Large" Text="PROCESAR"
                        ForeColor="Black" HoveredCssClass="goButtonClassHov" OnClick="procesar_click" >
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
                        
                    <telerik:RadButton ID="RadButton1" runat="server" Width="203px" Height="46px" Font-Size="Large" Text="ENVIAR EMAILS"
                        ForeColor="Black" HoveredCssClass="goButtonClassHov" OnClick="email_click">
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



      </asp:Panel>
    </div>

</asp:Content>
