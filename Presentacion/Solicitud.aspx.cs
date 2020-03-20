using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDeEntidad;
using CapaDeNegocios;

namespace Presentacion
{
    public partial class Solicitud : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            

        }

   private RegistroAlum GetEntity()
        {
            
            RegistroAlum objRegistroAlum = new RegistroAlum();
            objRegistroAlum.Nombre = tbNames.Text;
            //objRegistroAlum.SNombre = tbSegundoNombre.Text;
            objRegistroAlum.ApPaterno = tbPaterno.Text;
            objRegistroAlum.ApMaterno = tbMaterno.Text;
            objRegistroAlum.Edad = Convert.ToInt32(tbEdad.Text);
            //objRegistroAlum.Sexo = tbSexo.Text;
            objRegistroAlum.Sexo=((ddlSexo.SelectedValue=="Femenino")?'F':'M');
            objRegistroAlum. Semestre= Convert.ToInt32(ddlSemestre.Text);
            objRegistroAlum.Direccion = tbDireccion.Text;
            objRegistroAlum.Correo = tbEmail.Text;
            objRegistroAlum.Carrera = tbCarreraU.Text;
            objRegistroAlum.Celular = tbCel.Text;
            objRegistroAlum.Estado = ((ddlEstado.SelectedValue == "En Proceso")?"En Proceso":"Aceptado");
            objRegistroAlum.Matricula = Convert.ToInt32(tbMatricula.Text);
            return objRegistroAlum;

        }


        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            RegistroAlum objRegistroAlum = GetEntity();
             bool response = RegistroAlumNeg.getInstance().Solicitud(objRegistroAlum);
             if (response == true)
             {
                 Response.Write("<script>alert('Alumno registrado correctamente.')</script>");
               // Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('TThis is alert');</script>");
            }
             else
             {
                 Response.Write("<script>alert('Alumno registrado incorrectamente ,Revise los campos!!.')</script>");
             }

           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
          //Page.ClientScript.RegisterStartupScript(this.GetType(),"Scripts","<script>alert('TThis is alert');</script>");
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEstado.Enabled = false;
        }

        protected void tbNames_TextChanged(object sender, EventArgs e)
        {
            
        }
    }

    
}