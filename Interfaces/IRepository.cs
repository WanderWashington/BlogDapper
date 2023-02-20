namespace Blog.Interfaces
{

    public interface IRepository<T>
    {   
        public T Get(int id);
        
        public T GetAll();

        public T Create();
    }

}