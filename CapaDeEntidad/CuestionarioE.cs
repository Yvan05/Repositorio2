using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class CuestionarioE
    {
        public int IdMatricula { get; set; }
        public string Nombres { get; set; }
        public String Fecha { get; set; }
        public int Años { get; set; }
        public char Sexo { get; set; }
        public String Estado { get; set; }
        public String Situacion { get; set; }
        public String Economicamente { get; set; }
        public String Baja { get; set; }
        public String Estudiando { get; set; }
        public String Apoyo { get; set; }
        public String Familia { get; set; }
        public String Hijos { get; set; }
        public int NumHijos { get; set; }
        public String Padres { get; set; }

        public CuestionarioE(){}
        public CuestionarioE(int _IdMatricula, String _Nombres,String _Fecha,int _Años,char _Sexo, String _Estado, String _Situacion, String _Economicamente,
            String _Baja, String _Estudiando, String _Apoyo, String _Familia, String _Hijos, int _NumHijos, String _Padres)
        {
            this.IdMatricula = _IdMatricula;
            this.Nombres = _Nombres;
            this.Fecha = _Fecha;
            this.Años = _Años;
            this.Sexo = _Sexo;
            this.Estado = _Estado;
            this.Situacion = _Situacion;
            this.Economicamente = _Economicamente;
            this.Baja = _Baja;
            this.Estudiando = _Estudiando;
            this.Apoyo = _Apoyo;
            this.Familia = _Familia;
            this.Hijos = _Hijos;
            this.NumHijos = _NumHijos;
            this.Padres = _Padres;

        }

    }
}
