using BlogDetailsDAL;
using BlogDetailsBAL.Repository;

namespace BlogDetailsBAL.Services
{
    public class BlogRepository : GenericRepository<BlogDetailsEntities, tblBlogDetail>, IBlog
    {
    }
}
