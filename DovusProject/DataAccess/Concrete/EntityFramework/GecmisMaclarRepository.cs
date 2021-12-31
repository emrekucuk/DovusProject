using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using DovusProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DovusProject.DataAccess.Concrete.EntityFramework
{
    public class GecmisMaclarRepository : EfEntityRepositoryBase<GecmisMaclar, ProjectDbContext>, IGecmisMaclarRepository
    {
        public GecmisMaclarRepository(ProjectDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<GecmisMaclar>> GetListAsync(Expression<Func<GecmisMaclar, bool>> expression = null)
        {
            return expression == null
                ? await Context.GecmisMaclar
                    .Include(x => x.Dovuscu1)
                    .Include(x => x.Dovuscu2)
                    .ToListAsync()
                : await Context.GecmisMaclar.Where(expression)
                    .Include(x => x.Dovuscu1)
                    .Include(x => x.Dovuscu2)
                    .ToListAsync();
        }

        public async Task<GecmisMaclar> GetAsync(Expression<Func<GecmisMaclar, bool>> expression = null)
        {
            return expression == null
                ? await Context.GecmisMaclar
                    .Include(x => x.Dovuscu1)
                    .Include(x => x.Dovuscu2)
                    .FirstOrDefaultAsync()
                : await Context.GecmisMaclar.Where(expression)
                    .Include(x => x.Dovuscu1)
                    .Include(x => x.Dovuscu2)
                    .FirstOrDefaultAsync();
        }
    }
}