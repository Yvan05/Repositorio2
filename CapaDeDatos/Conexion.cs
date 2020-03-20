using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    public class Conexion
    {
        #region "Patron singleton"
        //creando atributos de tipo conexion

        private static Conexion conexion = null;
        //constructor
        private Conexion()
        {
    
        }

        //metodo para retornar una instancia de la conexion
        public static Conexion getInstance()
        {
            if(conexion==null) //si la conexion es nulla crea una nueva conexion y la retorna
            {
                conexion = new Conexion();

            }
            return conexion;

        }


        #endregion
        //crea la conexion con el servidor sql
        public SqlConnection ConexionBD() {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-8OI8PMB\MSSQLSERVER01; Initial Catalog=SistemaDeBajas; Integrated Security=true";
            return conexion;
        }
       

    }
}
