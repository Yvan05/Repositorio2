<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.Master" AutoEventWireup="true" CodeBehind="Pag2.aspx.cs" Inherits="Presentacion.Pag2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ctp1" runat="server">
      <h1 style="text-align:center">Baja UABC</h1>
        
   <section class="content">
        <div class="row">
            
             <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                        <img src="img/estudiante.jpg" class="img-fluid" alt="User Image" />
                      La seccion de alumnos mostrara las solicitudes pendientes por aceptar,asi como informacion que describa al estudiante
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">

                      <img src="img/expd.png" class="img-fluid" alt="User Image" />
                        El apartado de expediente tendra funcion de generar un expediente encaso de quere archivar la informacion del estudieante (archivo en pdf)
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="box box-success">
                    <div class="box-body">
                        <img src="img/mensaje.png" class="img-fluid" alt="User Image" />
                        En la seccion mensaje aparecera notificaciones de las solicitudes que se hayan hecho.
                    </div>
                </div>
            </div>
          

        </div>
        
       
       
    </section>

</asp:Content>
