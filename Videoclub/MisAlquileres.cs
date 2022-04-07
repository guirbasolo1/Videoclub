using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoclub
{
    internal class MisAlquileres
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Videoclub"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        public int IDalquiler { get; set; }
        public int IDPelicula { get; set; }
        public string EmailUsuario { get; set; }
        public string FechaAlquiler { get; set; }
        public string FechaDevolucion { get; set; }


        public MisAlquileres()
        {

        }

        public static void Alquilar(int id, string email)
        {
            conexion.Open();

            string query = $"insert into alquileres (IDPelicula, EmailUsuario, FechaAlquiler, FechaDevolucion, Entrega) values ({id},'{email}','{DateTime.Now}','{DateTime.Now.AddDays(3)}', 'N')";
            comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();


            conexion.Close();
        }


        public static void MisAlq(Usuario usuario)
        {
            List<MisAlquileres> lista = new List<MisAlquileres>();


            conexion.Open();

            string query1 = $"SELECT ID, alquileres.IDAlquiler, Nombre, EmailUsuario, alquileres.FechaAlquiler, alquileres.FechaDevolucion, alquileres.Entrega from peliculas INNER JOIN alquileres ON peliculas.ID=alquileres.IDPelicula where EmailUsuario ='{usuario.Email}' and estado= 'ND'";
            comando = new SqlCommand(query1, conexion);
            registros = comando.ExecuteReader();
            if (registros.HasRows)
            {
                while (registros.Read())
                {

                    MisAlquileres misal = new MisAlquileres();
                    if (registros["Entrega"].ToString() == "E")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (registros["Entrega"].ToString() == "N" && Convert.ToDateTime(registros["FechaDevolucion"].ToString()) < DateTime.Now)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        misal.IDPelicula= Convert.ToInt32(registros["ID"]);
                        misal.IDalquiler= Convert.ToInt32(registros["IDAlquiler"]);
                        lista.Add(misal);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        misal.IDPelicula= Convert.ToInt32(registros["ID"]);
                        misal.IDalquiler= Convert.ToInt32(registros["IDAlquiler"]);
                        lista.Add(misal);
                    }
                    Console.WriteLine(registros["ID"]+" - "+registros["Nombre"]+" "+registros["EmailUsuario"]+" "+" alquilada el dia "+" "+Convert.ToDateTime(registros["FechaAlquiler"]).ToString("dd/MM/yyyy")+"\t"+"Fecha de devolución "+" "+Convert.ToDateTime(registros["FechaDevolucion"]).ToString("dd/MM/yyyy"));
                    Console.ForegroundColor= ConsoleColor.White;
                   
                    



                }
            }
            else
            {
                Console.ForegroundColor=ConsoleColor.Magenta;
                Console.WriteLine("No tienes peliculas alquiladas");
                Console.ForegroundColor=ConsoleColor.White;
            }

            conexion.Close();


            bool ok = false;
            int idReserva = 0;
            Console.WriteLine("Qué desea hacer \n1. Devolver una pelicula. \n2. Volver al menú principal ");
            int respuesta = int.Parse(Console.ReadLine());

            if (respuesta==1)
            {

                Console.WriteLine("Qué pelicula quieres devolver? ");
                int movie = int.Parse(Console.ReadLine());

                foreach (MisAlquileres film in lista)
                {
                    if (film.IDPelicula==movie)
                    {
                        ok = true;
                        idReserva=film.IDalquiler;

                    }

                }
                if (ok)
                {
                    conexion.Open();
                    string query3 = $"UPDATE peliculas set estado = 'dis' where ID = '{movie}';"+
                                    $"UPDATE alquileres set FechaDevolucion = GetDate(), Entrega = 'E' where IDalquiler= '{idReserva}'";
                    comando = new SqlCommand(query3, conexion);
                    registros = comando.ExecuteReader();
                    conexion.Close();
                    Console.ForegroundColor=ConsoleColor.DarkGreen;
                    Console.WriteLine("Tu pelicula ha sido devuelta correctamente");
                    Console.ForegroundColor=ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor=ConsoleColor.DarkRed;
                    Console.WriteLine("No tienes esa pelicula alquilada");
                    Console.ForegroundColor=ConsoleColor.White;
                    MisAlq(usuario);
                }
            }
            else if (respuesta==2)
            {
                //Menu.MenuPrinc(usuario);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Esa opción no exite. Por favor elija una opción disponible");
                Console.ForegroundColor = ConsoleColor.White;
                MisAlq(usuario);

            }





            //Menu.MenuPrinc(usuario);
        }
    }



}

