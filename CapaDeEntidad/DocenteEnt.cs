using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
   public class DocenteEnt
    {
        #region"Atributos"

        #endregion
        #region "Encapsulamiento"
        public int IdDocente { get; set; }
        //  public TipoEmpleado RTipoEmpleado { get; set; } Falta crea la clase tipo empleado
        public String Nombre { get; set; }
        public String AppPaterno { get; set; }
        public String ApMaterno { get; set; }
        //public String NroDocumento { get; set; }
        public bool Estado { get; set; }
        //public String Imagen { get; set; }
        public String Usuario { get; set; }
        public String Clave { get; set; }
        #endregion
        public DocenteEnt() { }
        //falta TipoEmpleado RTipoEmpleado
        public DocenteEnt(int IdDocente, String Nombre, String ApPaterno, String ApMaterno, bool Estado, String Usuario, String Clave)
        {
            this.IdDocente = IdDocente;
            //this.RTiopoEmpleado = RTipoEmpleado;
            this.Nombre = Nombre;
            this.AppPaterno = AppPaterno;
            this.AppPaterno = ApMaterno;
          //  this.NroDocumento = NroDocumento;
            this.Estado = Estado;
            //this.Imagen = Imagen;
            this.Usuario = Usuario;
            this.Clave = Clave;
        }

    }
}
