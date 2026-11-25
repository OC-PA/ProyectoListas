using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoListas
{
    internal class ListaDoblementeEnlazadaCircularCanales
    {
        // Representa la cabeza de la lista doblemente enlazada circular
        private NodoCanal Cabeza { get; set; }
        private NodoCanal actual;

        public ListaDoblementeEnlazadaCircularCanales()
        {
            Cabeza = null;
            actual = null;
        }
        // Método para agregar un nuevo canal
        public void AgregarCanal(string nombre, string url)
        {
            NodoCanal nuevoNodo = new NodoCanal(nombre, url);
            if (Cabeza == null) // La lista está vacía, el nuevo nodo se convierte en la cabeza y apunta a sí mismo
            {
                Cabeza = nuevoNodo;
                actual = Cabeza;

                nuevoNodo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = nuevoNodo;
                return;
            }
            NodoCanal temp = Cabeza.Anterior; // temp cumple la funcion de cola

            temp.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = temp;

            nuevoNodo.Siguiente = Cabeza;
            Cabeza.Anterior = nuevoNodo;
        }

        // Obtiene el nodo actual (para la reproducción inicial o después de reiniciar)
        public NodoCanal ObtenerCanalActual()
        {
            return actual;
        }

        // Avanza al siguiente canal
        public NodoCanal ObtenerSiguienteCanal()
        {
            if (actual == null)
            {
                return null; // Lista vacía
            }
            actual = actual.Siguiente; // Avanza al nodo siguiente
            return actual;
        }

        // Retrocede al canal anterior
        public NodoCanal ObtenerAnteriorCanal()
        {
            if (actual == null)
            {
                return null; // Lista vacía
            }
            actual = actual.Anterior; // Retrocede al nodo anterior
            return actual;
        }

        // Vuelve al primer canal de la lista
        public void Reiniciar()
        {
            actual = Cabeza;
        }
    }
}
