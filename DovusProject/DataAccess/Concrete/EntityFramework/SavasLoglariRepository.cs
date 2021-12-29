using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using DovusProject.Entities;

namespace DovusProject.DataAccess.Concrete.EntityFramework
{
    public class SavasLoglariRepository : EfEntityRepositoryBase<SavasLoglari, ProjectDbContext>, ISavasLoglariRepository
    {
            public SavasLoglariRepository(ProjectDbContext context) : base(context)
            {
            }
        }
}