using Radio_Free_Europe.Services.MainServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radio_Free_Europe.Services.MainServices.Models
{

    /**
     * This class utilises the Local storage to store the diff data in a dictionary
     * Advantages:
     * - Simple
     * - Very Fast
     * - Easy To Implement
     * Limitations:
     * - At the moment, the data lives forever (as long as the service is running)
     * - There is a risk of race condition
     * - All data lives in the memory
     */
    public class LocalDiffStorage : IDiffStorage
    {
        private Dictionary<long, DIffRecord> Records = new Dictionary<long, DIffRecord>();
        public DIffRecord Get(long Id)
        {
            return Records.GetValueOrDefault(Id, new DIffRecord());
        }

        public void StoreLeft(long Id, string Input)
        {
            var rec = Get(Id);
            rec.InputLeft = Input;
            Records[Id] = rec;
        }

        public void StoreRight(long Id, string Input)
        {
            var rec = Get(Id);
            rec.InputRight = Input;
            Records[Id] = rec;
        }
    }
}
