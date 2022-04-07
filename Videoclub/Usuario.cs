using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videoclub
{
    internal class Usuario
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["Videoclub"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Contaseña { get; set; }


        //metodo login
        public void Login()
        {
            bool login = false;
            while (login==false)
            {
                Console.WriteLine("Introduce tu email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Introduce tu contraseña: ");
                string pass = Console.ReadLine();

                conexion.Open();
                string query = $"SELECT * FROM usuarios WHERE email = '{email}' and contaseña='{pass}'";
                comando = new SqlCommand(query, conexion);
                registros = comando.ExecuteReader();

                if (registros.HasRows)
                {
                    while (registros.Read())
                    {
                        Console.WriteLine("usuario : " + registros["Nombre"]); login = true;
                        Nombre = registros["Nombre"].ToString();
                        Apellido = registros["Apellido"].ToString();
                        FechaNacimiento = registros["FechaNacimiento"].ToString();
                        Email = registros["Email"].ToString();
                        Contaseña = registros["Contaseña"].ToString();


                    }
                    //Menu.MenuPrinc();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ese usuario no existe");
                    Console.ForegroundColor= ConsoleColor.White;
                }

                conexion.Close();
            }
        }

        //metodo registro
        public  void Register()
        {
            Console.WriteLine("Introduce tu Nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("Introduce tu Apellido: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Introduce tu fecha de nacimiento: ");
            string date = Console.ReadLine();
            Console.WriteLine("Introduce tu email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Introduce tu contraseña: ");
            string pass = Console.ReadLine();

            conexion.Open();
            string query = $"insert into usuarios (nombre, apellido, fechanacimiento, email, contaseña) values ('{name}','{surname}','{date}','{email}','{pass}')";
            comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            //Menu.MenuPrinc();

            conexion.Close();
        }
        public int Anios()
        {
            DateTime birthDate = Convert.ToDateTime(FechaNacimiento);
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }



    }

}
