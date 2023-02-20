using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{ 
    public static class UpdateTagScreen{

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Insira o codigo da tag");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nome da tag::");
            var name = Console.ReadLine();
            Console.WriteLine("Insira o nome da slug::");
            var slug = Console.ReadLine();

            UpdateTag( new Tag { Id = id, Name = name, Slug = slug});
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void UpdateTag(Tag tag){
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }

    }
}