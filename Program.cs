using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433; Database=Blog; User ID=sa; Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main(string[]args){
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            Console.WriteLine("Program...");
            ReadUsers(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            ReadUsersWithRoles(connection);
            connection.Close();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
        }

            
        public static void ReadUsers(SqlConnection sqlConnection){
            var repository = new Repository<User>(sqlConnection);
            var users = repository.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine($"Nome do usuário:: {user.Name}");
            }
        }

        public static void CreateUsers(SqlConnection sqlConnection){
            var user = new User(){
                Name = "William Tarcisio", 
                Bio = "Eng. Produção",
                Email = "williamtheguitar@hotmail.com",
                Image = "img",
                Slug = "will.i.am",
                PasswordHash = "hash"
            };
            var repository = new Repository<User>(sqlConnection);
            repository.Create(user);
        }

        public static void ReadUsersWithRoles(SqlConnection connection){
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($"Role - {role.Name}");
                }
            }
        }

        public static void ReadRoles(SqlConnection sqlConnection){
            var repository = new Repository<Role>(sqlConnection);
            var roles = repository.GetAll();
            foreach (var role in roles)
            {
                Console.WriteLine($"Nome do autor:: {role.Name}");
            }
        }
        public static void ReadTags(SqlConnection sqlConnection){
            var repository = new Repository<Tag>(sqlConnection);
            var roles = repository.GetAll();
            foreach (var role in roles)
            {
                Console.WriteLine($"Nome da tag:: {role.Name}");
            }
        }

         public static void ReadUser(){
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine($"User:: {user.Name}");
            }
        }

         public static void CreateUser(){
            var user = new User(){
                Name = "William Tarcisio", 
                Bio = "Eng. Produção",
                Email = "williamtheguitar@hotmail.com",
                Image = "img",
                Slug = "will.i.am",
                PasswordHash = "hash"
            };
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine($"Inserido com sucesso");
            }
        }

        
         public static void UpdateUser(){
             var user = new User(){
                Id= 2,
                Name = "William Tarcisio", 
                Bio = "Eng. Produção",
                Email = "william@hotmail.com",
                Image = "img2",
                Slug = "will.i.am",
                PasswordHash = "hash2"
            };
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                Console.WriteLine($"Atualizado com sucesso");
            }
        }
        public static void DeleteUser(){
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                Console.WriteLine($"Excluído com sucesso");
            }
        }
    }

}