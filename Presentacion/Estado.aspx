<%@ Page Title="" Language="C#" MasterPageFile="~/InicioMasterPage.Master" AutoEventWireup="true" CodeBehind="Estado.aspx.cs" Inherits="Presentacion.Estado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">

    
     
    <div class="form-box" id="Men-Box">
        <div class="header bg-success bg-green-gradient" >
            <asp:Label ID="lblHeaderMensjes" runat="server" CssClass="text-lg-center" Text="ESTADO DE SOLICITUD"></asp:Label>
        </div>
        <div class="body bg-gray">
            
  <div class="form-group">
      <asp:Label ID="lblMsg" CssClass=" text-success"  Visible="false" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control  btn-block" placeholder="Ingresa un matricula"></asp:TextBox>
       <asp:RegularExpressionValidator ID="revTextBox1" runat="server" ErrorMessage="*" CssClass="lbl-Valida"
      Display="Dynamic" ControlToValidate="TextBox1"
      ValidationExpression="^[0-9]{6}$" ForeColor="Red">
     *Ingrese 6 digitos
     </asp:RegularExpressionValidator>

    <asp:RequiredFieldValidator ID="rfvTextBox1" runat="server" ErrorMessage="*"
    ControlToValidate="TextBox1" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Campo obligatorio
    </asp:RequiredFieldValidator>
      </div>
        <div class="footer bg-gray">
            <asp:Button ID="Button1" runat="server" Text="BUSCAR" CssClass="btn  btn-block  btn-success"  OnClick="Button1_Click"  />
       
            
              </div>
        </div>
        </div>


    <br />
    <asp:Panel ID="pnlGrid" runat="server" Visible="True">
    <asp:GridView ID="grvEstado" runat="server" CssClass=" table table-hover" AutoGenerateColumns="False" >
        
        
     <Columns>
        <asp:BoundField DataField="matricula" HeaderText="Matricula" SortExpression="matricula" />
                <asp:BoundField DataField="estado" HeaderText="Estado Solicitud" SortExpression="estado" />
       </Columns>
    </asp:GridView>
        </asp:Panel>
  
   
  
</asp:Content>
