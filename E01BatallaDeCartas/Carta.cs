using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01BatallaDeCartas
{
    internal class Carta
    {
        public enum ePalos
        {
            Oros,
            Picas,
            Corazones,
            Diamantes
        }
        
        private int numero;
        private ePalos palo;

        public Carta() { }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public ePalos Palo
        {
            get { return palo; }
            set { palo = value; }
        }

        public Carta(int numero, ePalos palo) 
        {
            this.numero = numero;
            this.palo = palo;
        }
    }
}
