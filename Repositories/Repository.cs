using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel: class
    {   
        private readonly SqlConnection _sqlConnection; 
        public Repository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }  

        public void Create(TModel model){
            _sqlConnection.Insert<TModel>(model);
        }
        
        public TModel Get(int id) => _sqlConnection.Get<TModel>(id);

        public IEnumerable<TModel> GetAll() => _sqlConnection.GetAll<TModel>();

        public void DeleteById(int id){
            var model = _sqlConnection.Get<TModel>(id);
            _sqlConnection.Delete<TModel>(model);  
        }

        public void Delete(TModel model){
            _sqlConnection.Delete<TModel>(model);   
        }

        public void Delete(int id){
            var role = _sqlConnection.Get<TModel>(id);
            _sqlConnection.Delete<TModel>(role);  
        }
        public void Update(TModel model) {
            _sqlConnection.Update<TModel>(model);   
        }
    }

}