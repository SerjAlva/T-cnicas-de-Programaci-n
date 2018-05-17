using System;
using System.IO;

namespace ArchivosGestor
{
    public class Archivo
    {
        //Acceso secuencial.
        FileStream fs;
        StreamWriter sw;
        StreamReader sr;

        public string contenido;
        private string nombre; //Atributo

        //Propiedad
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (value == "")
                {
                    nombre = "archivo.txt";
                }
                else
                {
                    nombre = value;
                }
            }

        }

        //Construtor que pide el nombre del archivo y su contenido en formato de cadena.Texto Plano.
        //Nombre -> Ruta del archvio y su identificador.
        //contenido -> Es lo que desea almacenar el usuario.

        //Constructor para pedirle el contenido al usuario.
        public Archivo(string Nombre, string contenido)
        {
            this.contenido = contenido;
            this.Nombre = Nombre;
        }



        public void Escribir()
        {
            try
            {
                //Abriendo el flujo
                sw = new StreamWriter(Nombre);
                sw.WriteLine(contenido);
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        public void Leer()
        {
            try
            {
                sr = new StreamReader(Nombre);
                contenido = sr.ReadLine(); //Contenido ya es publico

            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                sr.Close();
            }

        }

        //Va a concatenar. Agregar más datos al archivo.
        public void EscribirAppend()
        {
            try
            {
                fs = new FileStream(Nombre, FileMode.Append, FileAccess.Write);
                //Abriendo el flujo
                sw = new StreamWriter(Nombre);
                sw.WriteLine(contenido);
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        public void Append()
        {
            try
            {
                sr = new StreamReader(fs);
                contenido = sr.ReadLine();//Contenido ya es publico
                while (contenido != null)
                {
                    contenido += contenido;
                }


            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                sr.Close();
            }

        }
        public void LeerAleatorio(string Archivo) //el string con mayúscula es para un objeto
        {
            long offset;     //
            int nextbyte;

            fs = new FileStream(Archivo, FileMode.Open, FileAccess.Read);//leer el flujo 
            for (offset = 1; offset <= fs.Length; offset++) //para recorrer los byrtes de ese archivo
            {
                fs.Seek(-offset, SeekOrigin.End);   //indica que vas de derecha izquierda

                Console.Write(Convert.ToChar(fs.ReadByte()));

            }
            Console.WriteLine();
            fs.Seek(20, SeekOrigin.Begin);
            while ((nextbyte = fs.ReadByte()) > 0)
            {
                Console.WriteLine();


            }


        }
    }
}
