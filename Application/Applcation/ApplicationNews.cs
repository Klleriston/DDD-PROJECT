using Application.Interface;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceService;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applcation
{
    public class ApplicationNews : INewsApplication
    {
        INews _Inews;
        IServiceNews _IservicesNews;

        public ApplicationNews(INews news, IServiceNews serviceNews) 
        {
            _Inews = news;
            _IservicesNews = serviceNews;
        }

        public async Task Add(News obj)
        {
            await _Inews.Add(obj);
        }

        public async Task AddNews(News news)
        {
            await _IservicesNews.AddNews(news);
        }

        public async Task Delete(News obj)
        {
            await _Inews.Delete(obj);
        }

        public async Task<List<News>> Get()
        {
            return await _Inews.Get();
        }

        public async Task<News> GetById(int Id)
        {
            return await _Inews.GetById(Id);
        }

        public async Task<List<News>> GetNewsActive()
        {
            return await _IservicesNews.GetNewsActive();
        }

        public async Task Update(News obj)
        {
            await _Inews.Update(obj);
        }

        public async Task UpdateNews(News news)
        {
            await _IservicesNews.UpdateNews(news);
        }
    }
}
