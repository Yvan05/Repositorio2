using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDeEntidad;
using System.Data;


namespace CapaDeDatos
{
   public class DocenteDat
    {
        #region "Patron Singleton"
        private static DocenteDat uabcDocente = null;
        private DocenteDat() { }
        public static DocenteDat getInstance()
        {
            if (uabcDocente == null)
            {
                uabcDocente = new DocenteDat();
            }
            return uabcDocente;
        }
        #endregion

        public DocenteEnt AccesoSistemaDocente(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            DocenteEnt objDocent= null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSitemaAdministrador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objDocent = new DocenteEnt();
                    objDocent.IdDocente = Convert.ToInt32(dr["IdDocente"].ToString());
                    objDocent.Usuario = dr["Usuario"].ToString();
                    objDocent.Clave = dr["Clave"].ToString();



                }
            }
            catch (Exception e)
            {
                objDocent = null;
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            return objDocent;
        }

    }
}
///////////////




 

