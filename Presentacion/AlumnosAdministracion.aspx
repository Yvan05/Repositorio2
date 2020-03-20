<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="AlumnosAdministracion.aspx.cs" Inherits="Presentacion.AlumnosAdministracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">
 
    <asp:Panel ID="PanelGvMostrar" runat="server" Visible="true">
    <div class="table-responsive">
        <asp:GridView ID="DatodelAlumno" runat="server" CssClass=" table table-hover" AutoGenerateColumns="False" OnSelectedIndexChanged="DatodelAlumno_SelectedIndexChanged">
            <Columns>
                
                <asp:BoundField DataField="matricula" HeaderText="Matricula" SortExpression="matricula" ReadOnly="True" />
                <asp:BoundField DataField="nombre" HeaderText="Nombres" SortExpression="nombre"  />
               
                <asp:BoundField DataField="carrera" HeaderText="Carrera" SortExpression="carrera"  />
                <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo" />
                
                <asp:BoundField DataField="estado" HeaderText="Estado De La Solicitud" SortExpression="estado" />
              
               
                <asp:CommandField ButtonType="Image"  ItemStyle-HorizontalAlign="Center" HeaderText="PDF" SelectImageUrl="~/img/pdf.png" SelectText="Ver Reporte" ShowSelectButton="True" > 
            
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:CommandField> 
              
                   
               
            </Columns>
     
        </asp:GridView>

        <br />
        <br />
        <br />
     </div>

        </asp:Panel>


    

     <asp:Panel ID="PanelGvEditar" runat="server" CssClass=" table table-hover" AutoGenerateColumns="False" Visible="false">


     <asp:GridView runat="server" AutoGenerateColumns="False"  CssClass=" table table-hover" DataKeyNames="matricula,nombre,correo" DataSourceID="SqlDataSource1" >
         <Columns>
             <asp:BoundField DataField="matricula" HeaderText="Matricula" ReadOnly="True" SortExpression="matricula"  />
             <asp:BoundField DataField="nombre" HeaderText="Nombres" SortExpression="nombre" ReadOnly="True"  />
             <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo" ReadOnly="True" />
             
            
             <asp:BoundField DataField="estado" HeaderText="Estado De La Solicitud" SortExpression="estado" />
                <asp:ButtonField ButtonType="Image" CommandName="Edit" HeaderText="Editar" ShowHeader="True" Text="Edit" ImageUrl="~/img/edit.png" />
             <asp:ButtonField ButtonType="Image" CommandName="Cancel" HeaderText="Cancel" ShowHeader="True" Text="Cancel" ImageUrl="~/img/cancel.png"/>
             <asp:ButtonField ButtonType="Image" CommandName="Update" HeaderText="Guardar" ShowHeader="True" Text="Update" ImageUrl="~/img/save.png"/>
             <asp:ButtonField ButtonType="Image" CommandName="Delete" HeaderText="Borrar" ShowHeader="True" Text="Delete" ImageUrl="~/img/delete.png"/>
           
             
               
         </Columns>
        
    </asp:GridView>
        </asp:Panel>
    
    <div align="center">
            <table>
                <tr>
                    <td>
                        
                   <asp:Button ID="btnEditar" runat="server" Text="Administrar Solicitud" CssClass="btn-success" OnClick="btnEditar_Click" />
                   <asp:Button ID="btnImprimir" runat="server" Text="Imprimir Solicitud" CssClass="btn-success" OnClick="btnImprimir_Click" />
                         
                   
                         
                        
                </tr>
                
            </table>
        </div>





     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaDeBajasConnectionString3 %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [matricula], [nombre], [correo], [estado] FROM [RegistroAlum]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [RegistroAlum] WHERE [matricula] = @original_matricula AND [nombre] = @original_nombre AND (([correo] = @original_correo) OR ([correo] IS NULL AND @original_correo IS NULL)) AND (([estado] = @original_estado) OR ([estado] IS NULL AND @original_estado IS NULL))" InsertCommand="INSERT INTO [RegistroAlum] ([matricula], [nombre], [correo], [estado]) VALUES (@matricula, @nombre, @correo, @estado)" UpdateCommand="UPDATE [RegistroAlum] SET  [estado] = @estado WHERE [matricula] = @original_matricula   AND (([estado] = @original_estado) OR ([estado] IS NULL AND @original_estado IS NULL))">
         <DeleteParameters>
             <asp:Parameter Name="original_matricula" Type="Int32" />
             <asp:Parameter Name="original_nombre" Type="String" />
             <asp:Parameter Name="original_correo" Type="String" />
             <asp:Parameter Name="original_estado" Type="String" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="matricula" Type="Int32" />
             <asp:Parameter Name="nombre" Type="String" />
             <asp:Parameter Name="correo" Type="String" />
             <asp:Parameter Name="estado" Type="String" />
         </InsertParameters>
         <UpdateParameters>
           <asp:Parameter Name="nombre" Type="String" />
           
             <asp:Parameter Name="original_matricula" Type="Int32" />
            
             <asp:Parameter Name="original_estado" Type="String" />
         </UpdateParameters>
    </asp:SqlDataSource>
    





     <br/>
     
    <h4 style="text-align: center">Generar PDF Completo</h4>
        
            
        <div align="center">
            <table>
                <tr>
                    <td>
                         <asp:ImageButton ID="ibTodoPdf" runat="server" ImageAlign="Right" ImageUrl="~/img/PDF2.png" OnClick="ibTodoPdf_Click" />
                  
                         <br />
                          <asp:Button ID="btnVer" runat="server" CssClass="btn-success" Text="VerReporte" OnClick="btnVer_Click" />
                  
                        </td>
                   
                     <h6 style="text-align: center"><asp:Label ID="lblMensaje" runat="server" Text="Reporte" CssClass=" text-success"  Visible="false"></asp:Label></h6>
                    
                   
                         
                   
                         
                        
                </tr>
                
            </table>
        </div>
                
         
        
        



      
</asp:Content>
