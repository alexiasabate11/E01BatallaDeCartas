using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01BatallaDeCartas
{
    internal class Jugador
    {
        private string nombre;
        private List<Carta> cartasJugador;
        
        public Jugador() { }

        public Jugador(string nombre, List<Carta> cartasJugador)
        {
            this.nombre = nombre;
            this.cartasJugador = cartasJugador;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Carta> CartasJugador
        {
            get { return cartasJugador; }
            set { cartasJugador = value; }
        }

        public void MostrarJugadores(List<Jugador> jugadores)
        {
            foreach (Jugador jugador in jugadores)
            {
                string nombreJugador = jugador.Nombre;
                cartasJugador = jugador.CartasJugador;
                Console.WriteLine($"Jugador: {nombreJugador}\nNumero de cartas: {cartasJugador.Count()}");
            }
        }

        public int NumeroJugadores()
        {
            Console.WriteLine("Numero de jugadores: ");
            Int32.TryParse(Console.ReadLine(), out int numeroJugadores);
            Console.WriteLine();
            return numeroJugadores;
        }

        public Jugador CrearJugador(List<Carta> cartasJugador)
        {
            Console.WriteLine("Nombre del jugador:");
            Jugador nuevoJugador = new Jugador(Console.ReadLine(), cartasJugador);
            Console.WriteLine();
            return nuevoJugador;
        }
    }
}
