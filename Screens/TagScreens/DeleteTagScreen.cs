using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens{ 
    public static class DeleteTagScreen{
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Insira o codigo da tag");
            var id = int.Parse(Console.ReadLine());

            DeleteTag(id);
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void DeleteTag(int id){
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag excluída com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}