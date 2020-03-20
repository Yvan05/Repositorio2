using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDeDatos
{
   public class RegistroAlumDat
    {
        #region "PATRON SINGLETON"
        private static RegistroAlumDat daoAlumno = null;
        private RegistroAlumDat() { }
        public static RegistroAlumDat getInstance()
        {
            if (daoAlumno == null)
            {
                daoAlumno = new RegistroAlumDat();
            }
            return daoAlumno;
        }
        #endregion
        public bool Solicitud(RegistroAlum objRegistroAlum)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("Solicitud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombre",objRegistroAlum.Nombre);
             //   cmd.Parameters.AddWithValue("@prmSNombre", objRegistroAlum.SNombre);
                cmd.Parameters.AddWithValue("@prmApPaterno", objRegistroAlum.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno", objRegistroAlum.ApMaterno);
                cmd.Parameters.AddWithValue("@prmEdad", objRegistroAlum.Edad);
                cmd.Parameters.AddWithValue("@prmSexo", objRegistroAlum.Sexo);
                cmd.Parameters.AddWithValue("@prmDireccion", objRegistroAlum.Direccion);
               // cmd.Parameters.AddWithValue("@prmTelefono", objRegistroAlum.Telefono);
                cmd.Parameters.AddWithValue("@prmSemestre", objRegistroAlum.Semestre);
                cmd.Parameters.AddWithValue("@prmCarrera", objRegistroAlum.Carrera);
                cmd.Parameters.AddWithValue("@prmCorreo", objRegistroAlum.Correo);
                cmd.Parameters.AddWithValue("@prmMatricula", objRegistroAlum.Matricula);
                cmd.Parameters.AddWithValue("@prmCelular", objRegistroAlum.Celular);
                cmd.Parameters.AddWithValue("@prmEstado", objRegistroAlum.Estado);

                con.Open();

                int filas = cmd.ExecuteNonQuery();
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
