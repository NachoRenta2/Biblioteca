
using System;
using System.Collections.Generic;

namespace Colecciones
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            int opcion;

            do
            {
                Console.WriteLine("\nBIBLIOTECA");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Listar libros");
                Console.WriteLine("3. Buscar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese una opcion: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el titulo: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Ingrese el autor: ");
                        string autor = Console.ReadLine();

                        Console.Write("Ingrese la editorial: ");
                        string editorial = Console.ReadLine();

                        if (biblioteca.agregarLibro(titulo, autor, editorial))
                        {
                            Console.WriteLine("Libro agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El libro ya existe.");
                        }

                        break;


                    case 2:
                        biblioteca.listarLibros();
                        break;


                    case 3:
                        Console.Write("Ingrese el titulo del libro a buscar: ");
                        titulo = Console.ReadLine();

                        Libro libro = biblioteca.buscarLibro(titulo);

                        if (libro != null)
                        {
                            Console.WriteLine("Libro encontrado:");
                            Console.WriteLine(libro);
                        }
                        else
                        {
                            Console.WriteLine("El libro no existe.");
                        }

                        break;


                    case 4:
                        Console.Write("Ingrese el titulo del libro a eliminar: ");
                        titulo = Console.ReadLine();

                        if (biblioteca.eliminarLibro(titulo))
                        {
                            Console.WriteLine("Libro eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El libro no existe.");
                        }

                        break;


                    case 5:
                        Console.WriteLine("Programa finalizado.");
                        break;


                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }

                Console.WriteLine();

            } while (opcion != 5);
        }
    }


    internal class Biblioteca
    {
        private List<Libro> libros;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
        }


        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;

            Libro libro;
            libro = buscarLibro(titulo);

            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
            }

            return resultado;
        }


        public void listarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
            }
            else
            {
                Console.WriteLine("\nLISTA DE LIBROS");

                foreach (var libro in libros)
                {
                    Console.WriteLine(libro);
                }
            }
        }


        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;

            Libro libro;
            libro = buscarLibro(titulo);

            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }

            return resultado;
        }


        public Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;

            int i = 0;

            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
            {
                i++;
            }

            if (i != libros.Count)
            {
                libroBuscado = libros[i];
            }

            return libroBuscado;
        }
    }


    internal class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;


        public Libro(string titulo, string autor, string editorial)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
        }


        public string getTitulo()
        {
            return titulo;
        }


        public override string ToString()
        {
            return "Titulo: " + titulo +
                   " Autor: " + autor +
                   " Editorial: " + editorial;
        }
    }
}