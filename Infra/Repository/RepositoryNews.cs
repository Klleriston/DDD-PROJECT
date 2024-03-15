using Domain.Interfaces;
using Entities.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryNews : RepositoryGeneric<News>, INews
    {
        private readonly DbContextOptions<ContextDb> _OptionsBuilder;
        public RepositoryNews()
        {
            _OptionsBuilder = new DbContextOptions<ContextDb>();
        }

        public async Task<List<News>> ListNews(Expression<Func<News, bool>> exNews)
        {
           using (var data = new ContextDb(_OptionsBuilder))
            {
                return await data.News.Where(exNews).AsNoTracking().ToListAsync();
            }
        }
    }
}
