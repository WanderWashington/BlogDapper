using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {

        private readonly SqlConnection _sqlConnection; 
        public UserRepository(SqlConnection sqlConnection): base(sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }  

        public List<User> GetWithRoles()
        {
            var query = @"SELECT 
                            [User].*,
                            [Role].*
                        FROM 
                            [User] 
                            LEFT JOIN [UserRole] on [UserRole].[UserId] = [User].[Id]
                            LEFT JOIN [Role] on [UserRole].[RoleId] = [Role].[Id]";
            var users = new List<User>();

            var items = _sqlConnection.Query<User,Role,User>(
                query,
                (user, role)=>
                {
                    var usr = users.FirstOrDefault(x=> x.Id == user.Id);
                    if(usr == null){
                        usr = user;
                        if(role != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);
                    return user;
                }, splitOn: "Id");

            return users;
        }
    }

}