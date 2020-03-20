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
  public  class AlumnoDat
    {
        #region "Patron Singleton"
        private static AlumnoDat uabcAlumno = null;
        private AlumnoDat() { } //esconde el constructor
        public static AlumnoDat getInstance() //retorna una instancia de tipo alumnoDat
        {
            if(uabcAlumno==null) //si no se ha hecho una instancia de tipo uabcalum
            {
                uabcAlumno = new AlumnoDat(); //da una instancia de ese objeto
            }
            return uabcAlumno;
        }
        #endregion

        public AlumnoEnt AccesoSistema(String user,String pass) //recibe como parametros usuario y pass
        {
            SqlConnection conexion = null; 
            SqlCommand cmd = null; //envia nuestro comando a la base de datos para que se ejecute
            AlumnoEnt objAlum = null; //objeto de tipo alum, se va a llenar dentro de este metodo
            SqlDataReader dr = null; //lee los datos
            try
            {
                conexion = Conexion.getInstance().ConexionBD(); // se establece la conexion
                cmd = new SqlCommand("spAccesoSitemaAlumnos", conexion); //storeprocedure
                cmd.CommandType = CommandType.StoredProcedure;//nos dice que tipo de comando estamos llamando
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open(); //abrimos la conexion y ejecutamos
                dr = cmd.ExecuteReader(); //lector de datos
                if (dr.Read())//si tiene un dato para leer
                {
                    objAlum = new AlumnoEnt(); //nos crea un objeto
                    objAlum.IdMatricula = Convert.ToInt32(dr["IdMatricula"].ToString()); 
                    objAlum.Usuario = dr["Usuario"].ToString();
                    objAlum.Clave = dr["Clave"].ToString();



                }
            }
            catch(Exception e)
            {
                objAlum = null;
                throw e;
            }
            finally
            {
                conexion.Close();//cierra la conexion
            }
            return objAlum; //retorna tipo alum
        }
    }
}
