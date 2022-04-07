using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoclub
{
    internal class Disponibilidad
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Videoclub"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;


        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public string EdadRecomendada { get; set; }
        public string Estado { get; set; }
        public string ID { get; set; }

        public static void DispFilm(Usuario usuario)
        {   
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("Pelculas disponibles para su edad: ");
            Console.ForegroundColor = ConsoleColor.White;

            conexion.Open();
            string query = $"SELECT * FROM PELICULAS where edadrecomendada < {usuario.Anios()+1}";
            comando = new SqlCommand(query, conexion);
            registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["ID"]+" "+registros["Nombre"]);
            }

            conexion.Close();

            Console.WriteLine("Introduzca el ID de la pelicula: ");
            int id = int.Parse(Console.ReadLine());


            conexion.Open();
            string query1 = $"SELECT * from peliculas where ID={id}";
            comando = new SqlCommand(query1, conexion);
            registros = comando.ExecuteReader();


            if (id<=10)
            {
                while (registros.Read())
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Nombre: "+registros["Nombre"]+"\nSinopsis: "+registros["sinopsis"]+"\nEstado: "+registros["estado"]+"\nEdad recomendada: "+registros["edadrecomendada"]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            else
            {
                Console.WriteLine("Opción no dispoible");
            }


            conexion.Close();



            
            //Menu.MenuPrinc(usuario);






        }
    }
}
