using Domain.Interfaces;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceNews : IServiceNews
    {

        private readonly INews _Inews;

        public ServiceNews(INews inews)
        {
            _Inews = inews;
        }

        public async Task AddNews(News news)
        {
            var validateTitle = news.ValidatePropertyString(news.Title, "Titulo");
            var validateInfo = news.ValidatePropertyString(news.Info, "Info");

            if (validateInfo && validateTitle)
            {
                news.UpdateDate = DateTime.Now;
                news.SingUp = DateTime.Now;
                news.Active = true;
                await _Inews.Add(news);

            }
        }

        public async Task<List<News>> GetNewsActive()
        {
            return await _Inews.ListNews(n => n.Active);
        }

        public async Task UpdateNews(News news)
        {
            var validateTitle = news.ValidatePropertyString(news.Title, "Titulo");
            var validateInfo = news.ValidatePropertyString(news.Info, "Info");

            if (validateInfo && validateTitle)
            {
                news.UpdateDate = DateTime.Now;
                news.SingUp = DateTime.Now;
                news.Active = true;
                await _Inews.Update(news);

            }
        }
    }
}
