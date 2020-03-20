<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="Expediente.aspx.cs" Inherits="Presentacion.Expediente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">
    
    

     <section class="content">
                       
                          
           <div class="table-responsive">
        <asp:GridView ID="DatodelAlumnoCuestionario" runat="server" CssClass=" table table-hover" AutoGenerateColumns="False" OnSelectedIndexChanged="DatodelAlumnoCuestionario_SelectedIndexChanged">
            <Columns>
                
                <asp:BoundField DataField="IdMatricula" HeaderText="Matricula" SortExpression="IdMatricula" ReadOnly="True" />
                <asp:BoundField DataField="nombres" HeaderText="Nombre" SortExpression="nombres" ReadOnly="True" />
               
                <asp:CommandField ButtonType="Image"  ItemStyle-HorizontalAlign="Center" HeaderText="CuestinarioPDF" SelectImageUrl="~/img/pdf.png" SelectText="Ver Reporte" ShowSelectButton="True" >            

<ItemStyle HorizontalAlign="Center"></ItemStyle>

                </asp:CommandField>
               
              
               
                
           
               
            </Columns>

        </asp:GridView>
     </div>
     
       
                
         
        
        
                    </section>
    
</asp:Content>
