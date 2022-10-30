using Radio_Free_Europe.Models;
using Radio_Free_Europe.Services.MainServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radio_Free_Europe.Services.MainServices
{
    public class MainService : IMainService
    {
        // Injecting both of the diffFinder and diffStorage as interfaces.
        //This allows having multiple implementations, for example:
        //we can have a new implementation for diffStorage which utilizes the DB for storing the diff data.
        readonly IDiffFinder diffFinder;
        readonly IDiffStorage diffStorage;
        public MainService(IDiffStorage diffStorage, IDiffFinder diffFinder)
        {
            this.diffStorage = diffStorage;
            this.diffFinder = diffFinder;
        }

        public BaseResponse setLeft(long Id, DiffData DiffData)
        {
            diffStorage.StoreLeft(Id, DiffData.Input);
            return new BaseResponse();
        }

        public BaseResponse setRight(long Id, DiffData DiffData)
        {
            diffStorage.StoreRight(Id, DiffData.Input);
            return new BaseResponse();
        }
        public BaseResponse<DiffResults> GetDiff(long Id)
        {
            var data = diffStorage.Get(Id);
            var Result = diffFinder.Compute(data.InputLeft, data.InputRight);
            return new BaseResponse<DiffResults>(Result);
        }
    }
}
