using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using DovusProject.Entities;

namespace DovusProject.DataAccess.Concrete.EntityFramework
{
    public class MacRepository : EfEntityRepositoryBase<Mac, ProjectDbContext>, IMacRepository
    {
            public MacRepository(ProjectDbContext context) : base(context)
            {
            }
        }
}