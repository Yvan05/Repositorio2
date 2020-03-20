using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDeNegocios;

namespace Presentacion
{
    public partial class Estado : System.Web.UI.Page
    {
        


        public SqlConnection Conne = new SqlConnection(@"Data Source=DESKTOP-8OI8PMB\MSSQLSERVER01;Initial Catalog=SistemaDeBajas;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
          
      

        }
        
        protected void grvEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }
        

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
      


        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand micomm = new SqlCommand("select * from RegistroAlum where matricula like '" + TextBox1.Text + "%" + "'", Conne);
         
                Conne.Open();
                grvEstado.DataSource = micomm.ExecuteReader();
                grvEstado.DataBind();
            
            
        }
    }
}