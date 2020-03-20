using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeEntidad;
using System.Data;
using System.Data.SqlClient;


namespace CapaDeDatos
{
   public class CuestionarioD
    {
        #region "PATRON SINGLETON"
        private static CuestionarioD daoCuesti = null;
        private CuestionarioD() { }
        public static CuestionarioD getInstance()
        {
            if (daoCuesti == null)
            {
                daoCuesti = new CuestionarioD();
            }
            return daoCuesti;
        }
        #endregion

        public bool Cuestionario(CuestionarioE objCuestionarioE)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false; //
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spCuestionario", con);// ennvia los parametros y la conexion
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMatricula", objCuestionarioE.IdMatricula);//enviamos el nombre de los parametros y el valor
                cmd.Parameters.AddWithValue("@prmNombres", objCuestionarioE.Nombres);
                cmd.Parameters.AddWithValue("@prmFecha", objCuestionarioE.Fecha);
                cmd.Parameters.AddWithValue("@prmAños", objCuestionarioE.Años);
                cmd.Parameters.AddWithValue("@prmSexo", objCuestionarioE.Sexo);
                cmd.Parameters.AddWithValue("@prmEstado", objCuestionarioE.Estado);
                cmd.Parameters.AddWithValue("@prmSituacion", objCuestionarioE.Situacion);
                cmd.Parameters.AddWithValue("@prmEconomicamente", objCuestionarioE.Economicamente);
                cmd.Parameters.AddWithValue("@prmBaja", objCuestionarioE.Baja);
                cmd.Parameters.AddWithValue("@prmEstudiando", objCuestionarioE.Estudiando);
                cmd.Parameters.AddWithValue("@prmApoyo", objCuestionarioE.Apoyo);
                cmd.Parameters.AddWithValue("@prmFamilia", objCuestionarioE.Familia);
                cmd.Parameters.AddWithValue("@prmHijos", objCuestionarioE.Hijos);
                cmd.Parameters.AddWithValue("@prmNumHijos", objCuestionarioE.NumHijos);
                cmd.Parameters.AddWithValue("@prmPadres", objCuestionarioE.Padres);

                con.Open();

                int filas = cmd.ExecuteNonQuery(); //filas aceptadas
                if (filas > 0) response = true; 

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }
    }
}
