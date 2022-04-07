using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoclub
{
    internal class Menu
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Videoclub"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;
        public static void FirstMenu()
        {
            Usuario usuario1 = new Usuario();
            //bienvenida y menu principal
            bool menu = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bienvenido al VideoclubBBk:  ");
            Console.ForegroundColor = ConsoleColor.White;
            while (menu==false)
            {

                Console.WriteLine("Por favor elija una opción: \n1 Crear un usuario \n2 Identificarte: ");


                try
                {
                    int respuesta = int.Parse(Console.ReadLine());
                    if (respuesta==1)
                    {
                        usuario1.Register();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Registrado correctamente");
                        Console.ForegroundColor = ConsoleColor.White;
                        usuario1.Login();
                        menu=true;


                    }
                    else if (respuesta==2)
                    {
                        usuario1.Login();
                        menu =true;


                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.DarkRed;
                        Console.WriteLine("¡ERROR! Introduce una opcion valida");
                        Console.ForegroundColor =ConsoleColor.White;

                    }
                   


                }
                catch (Exception)
                {
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine("¡ERROR! Introduce una opción valida");
                    Console.ForegroundColor =ConsoleColor.White;
                }
            }

            Console.Clear();
            MenuPrinc(usuario1);


        }



        //metodo menu principal
        public static void MenuPrinc(Usuario usuario)
        {

            //conexion.Close();
            bool exit = false;
            while (exit==false)
            {
                Console.WriteLine("¿Qué desea hacer?");
                Console.WriteLine("\n 1- Ver peliculas disponibles \n 2- Alquilar pelicula \n 3- Mis alquileres \n 4- Log Out");

                try
                {
                    int option = int.Parse(Console.ReadLine());


                    switch (option)
                    {
                        case 1:
                            Disponibilidad.DispFilm(usuario);

                            break;
                        case 2:
                            Alquilar.RentFilm(usuario);

                            break;
                        case 3:
                            MisAlquileres.MisAlq(usuario);

                            break;
                        case 4:
                            Console.ForegroundColor= ConsoleColor.Magenta;
                            Console.WriteLine("Gracias por confiar en el VideoclubBBk, esperemos verle de nuevo pronto");
                            Console.ForegroundColor= ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;



                            exit = true;


                            
                            break;
                        default:
                            Console.ForegroundColor=ConsoleColor.DarkRed;
                            Console.WriteLine("Opcion no disponible");
                            Console.ForegroundColor=ConsoleColor.White;

                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor=ConsoleColor.DarkRed;
                    Console.WriteLine("Introduce una opción válida");
                    Console.ForegroundColor=ConsoleColor.White;


                }
            }

            //MenuPrinc(usuario);

        }
    }







}



