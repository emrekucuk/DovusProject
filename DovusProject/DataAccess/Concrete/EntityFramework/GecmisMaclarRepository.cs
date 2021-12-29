using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using DovusProject.Entities;

namespace DovusProject.DataAccess.Concrete.EntityFramework
{
    public class GecmisMaclarRepository : EfEntityRepositoryBase<GecmisMaclar, ProjectDbContext>, IGecmisMaclarRepository
    {
            public GecmisMaclarRepository(ProjectDbContext context) : base(context)
            {
            }
        }
}