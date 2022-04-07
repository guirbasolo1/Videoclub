using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Videoclub
{
    internal class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Videoclub"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        static SqlDataReader registros;

       
                                                                                         
                                                                                        

        static void Main(string[] args)


        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
          //  Console.WriteLine(@"
          //$$\    $$\ $$\       $$\                               $$\           $$\       
          //$$ |   $$ |\__|      $$ |                              $$ |          $$ |      
          //$$ |   $$ |$$\  $$$$$$$ | $$$$$$\   $$$$$$\   $$$$$$$\ $$ |$$\   $$\ $$$$$$$\  
          //\$$\  $$  |$$ |$$  __$$ |$$  __$$\ $$  __$$\ $$  _____|$$ |$$ |  $$ |$$  __$$\ 
          // \$$\$$  / $$ |$$ /  $$ |$$$$$$$$ |$$ /  $$ |$$ /      $$ |$$ |  $$ |$$ |  $$ |
          //  \$$$  /  $$ |$$ |  $$ |$$   ____|$$ |  $$ |$$ |      $$ |$$ |  $$ |$$ |  $$ |
          //   \$  /   $$ |\$$$$$$$ |\$$$$$$$\ \$$$$$$  |\$$$$$$$\ $$ |\$$$$$$  |$$$$$$$  |
          //    \_/    \__| \_______| \_______| \______/  \_______|\__| \______/ \_______/ 







          //                                                                              ");
            Console.WriteLine(@"

                                       /\
                                      /  \
                                     / /\ \
                                    / /  \ \
                                   / /    \ \
                                  / /      \ \
                                 / /        \ \
                                / /          \ \
                               / /            \ \
_ _____  _ _ _  ___ __________/ /              \ \_____________________________
`|_   _|| |_| || __|___________/                \________________________  ,-'
   | |`-|  _  || _|                                                  ,-',-'
   |_|`-|_| |_||___|                                             _,-',-'
  ____    `-.`-____        ____        ___      ___  ___  _____,-_,-'________
 |    \      `/    |    ,-'    `-.    |   |    |   ||   ||        | /        |
 |     \     /     |-.,'  __  __  `.  |   |    |   ||   ||    ____||    _____|
 |      \   /      |-/   /  \/  \   \ |   |    |   ||   ||   |____ |   (____
 |       \_/       ||    \      /    ||   |    |   ||   ||        ||        \
 |   |\       /|   ||     |     ]    | \   \  /   / |   ||    ____| \____    |
 |   | \     / |   |/\    |____|    /   \   \/   /  |   ||   |____  _____)   |
 |   |  \   /  |   | / .  ,' | `. ,'   , \      /   |   ||        ||         |
 |___|   \_/   |___|/   `-.____,-'  ,-',`-\____/    |___||________||________/
                 / /             ,-',-' `-.`-.             \ \
                / /           ,-',-'       `-.`-.           \ \
               / /         ,-',-'             `-.`-.         \ \
              / /       ,-',-'                   `-.`-.       \ \
             / /     ,-',-'                         `-.`-.     \ \
            / /   ,-',-'                                  `-.   \ \
           / / ,-',-'                                     `-.`-. \ \
          / /-',-'                                           `-.`-\ \
         /_,-'`                                                 `'-._\






                                                                                        ");
            Console.ForegroundColor = ConsoleColor.White;





            Menu.FirstMenu();



           
        }
    }
}
