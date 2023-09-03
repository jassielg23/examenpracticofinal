using System;
using System.Collections.Generic;

class Program
{
    struct Zona
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

    static List<Zona> zonas = new List<Zona>
    {
        new Zona { Clave = 12, Nombre = "América del norte", Precio = 2 },
        new Zona { Clave = 15, Nombre = "América central", Precio = 2.2 },
        new Zona { Clave = 18, Nombre = "América del sur", Precio = 4.5 },
        new Zona { Clave = 19, Nombre = "Europa", Precio = 3.5 },
        new Zona { Clave = 23, Nombre = "Asia", Precio = 6 }
    };

    struct Libro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int Edicion { get; set; }
        public string Autor { get; set; }
    }

    static Libro[] biblioteca = new Libro[100];
    static int contadorLibros = 0;

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Gestionar llamadas telefónicas");
            Console.WriteLine("2. Gestionar libros");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    GestionarLlamadas();
                    break;
                case 2:
                    GestionarLibros();
                    break;
                case 3:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void GestionarLlamadas()
    {
        Console.WriteLine("\nGestión de Llamadas Telefónicas:");

        Console.Write("Ingrese la clave de la zona (12, 15, 18, 19, 23): ");
        int clave = int.Parse(Console.ReadLine());

        Zona zonaSeleccionada = zonas.Find(z => z.Clave == clave);

        if (zonaSeleccionada.Clave == 0)
        {
            Console.WriteLine("Clave de zona no válida. Debe ser 12, 15, 18, 19 o 23.");
            return;
        }

        Console.Write("Ingrese el número de minutos utilizados: ");
        int minutos = int.Parse(Console.ReadLine());

        double costoTotal = zonaSeleccionada.Precio * minutos;

        Console.WriteLine($"El costo de la llamada a {zonaSeleccionada.Nombre} es: ${costoTotal}\n");
    }

    static void GestionarLibros()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nGestión de Libros:");
            Console.WriteLine("1. Agregar un libro");
            Console.WriteLine("2. Mostrar listado de libros");
            Console.WriteLine("3. Buscar libro por código");
            Console.WriteLine("4. Editar información de un libro por código");
            Console.WriteLine("5. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarLibro();
                    break;
                case 2:
                    MostrarListadoLibros();
                    break;
                case 3:
                    BuscarLibroPorCodigo();
                    break;
                case 4:
                    EditarLibroPorCodigo();
                    break;
                case 5:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void AgregarLibro()
    {
        if (contadorLibros < biblioteca.Length)
        {
            Console.Write("Ingrese el código del libro: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine();

            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine();

            Console.Write("Ingrese la edición del libro: ");
            int edicion = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();

            Libro nuevoLibro = new Libro
            {
                Codigo = codigo,
                Titulo = titulo,
                ISBN = isbn,
                Edicion = edicion,
                Autor = autor
            };

            biblioteca[contadorLibros] = nuevoLibro;
            contadorLibros++;

            Console.WriteLine("Libro agregado correctamente.");
        }
        else
        {
            Console.WriteLine("La biblioteca está llena. No se pueden agregar más libros.");
        }
    }

    static void MostrarListadoLibros()
    {
        Console.WriteLine("\nListado de Libros:");
        Console.WriteLine("Código\tTítulo\tISBN\tEdición\tAutor");

        for (int i = 0; i < contadorLibros; i++)
        {
            Console.WriteLine($"{biblioteca[i].Codigo}\t{biblioteca[i].Titulo}\t{biblioteca[i].ISBN}\t{biblioteca[i].Edicion}\t{biblioteca[i].Autor}");
        }
    }

    static void BuscarLibroPorCodigo()
    {
        Console.Write("Ingrese el código del libro a buscar: ");
        int codigoBuscado = int.Parse(Console.ReadLine());

        bool libroEncontrado = false;

        Console.WriteLine("\nLibros encontrados:");
        Console.WriteLine("Código\tTítulo\tISBN\tEdición\tAutor");

        for (int i = 0; i < contadorLibros; i++)
        {
            if (biblioteca[i].Codigo == codigoBuscado)
            {
                Console.WriteLine($"{biblioteca[i].Codigo}\t{biblioteca[i].Titulo}\t{biblioteca[i].ISBN}\t{biblioteca[i].Edicion}\t{biblioteca[i].Autor}");
                libroEncontrado = true;
                break;
            }
        }

        if (!libroEncontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    static void EditarLibroPorCodigo()
    {
        Console.Write("Ingrese el código del libro a editar: ");
        int codigoBuscado = int.Parse(Console.ReadLine());

        bool libroEncontrado = false;

        for (int i = 0; i < contadorLibros; i++)
        {
            if (biblioteca[i].Codigo == codigoBuscado)
            {
                Console.WriteLine("\nLibro encontrado:");
                Console.WriteLine($"Código: {biblioteca[i].Codigo}");
                Console.WriteLine($"Título actual: {biblioteca[i].Titulo}");
                Console.Write("Ingrese el nuevo título del libro: ");
                biblioteca[i].Titulo = Console.ReadLine();

                Console.WriteLine($"ISBN actual: {biblioteca[i].ISBN}");
                Console.Write("Ingrese el nuevo ISBN del libro: ");
                biblioteca[i].ISBN = Console.ReadLine();

                Console.WriteLine($"Edición actual: {biblioteca[i].Edicion}");
                Console.Write("Ingrese la nueva edición del libro: ");
                biblioteca[i].Edicion = int.Parse(Console.ReadLine());

                Console.WriteLine($"Autor actual: {biblioteca[i].Autor}");
                Console.Write("Ingrese el nuevo autor del libro: ");
                biblioteca[i].Autor = Console.ReadLine();

                Console.WriteLine("Libro editado correctamente.");
                libroEncontrado = true;
                break;
            }
        }

        if (!libroEncontrado)
        {
            Console.WriteLine("Libro no encontrado. No se puede editar.");
        }
    }
}
