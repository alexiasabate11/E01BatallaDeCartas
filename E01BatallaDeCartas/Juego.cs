using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01BatallaDeCartas
{
    internal class Juego
    {
        List<Jugador> jugadores = new List<Jugador>();
        public Juego() 
        {
            Ronda();
        }

        public void Ronda()
        {
            Baraja baraja = new Baraja();
            jugadores = baraja.RepartirCartas();
            do
            {
                List<Carta> cartasRonda = CartasRonda();
                Carta cartaMasAlta = CartaMasAlta(cartasRonda);
                JugadorGanadorRonda(cartaMasAlta, cartasRonda);
                if(JugadorGanadorPartida())
                    return;

            } while (true);
        }

        public List<Carta> CartasRonda()
        {
            Baraja baraja = new Baraja();

            List<Carta> cartasRonda = new List<Carta>();
            Carta cartaMasAlta = new Carta();
            Jugador jugadorCartaMasAlta = new Jugador();

            foreach (Jugador jugador in jugadores)
            {
                Carta cartaRobada = baraja.RobarCarta(jugador.CartasJugador);
                Console.WriteLine(jugador.Nombre);
                Console.WriteLine($"\tCarta robada: {cartaRobada.Numero} de {cartaRobada.Palo}");
                cartasRonda.Add(cartaRobada);
            }
            return cartasRonda;
        }

        public Carta CartaMasAlta(List<Carta> cartasRonda)
        {
            Carta cartaMax = new Carta();
            foreach(Carta carta in cartasRonda)
            {
                if (carta.Numero > cartaMax.Numero)
                    cartaMax = carta;
            }
            return cartaMax;
        }

        public void JugadorGanadorRonda(Carta cartaMax, List<Carta> cartasRonda)
        {
            foreach(Jugador jugador in jugadores)
            {
                foreach(Carta cartaJugador in jugador.CartasJugador)
                {
                    if (cartaJugador == cartaMax)
                    {
                        jugador.CartasJugador.Remove(cartaMax);
                        jugador.CartasJugador.AddRange(cartasRonda);
                        Console.WriteLine($"\nEl ganador de esta ronda es: " + jugador.Nombre);
                        break;
                    }
                }

                foreach(Carta cartaAEliminar in cartasRonda)
                {
                    if(jugador.CartasJugador.Contains(cartaAEliminar))
                        jugador.CartasJugador.Remove(cartaAEliminar);
                }
            }
        }

        public Boolean JugadorGanadorPartida()
        {
            foreach(Jugador jugador in jugadores)
            {
                if (jugador.CartasJugador.Count() == 0)
                {
                    Console.WriteLine($"Jugador: {jugador.Nombre} eliminado.");
                    jugadores.Remove(jugador);
                }

                if (jugadores.Count() == 1)
                {
                    Console.WriteLine($"GANADOR: {jugador.Nombre}.");
                    return true;
                }
            }
            return false;
        }
    }
}
