using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransportePublico
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int CantPasajeros) : base(CantPasajeros)
        { 
        }
        public override int CantMaxPasajeros => 20;
        public override string Tipo => "Omnibus";
        public override string Estado { get => base.Estado; set => base.Estado = value; }
        public override string Avanzar()
        {
            Estado = "En marcha";
            return "En marcha";
        }
        public override string Detenerse()
        {
            Estado = "Detenido";
            return "Detenido";
        }
    }
}
