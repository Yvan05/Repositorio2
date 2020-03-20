using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeEntidad;

namespace CapaDeNegocios
{
    public class DocenteNeg
    {
        #region"Patron Singleton"
        private static DocenteNeg objDocent = null;
        private DocenteNeg() { }
        public static DocenteNeg getInstance()
        {
            if (objDocent == null)
            {
                objDocent = new DocenteNeg();

            }
            return objDocent;
        }
#endregion

        public DocenteEnt AccesoSistemaDocente(String user, String pass)
        {
            try
            {
                return DocenteDat.getInstance().AccesoSistemaDocente(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
