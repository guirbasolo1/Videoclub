using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoclub
{
    internal class Alquilar
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Videoclub"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;
        

        public static void RentFilm(Usuario usuario)
        {
            List<int> list = new List<int>();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Peliculas disponibles");
            Console.ForegroundColor = ConsoleColor.White;
            conexion.Open();
            string query = $"select * from peliculas where estado = 'dis' and edadrecomendada < {usuario.Anios()+1} ";
            comando = new SqlCommand(query, conexion);
            registros = comando.ExecuteReader();
            while (registros.Read())
            {
                list.Add(int.Parse(registros["ID"].ToString()));
                Console.WriteLine(registros["ID"]+" "+registros["Nombre"]);
            }

            conexion.Close();



            Console.WriteLine("Escribe el ID de la pelicula que desea alquilar: ");
            int film = int.Parse(Console.ReadLine());
            if (list.IndexOf(film) != -1)
            {
                string state = "ND";

                conexion.Open();
                string queryUpdate = $"UPDATE peliculas SET ESTADO = '{state}' WHERE id = {film} and edadrecomendada < {usuario.Anios()+1} and estado='dis' ";
                comando = new SqlCommand(queryUpdate, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Pelicula alquilada con exito");
                Console.ForegroundColor = ConsoleColor.White;
                MisAlquileres.Alquilar(film, usuario.Email);
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Solo puedes elegir una pelicula disponible.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //Menu.MenuPrinc(usuario);
        }

    }
}



