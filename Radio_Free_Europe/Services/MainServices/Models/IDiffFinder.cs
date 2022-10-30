using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radio_Free_Europe.Services.MainServices.Models
{
   public interface IDiffFinder
    {
        DiffResults Compute(string input1, string input2);
    }
}
