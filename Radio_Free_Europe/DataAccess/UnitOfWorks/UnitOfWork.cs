
using System;
using System.Threading.Tasks;

namespace Radio_Free_Europe.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DatabaseService databaseService;
        

        public UnitOfWork(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
           
        }

        public void Save()
        {
            databaseService.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await databaseService.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    databaseService.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}