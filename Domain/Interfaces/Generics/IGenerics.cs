using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGenerics<T> where T : class
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task<T> GetById(int Id);
        Task<List<T>> Get();
    }
}
