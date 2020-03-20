<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="Presentacion.Mensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">
    

       
     
    <div class="form-box" id="Men-Box">
        <div class="header bg-success bg-green-gradient" >
            <asp:Label ID="lblHeaderMensjes" runat="server" CssClass="text-lg-center" Text="MENSAJES"></asp:Label>
        </div>
        <div class="body bg-gray">
            <div class="form-group">
                            <label>DESTINATARIO</label>
                        </div>
            <div class="form-group">
                <asp:TextBox ID="tbdir" runat="server" CssClass="form-control" placeholder="ejemplo@uabc.edu.mx"></asp:TextBox>
                <asp:regularexpressionvalidator ID="revtbdir" runat="server" ControlToValidate="tbdir" ErrorMessage="*" 
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                CssClass="auto-style1"
               Display="Dynamic" ForeColor="Red">*Correo invalido</asp:regularexpressionvalidator>
            </div>
             <div class="form-group">
                            <label>DESTINATARIO OPCIONAL</label>
                        </div>
            <div class="form-group">
                <asp:TextBox ID="tbdir2" runat="server" CssClass="form-control"  placeholder="ejemplo@uabc.edu.mx"></asp:TextBox>
                <asp:regularexpressionvalidator ID="revtbdir2" runat="server" ControlToValidate="tbdir2" ErrorMessage="*" 
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                CssClass="auto-style1"
               Display="Dynamic" ForeColor="Red">*Correo invalido</asp:regularexpressionvalidator>
            </div>
             <div class="form-group">
                            <label>ASUNTO:</label>
                        </div>
            <div class="form-group">
                <asp:TextBox ID="tbAsunto" runat="server" CssClass="form-control"  placeholder="Asunto"></asp:TextBox>

            </div>
              <div class="form-group">
                            <label>MENSAJE:</label>
                        </div>
            <div class="form-group">
                <asp:TextBox ID="tbMensaje" runat="server" CssClass=" form-control"  placeholder="Mensaje...." Height="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtbMensaje" runat="server" ErrorMessage="*Introduzca Mensaje" ForeColor="Red" ControlToValidate="tbMensaje"></asp:RequiredFieldValidator>
            </div>
            
          
            
        
        <div class="footer bg-gray">
            <asp:Button ID="btnMensaje" runat="server" Text="Enviar Mensaje" CssClass="btn btn-block  btn-success" OnClick="btnMensaje_Click"  />
       
            </div>
                  <h4 style="text-align: center"><asp:Label ID="lblMsg" runat="server" Text="Aviso" CssClass=" text-success"  Visible="false"></asp:Label></h4>
        </div>
        </div>
          




</asp:Content>
