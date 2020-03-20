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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            //verifica el selectedvaluedel ddl
           
            if (DropDownList1.SelectedValue=="alum")
               
                {
                //intancia
                AlumnoEnt objAlumno = AlumnoNeg.getInstance().AccesoSistema(txtUsuario.Text, txtClave.Text);
                if (objAlumno != null)
                {
                    //se inicio sesion en el login lo pone en acessoo lo que hay en txtusuario
                    Session["acceso"] = txtUsuario.Text;
                    Response.Write("<script>alert('USUARIO CORRECTO' )</script>");//manda un mensaje
                    Response.Redirect("Pag1.aspx");//redirige

                }
                else
                {
                    Response.Write("<script>alert('USUARIO INCORRECTO')</script>");//manda un mensaje si esta man el usuario

                }
            }
       
           if (DropDownList1.SelectedValue == "docent")
            
            {

                DocenteEnt objAlumno = DocenteNeg.getInstance().AccesoSistemaDocente(txtUsuario.Text, txtClave.Text);
                if (objAlumno != null)
                {
                    Session["acceso2"] = txtUsuario.Text;
                    Response.Write("<script>alert('USUARIO CORRECTO' )</script>");
                    Response.Redirect("Pag2.aspx");

                }
                else
                {
                    Response.Write("<script>alert('USUARIO INCORRECTO')</script>");

                }
            }
            //else
            //{
           //     Response.Write("<script>alert('SELECCIONE USUARIO CORRECTO ALUMNO O DOCENTE')</script>");
           //
            ///}
        

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
