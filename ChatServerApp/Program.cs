using ChatServerApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en purto {0},puerto");
            ServerSocket servidor = new ServerSocket(puerto);
            if(servidor.Iniciar())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Esperando Clientes....");
                if(servidor.ObtenerCliente())
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Conexion Establecida!");
                    Console.WriteLine("S:Hola mundo Cliente!");
                    servidor.Escribir("hola mundo cliente");
                    string mensaje = servidor.Leer();
                    Console.WriteLine("C:{0}", mensaje);
                    servidor.CerrarConexion();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No es posible Iniciar servidor");
                Console.ReadKey();
            }
        }
    }
}
