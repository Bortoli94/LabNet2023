using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransportePublico
{
    public class Taxi : TransportePublico
    {
        public Taxi(int CantPasajeros) : base(CantPasajeros)
        {            
        }
        public override int CantMaxPasajeros => 4;
        public override string Tipo => "Taxi";
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
