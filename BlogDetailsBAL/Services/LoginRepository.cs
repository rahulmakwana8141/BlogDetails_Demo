using BlogDetailsDAL;
using BlogDetailsBAL.Repository;

namespace BlogDetailsBAL.Services
{
    public class LoginRepository : GenericRepository<BlogDetailsEntities, tblLoginDetail>, ILogin
    {
    }
}