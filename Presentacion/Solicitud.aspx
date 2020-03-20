<%@ Page Title="" Language="C#" MasterPageFile="~/InicioMasterPage.Master" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="Presentacion.Solicitud" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">
    <section class="content-header">
      
        <h1 style="text-align: center">Datos Personales Del Alumno</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRE(S)</label>
                        </div>
                        <div class="form-group">
                            <asp:textbox id="tbNames" runat="server" text="" cssclass="form-control" OnTextChanged="tbNames_TextChanged"></asp:textbox>
<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*"
    ControlToValidate="tbNames" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Campo obligatorio
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID = "revNombre" runat = "server"     
ErrorMessage = "nombre incorrecto"
ControlToValidate = "tbNames"    
ValidationExpression = "^[a-zA-Z \s]{3,50}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        
                        <div class="form-group">
                            <label>APELLIDO PATERNO</label>
                        </div>
                        <div class="form-group">
                             <asp:textbox id="tbPaterno" runat="server" text="" cssclass="form-control"></asp:textbox>
<asp:RequiredFieldValidator ID="rfvApPaterno" runat="server" ErrorMessage="*"
    ControlToValidate="tbPaterno" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Campo obligatorio
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID = "revApPaterno" runat = "server"     
ErrorMessage = "Solo caracteres"
ControlToValidate = "tbPaterno"    
ValidationExpression = "^[a-zA-Z \s]{3,10}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>APELLIDO MATERNO</label>
                        </div>
                        <div class="form-group">
                          <asp:textbox id="tbMaterno" runat="server" text="" cssclass="form-control"></asp:textbox>
<asp:RequiredFieldValidator ID="rfvApMaterno" runat="server" ErrorMessage="*"
    ControlToValidate="tbMaterno" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Campo obligatorio
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID = "revApMaterno" runat = "server"     
ErrorMessage = "Solo caracteres"
ControlToValidate = "tbMaterno"    
ValidationExpression = "^[a-zA-Z \s]{3,10}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>EDAD</label>
                        </div>
                        <div class="form-group">
                            <asp:textbox id="tbEdad" runat="server" text="" cssclass="form-control"></asp:textbox>
                            <asp:RequiredFieldValidator ID="rfvEdad" runat="server" ErrorMessage="*Requerido" 
                            ControlToValidate="tbEdad" MinimumValue="1" MaximumValue="99" ForeColor="Red"></asp:RequiredFieldValidator>


                            <asp:RegularExpressionValidator ID="revEdad" runat="server"    ControlToValidate="tbEdad"
                            ErrorMessage="*Edad Incorrecta" ValidationExpression="^[1-99]{1,3}$" ForeColor="Red"></asp:RegularExpressionValidator>
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
                            <asp:dropdownlist id="ddlSexo" runat="server" cssclass="form-control">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>SinEspecificar</asp:ListItem>
                             
                            </asp:dropdownlist>
                            <!--<asp:TextBox ID="tbSexo" CssClass="form-control" runat="server"></asp:TextBox>-->

                        </div>
                      <br />
                        <div class="form-group">
                            <label>CORREO</label>
                        </div>
                        <div class="form-group">
                            
<asp:textbox id="tbEmail" runat="server" text="" cssclass="form-control"></asp:textbox>
<asp:regularexpressionvalidator ID="revtbCorreo" runat="server" ControlToValidate="tbEmail" ErrorMessage="*" 
    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
    CssClass="auto-style1"
    Display="Dynamic" ForeColor="Red">*Correo invalido</asp:regularexpressionvalidator>
<asp:RequiredFieldValidator ID="rfvtbCorreo" runat="server" ErrorMessage="*Introduzca Correo" ForeColor="Red" 
    ControlToValidate="tbEmail"></asp:RequiredFieldValidator>

                        </div>
                         
                        <div class="form-group">
                            <label>DIRECCIÓN</label>
                             </div>
                        <div class="form-group">
                            <asp:textbox id="tbDireccion" runat="server" text="" cssclass="form-control"></asp:textbox>
                            
                            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="tbDireccion"
                                ErrorMessage="*Campo Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            SOLICITUD
                        </div>
                        <div class="form-group">
                            <asp:dropdownlist id="ddlEstado" runat="server" cssclass="form-control" onselectedindexchanged="ddlEstado_SelectedIndexChanged" enabled="False">
                                <asp:ListItem>En Proceso</asp:ListItem>
                                 <asp:ListItem>Aceptado</asp:ListItem>
                                
                               
                             
                            </asp:dropdownlist>
                        </div>
                    </div>
                    <br />
                </div>
            
            </div>
            <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                        <div class="form-group">
                            <label>SEMESTRE</label>
                        </div>
                        <div class="form-group">
                            <asp:dropdownlist id="ddlSemestre" runat="server" cssclass="form-control">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                            </asp:dropdownlist>
                        </div>
                        <br />
                        <div class="form-group">
                            <label>CARRERA</label>
                        </div>
                        <div class="form-group">
                            <asp:textbox id="tbCarreraU" runat="server" text="" cssclass="form-control"></asp:textbox>
<asp:RequiredFieldValidator ID="rfvtbCarrera" runat="server" ErrorMessage="*"
    ControlToValidate="tbCarreraU" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
    Campo obligatorio
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID = "revtbCarrera" runat = "server"     
ErrorMessage = "nombre incorrecto"
ControlToValidate = "tbCarreraU"    
ValidationExpression = "^[a-zA-Z \s]{3,25}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label>MATRICULA</label>
                        </div>
                        <div class="form-group">
                            <asp:textbox id="tbMatricula" runat="server" text="" cssclass="form-control"></asp:textbox>
                            <asp:RegularExpressionValidator ID="revtbMatricula" runat="server" ErrorMessage="*" CssClass="lbl-Valida"
                            Display="Dynamic" ControlToValidate="tbMatricula"
                            ValidationExpression="^[0-9]{6}$" ForeColor="Red">
                            *Ingrese solo 6 digitos
                            </asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator ID="rfvtbMatricula" runat="server" ErrorMessage="*"
                            ControlToValidate="tbMatricula" Display="Dynamic" CssClass="lbl-Valida" ForeColor="Red">
                             Campo obligatorio
                            </asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <div class="form-group">
                            <label>CELULAR</label>
                        </div>
                        <div class="form-group">
                            <asp:textbox id="tbCel" runat="server" text="" cssclass="form-control"></asp:textbox>
                            <asp:requiredfieldvalidator id="rfvtbCel" runat="server" Display="Dynamic" ControlToValidate="tbCel" 
                            ErrorMessage="Falta Ingreso de Teléfono"  ForeColor="Red">*Requerido</asp:requiredfieldvalidator>

                            <br />

                            <asp:regularexpressionvalidator id="revtbCel" runat="server" Display="Dynamic"
                            ControlToValidate="tbCel" ErrorMessage="Formato de celular no valido"
                            ValidationExpression="[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}" CssClass="auto-style1"
                            ForeColor="Red">*No valido</asp:regularexpressionvalidator>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div align="center">
 

            <table>
                <tr>
                    <td>
                        <asp:button id="btnEnviar" runat="server" cssclass="btn btn-block  btn-success"  href="#" data-toggle="modal" data-target="#EF"  onclick="btnEnviar_Click"   width="200px" text="Registrar"  />
                        
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                  <td>
                        <asp:button id="btnCancelar" runat="server" cssclass="btn btn-block  btn-success"  width="200px" text="Cancelar" />
                  
                    </td>
                </tr>
            </table>
        </div>
     

    </section>
</asp:Content>
