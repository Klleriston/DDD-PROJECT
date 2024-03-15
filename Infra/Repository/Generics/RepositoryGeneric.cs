using Domain.Interfaces.Generics;
using Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Generics
{
    public class RepositoryGeneric<T> : IGenerics<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextDb> _OptionsBuilder;

        public RepositoryGeneric() 
        {
           _OptionsBuilder = new DbContextOptions<ContextDb>();
        }
        public async Task Add(T obj)
        {
            using (var data = new ContextDb(_OptionsBuilder))
            {
                await data.AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var data = new ContextDb(_OptionsBuilder))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> Get()
        {
            using (var data = new ContextDb(_OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> GetById(int Id)
        {
            using (var data = new ContextDb(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task Update(T obj)
        {
            using (var data = new ContextDb(_OptionsBuilder))
            {
                data.Update(obj);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion

    }
}
