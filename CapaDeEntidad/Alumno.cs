using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class Alumno
    {
        public String Nombre { get; set; }
       // public String SNombre { get; set; }
        public String ApPaterno { get; set; }
        public String ApMaterno { get; set; }
        public int Edad { get; set; }
        public String Sexo { get; set; }
        public String Carrera { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int Matricula { get; set; }
        public int Semestre { get; set; }
        public String Celular { get; set; }
        public String Estado { get; set; }

        public Alumno() { }
        public Alumno(String _Nombre,  String _ApPaterno, String _ApMaterno, int _Edad, String _Sexo
            , String _Carrera, String _Direccion, String _Telefono, int _Matricula, int _Semestre, String _Celular,String _Estado)
        {

            this.Nombre = _Nombre;
          //  this.SNombre = _SNombre;
            this.ApPaterno = _ApPaterno;
            this.ApMaterno = _ApMaterno;
            this.Edad = _Edad;
            this.Sexo = _Sexo;
            this.Carrera = _Carrera;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
            this.Matricula = _Matricula;
            this.Semestre = _Semestre;
            this.Celular = _Celular;
            this.Estado = _Estado;

        }
    }
}
