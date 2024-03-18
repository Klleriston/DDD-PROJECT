using Application.Interface.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface INewsApplication : IGenericApplication<News>
    {
        Task AddNews(News news);
        Task UpdateNews(News news);
        Task<List<News>> GetNewsActive();
    }
}
