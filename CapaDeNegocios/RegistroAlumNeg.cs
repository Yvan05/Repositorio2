using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeEntidad;
using CapaDeNegocios;

namespace CapaDeNegocios
{
   public  class RegistroAlumNeg
    {
        #region "PATRON SINGLETON"
        private static RegistroAlumNeg objAlumno = null;
        private RegistroAlumNeg() { }
        public static RegistroAlumNeg getInstance()
        {
            if (objAlumno == null)
            {
                objAlumno = new RegistroAlumNeg();
            }
            return objAlumno;
        }
        #endregion

        public bool Solicitud(RegistroAlum objRegistroAlum)
        
        {
            try
            {
                return RegistroAlumDat.getInstance().Solicitud(objRegistroAlum);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
