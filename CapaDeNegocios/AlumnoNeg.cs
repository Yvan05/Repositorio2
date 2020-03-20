using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeEntidad;
namespace CapaDeNegocios
{
   public class AlumnoNeg
    {
        #region"Patron Singleton"
        private static AlumnoNeg objAlumno = null;
        private AlumnoNeg() { }
        public static AlumnoNeg getInstance()
        {
            if (objAlumno == null)
            {
                objAlumno = new AlumnoNeg();

            }
            return objAlumno;
        }
        #endregion

        public AlumnoEnt AccesoSistema(String user, String pass)
        {
            try {
                return AlumnoDat.getInstance().AccesoSistema(user, pass);
                }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
