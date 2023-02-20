using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{ 
    public static class CreateTagScreen{
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Insira o nome da tag::");
            var name = Console.ReadLine();
            Console.WriteLine("Insira o nome da slug::");
            var slug = Console.ReadLine();

            CreateTag( new Tag { Name = name, Slug = slug});
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void CreateTag(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag inserida com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag");
                Console.WriteLine(ex.Message);
            }

        }
    }
}