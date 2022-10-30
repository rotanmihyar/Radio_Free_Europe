

namespace Radio_Free_Europe.Services.MainServices.Models
{
    public interface IDiffStorage
    {
        public void StoreLeft(long Id, string Input);
        public void StoreRight(long Id, string Input);
        public DIffRecord Get(long Id);
    }
}
