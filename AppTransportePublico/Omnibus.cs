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
        public override void Avanzar()
        {
            Estado = "En marcha";
        }
        public override void Detenerse()
        {
            Estado = "Detenido";
        }
    }
}
