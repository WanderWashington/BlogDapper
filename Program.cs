using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433; Database=Blog; User ID=sa; Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[]args){
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Load();
            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load(){

            Console.Clear();
            Console.WriteLine("Meu blog");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuário");
            Console.WriteLine("2 - Gestão de perfis");
            Console.WriteLine("3 - Gestão de Categorias");
            Console.WriteLine("4 - Gestão de tags");
            Console.WriteLine("4 - Vincular Perfil/Usuário");
            Console.WriteLine("4 - Vincular post/tag");
            Console.WriteLine("4 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch(option){
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load();break;
            }
        }
    }

}
