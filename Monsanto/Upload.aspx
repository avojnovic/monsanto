<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Monsanto.Upload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div id="content" style=" height:100%;">

   <br />
       <h1 class="lineas" ></h1>
      <asp:Panel runat="server" ID="panel1" Visible="true" Width="100%" class="background_color_generic" >
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        
        <tr>
           <td style=" width:200px;">                
                <telerik:RadUpload ID="RadUpload1" runat="server"  Width="100%" InitialFileInputsCount="1"  MaxFileInputsCount="1"  ControlObjectsVisibility="None" AllowedFileExtensions=".xls"/>
           </td>
           <td  style=" width:30px;">  
                <asp:imageButton id="UploadButton" Width="32px" Height="32px" ToolTip="Upload" OnClick="UploadButton_Click" ImageUrl="~/Images/Upload_file.png" runat="server"></asp:imageButton>   
           </td>
            <td>  
                <asp:CustomValidator ID="Customvalidator1" runat="server" Display="Dynamic" ClientValidationFunction="validateRadUpload1">
                 <span style="FONT-SIZE: 11px;">Invalid extensions.</span>
                 </asp:CustomValidator>
            </td>
         </tr>
    
         </table>
          <br/>
          <asp:Label id="UploadStatusLabel" runat="server"> </asp:Label>   
          <br/>

          <br/>
          <asp:GridView ID="GridView1" runat="server" GridLines="None"
                    AllowPaging="true" HorizontalAlign="Center" Width="100%" PageSize="15" EnableViewState="true" 
                      CssClass="mGrid"  PagerStyle-CssClass="pgr" ></asp:GridView>
          <br />


       </asp:Panel>
      <h1 class="lineas" ></h1>

    </div>

    <script type="text/javascript">
        function validateRadUpload1(source, arguments) {
            arguments.IsValid = $find('<%= RadUpload1.ClientID %>').validateExtensions();
        }
            </script>
</asp:Content>


