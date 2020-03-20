using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeNegocios;
using CapaDeEntidad;

namespace CapaDeNegocios
{
    public class CuestionarioN
    {
        #region "PATRON SINGLETON"
        private static CuestionarioN objCuesti = null;
        private CuestionarioN() { }
        public static CuestionarioN getInstance()
        {
            if (objCuesti == null)
            {
                objCuesti = new CuestionarioN();
            }
            return objCuesti;
        }
#endregion

        public bool Cuestionario(CuestionarioE objCuestionarioE)

        {
            try
            {
                //mandamos a llamar la funcion cuestionario y le eniamos como paramtro el objeto cuestionarioE
                return CuestionarioD.getInstance().Cuestionario(objCuestionarioE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
