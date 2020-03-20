<%@ Page Title="" Language="C#" MasterPageFile="~/InicioMasterPage.Master" AutoEventWireup="true" CodeBehind="Cuestionario.aspx.cs" Inherits="Presentacion.Cuestionario" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">
     
    <section class="content-header">
      
    <h1 style="text-align:center">Cuestionario Socioeconomico y de Baja UABC</h1>
        </section>
   <section class="content">
        <div class="row">
            <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                         <div class="form-group">
                            <label>NOMBRES(S)</label>
                        </div>
                        <div class="form-group">
       <asp:TextBox ID="tbNames" runat="server" Text="" CssClass="form-control" placeholder="Ingrese sus Nombres" OnTextChanged="tbNames_TextChanged"></asp:TextBox>
                                                        
<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese sus Nombres"
    ControlToValidate="tbNames" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Campo obligatorio
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID = "revNombre" runat = "server"     
ErrorMessage = "nombre incorrecto"
ControlToValidate = "tbNames"    
ValidationExpression = "^[a-zA-Z \s]{3,50}$" ForeColor="Red"></asp:RegularExpressionValidator>

                        </div>
                         <div class="form-group">
                            <label>MATRICULA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="tbMatri" runat="server" Text="" CssClass="form-control" placeholder="******"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revMatricula" runat="server" ErrorMessage="*" CssClass="lbl-Valida"
                            Display="Dynamic" ControlToValidate="tbMatri"
                            ValidationExpression="^[0-9]{6}$" ForeColor="Red">
                            *Ingrese solo 6 digitos
                             </asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ErrorMessage="*"
                            ControlToValidate="tbMatri" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
                             Campo obligatorio
                             </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>FECHA DE NACIMIENTO?</label>
                        </div>
                        <div class="form-group">
                           <asp:TextBox ID="tbFecha" runat="server" Text="" CssClass="form-control" placeholder="dd//mm//aa"></asp:TextBox>
<asp:RegularExpressionValidator ID="revFecha" runat="server" ErrorMessage="*"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/.](0[1-9]|1[012])[ /.](19|20)\d\d" 
    ControlToValidate="tbFecha" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Formato Incorrecto:dd/mm/aa 
</asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="*" CssClass="lbl-Valida" Display="Dynamic" ControlToValidate="tbFecha" ForeColor="Red">
    Campo obligatorio
</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>CUANTOS AÑOS CUMPLIDOS TIENE?</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="tbAñios" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAccount" runat="server" ErrorMessage="*Requerido" 
                            ControlToValidate="tbAñios" MinimumValue="1" MaximumValue="99" ForeColor="Red"></asp:RequiredFieldValidator>


                           <asp:RegularExpressionValidator ID="revAccount" runat="server"    ControlToValidate="tbAñios"
                            ErrorMessage="*Edad Incorrecta" ValidationExpression="^[1-99]{1,2}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                       
                        <div class="form-group">
                            <label>CUAL ES SU ESTADO CIVIL?</label>
                        </div>
                        <div class="form-group">
                               <asp:DropDownList ID="ddlEStadoCivil" runat="server" CssClass="form-control">
                                <asp:ListItem>Soltero</asp:ListItem>
                                <asp:ListItem>Casado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                         <div class="form-group">
                            <label>SEXO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                                
                            </asp:DropDownList>
                        </div>
                            <br />
                        <div class="form-group">
                            <label>SITUACION LABORAR ACTUAL?</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEstadoLaboral" runat="server" CssClass="form-control">
                                <asp:ListItem>Trabajo</asp:ListItem>
                                <asp:ListItem>Desempleado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>DEPENDE DE ALGUIEN ECONOMICAMENTE?</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dllDepende" runat="server" CssClass="form-control">
                                <asp:ListItem>Si</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>MOTIVO POR LA BAJA?</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="tbMotivoDeBaja" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <br />
                    
                        <div class="form-group">
                            <label>SEGUIRA ESTUDIANDO ?</label>
                        </div>
                        <div class="form-group">
                                <asp:DropDownList ID="dllEstudiando" runat="server" CssClass="form-control">
                                <asp:ListItem>Si</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                        
                  
                </div>
               
            </div>
             <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                        <div class="form-group">
                            <label>CUENTA CON BECA:</label>
                        </div>
                        <div class="form-group">
                                <asp:DropDownList ID="ddlApoyo" runat="server" CssClass="form-control">
                                <asp:ListItem>Si</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                            <br />
                        <div class="form-group">
                            <label>ESTADO ECONOMICO:</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEstadoEconomico" runat="server" CssClass="form-control">
                                <asp:ListItem>Bueno</asp:ListItem>
                               
                                 <asp:ListItem>Bajo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>TIENE HIJOS:</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dllTieneHijos" runat="server" CssClass="form-control">
                                <asp:ListItem>Si</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>                              
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>CUANTOS HIJOS TIENE:</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="dllNumerohijos" runat="server" CssClass="form-control">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem> 
                                <asp:ListItem>2</asp:ListItem>   
                                <asp:ListItem>3</asp:ListItem>   
                                <asp:ListItem>4</asp:ListItem>   
                                <asp:ListItem>5</asp:ListItem>   
                                <asp:ListItem>6</asp:ListItem>   
                                <asp:ListItem>7</asp:ListItem>   
                                <asp:ListItem>8</asp:ListItem>   
                                <asp:ListItem>9</asp:ListItem> 
                                <asp:ListItem>10</asp:ListItem>   
                                
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>VIVE SOLO:</label>
                        </div>
                            <br />
                        <div class="form-group">
                              <asp:DropDownList ID="ddlVive" runat="server" CssClass="form-control">
                                <asp:ListItem>Si</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>                              
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
               
            </div>
          

        </div>
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-block  btn-success" Width="200px" Text="Registrar" OnClick="btnEnviar_Click" />
                        
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-block  btn-success" Width="200px" Text="Cancelar" OnClick="btnCancelar_Click" />

                    </td>
                </tr>
            </table>
        </div>

       
       
    </section>
</asp:Content>
