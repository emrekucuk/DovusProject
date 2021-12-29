using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using DovusProject.Entities;

namespace DovusProject.DataAccess.Concrete.EntityFramework
{
    public class MacLoglariRepository : EfEntityRepositoryBase<MacLoglari, ProjectDbContext>, IMacLoglariRepository
    {
            public MacLoglariRepository(ProjectDbContext context) : base(context)
            {
            }
        }
}