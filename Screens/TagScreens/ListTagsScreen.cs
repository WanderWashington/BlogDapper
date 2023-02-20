using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{ 
    public static class ListTagScreen{
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void List(){
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.GetAll();
            foreach (var item in tags)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}