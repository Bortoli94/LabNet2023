using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransportePublico
{
    public abstract class TransportePublico
    {
        public TransportePublico(int cantPasajeros)
        {
            this.CantPasajeros = cantPasajeros;
            Estado = "Detenido";
        }
        public int CantPasajeros { get; set; }
        public abstract int CantMaxPasajeros { get; }
        public abstract string Tipo { get; }
        public virtual string Estado { get; set; }
        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
