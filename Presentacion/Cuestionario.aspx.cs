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
    public partial class Cuestionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private CuestionarioE GetEntity()
        {
            //creamos una entidad para poder asignar  nuestros objetos
            CuestionarioE objCuestionarioE = new CuestionarioE();
            objCuestionarioE.Nombres = tbNames.Text;  //con el objeto de tipo cuestionarioE manda a llamar el atributo Nombre
            objCuestionarioE.IdMatricula = Convert.ToInt32(tbMatri.Text);
            objCuestionarioE.Fecha = tbFecha.Text;
            objCuestionarioE.Años = Convert.ToInt32(tbAñios.Text);
            objCuestionarioE.Sexo = ((ddlSexo.SelectedValue == "Femenino") ? 'F' : 'M');
            objCuestionarioE.Estado = ((ddlEStadoCivil.SelectedValue == "Soltero") ? "Soltero" : "Casado");
            objCuestionarioE.Situacion = ((dllDepende.SelectedValue == "Trabajo") ? "Trabajo" : "Desempleado");
            objCuestionarioE.Economicamente = ((ddlEstadoEconomico.SelectedValue == "Si") ? "Si" : "No");
            objCuestionarioE.Baja = tbMotivoDeBaja.Text;
            objCuestionarioE.Estudiando = ((ddlEstadoEconomico.SelectedValue == "Si") ? "Si" : "No");
            objCuestionarioE.Apoyo = ((ddlApoyo.SelectedValue == "Si") ? "Si" : "No");
            objCuestionarioE.Familia = ((ddlEstadoEconomico.SelectedValue == "Bueno") ? "Bueno" : "Regular");
            objCuestionarioE.Hijos = ((dllTieneHijos.SelectedValue == "Si") ? "Si" : "No");
            objCuestionarioE.NumHijos = Convert.ToInt32(dllNumerohijos.Text);
            objCuestionarioE.Padres = ((ddlVive.SelectedValue == "Si") ? "Si" : "No");
            return objCuestionarioE;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //registro de cuestionario
            CuestionarioE objCuestionario= GetEntity();
            //envia a la capa de negocios
            bool response = CuestionarioN.getInstance().Cuestionario(objCuestionario);
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

        }

        protected void tbNames_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}