using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01BatallaDeCartas
{
    internal class Baraja
    {
        private List<Carta> cartas = new List<Carta>();
        public Baraja() { }

        public Baraja(List<Carta> cartas)
        {
            this.cartas = cartas;
        }

        public List<Carta> Cartas
        { 
            get { return cartas; }
            set { cartas = value; }
        }

        public List<Carta> Barajar(List<Carta> cartarSinMezclar)
        {
            Random random = new Random();
            List<Carta> cartasMezcladas = cartarSinMezclar.OrderBy(carta => random.Next()).ToList();
            return cartasMezcladas;
        }

        public Carta RobarCarta(List<Carta> cartas)
        {
            Carta cartaRobada = cartas.First();
            return cartaRobada;
        }
    }
}
