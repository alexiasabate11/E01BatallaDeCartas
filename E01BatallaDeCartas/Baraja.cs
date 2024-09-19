using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01BatallaDeCartas
{
    internal class Baraja
    {
        private List<Carta> cartas;
        private List<Jugador> jugadores = new List<Jugador>();
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

        public List<Carta> CrearBaraja()
        {
            cartas = new List<Carta>();

            // Recorremos todos los números (1 al 12) y palos (Oros, Picas, Corazones, Diamantes)
            for (int numero = 1; numero <= 12; numero++)
            {
                foreach (Carta.ePalos palo in Enum.GetValues(typeof(Carta.ePalos)))
                    cartas.Add(new Carta(numero, palo));
            }

            return cartas;
        }

        public List<Jugador> RepartirCartas()
        {
            Jugador j = new Jugador();
            List<Carta> cartas = Barajar(CrearBaraja());
            int numeroCartasJugador = cartas.Count / j.NumeroJugadores();


            int contadorCartas = 0;
            List<Carta> cartasJugador = new List<Carta>();

            foreach (Carta carta in cartas)
            {
                cartasJugador.Add(carta);
                contadorCartas++;

                if (contadorCartas == numeroCartasJugador)
                {
                    jugadores.Add(j.CrearJugador(new List<Carta>(cartasJugador)));
                    cartasJugador.Clear();
                    contadorCartas = 0;
                    continue;
                }
            }
            return jugadores;
        }
    }
}
