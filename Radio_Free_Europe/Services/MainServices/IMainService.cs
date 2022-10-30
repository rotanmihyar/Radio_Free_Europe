using Radio_Free_Europe.Models;
using Radio_Free_Europe.Services.MainServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radio_Free_Europe.Services.MainServices
{
  public interface IMainService
    {
        BaseResponse setLeft(long Id,DiffData diffData);
        BaseResponse setRight(long Id, DiffData diffData);
        BaseResponse<DiffResults> GetDiff(long Id);
    }
}
