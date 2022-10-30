
using System.Threading.Tasks;

namespace Radio_Free_Europe.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
       
        Task SaveAsync();

        void Save();

        void Dispose();
    }
}