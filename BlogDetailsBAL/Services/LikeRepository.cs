using BlogDetailsDAL;
using BlogDetailsBAL.Repository;

namespace BlogDetailsBAL.Services
{
    public class LikeRepository : GenericRepository<BlogDetailsEntities, tblLikeDetail>, ILikeDetails
    {
    }
}
