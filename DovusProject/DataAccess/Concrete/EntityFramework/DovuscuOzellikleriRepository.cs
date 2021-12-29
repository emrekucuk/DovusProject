using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using DovusProject.Entities;

namespace DovusProject.DataAccess.Concrete.EntityFramework
{
    public class DovuscuOzellikleriRepository : EfEntityRepositoryBase<DovuscuOzellikleri, ProjectDbContext>, IDovuscuOzellikleriRepository
        {
            public DovuscuOzellikleriRepository(ProjectDbContext context) : base(context)
            {
            }
        }
}