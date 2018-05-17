using System;
using ArchivosGestor;

namespace EscribirLeerArchivos
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Escribe tu contenido del archivo");
            string contenido = Console.ReadLine();
            Console.WriteLine("Escribe el nombre de tu archivo");
            string nombre = Console.ReadLine();

            Archivo miarchivo = new Archivo(nombre, contenido);
            miarchivo.Escribir();


            

            miarchivo.Leer();
            Console.WriteLine("Contenido del archivo: ");
            Console.Write(miarchivo.contenido);
            Console.WriteLine("\n Ingresa la ruta y el nombre del archivo");
            string path = Console.ReadLine();
            miarchivo.LeerAleatorio(@path); //se interpreta como una cadena
            miarchivo.BorrarAleatorio(path);  //porque es el mismo path
            





        }
    }
}
