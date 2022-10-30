using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radio_Free_Europe.Services.MainServices.Models
{
    public class DiffFinder: IDiffFinder
    {   
         /// <summary>
        /// this function will do couple of checks before it's call ComputeOfsets
        /// first check , make sure the inputs are not null
        /// second check, make sure inputs are the same length
        /// third check, input are not the same
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>

        public DiffResults Compute(string input1, string input2)
        {
            DiffResults output = new DiffResults();
            if (input1 == null || input2 == null)
            {
                output.DiffStates = Enums.DiffStates.InputIncomplete.ToString();
            }
            else
            if (input1.Length != input2.Length)
            {
                output.DiffStates = Enums.DiffStates.InputsOfDifferentSize.ToString();
            }
            else
            if (input2 == input1)
            {
                output.DiffStates = Enums.DiffStates.InputsAreEqual.ToString();
            }
            else
            {
                output.DiffOffsets = ComputeOfsets(input1, input2);
                output.DiffStates = Enums.DiffStates.InputAreDifferent.ToString();
            }
            return output;
        }
        /// compute of sets will save all the indexes of different inputs and add them to the list
        private List<int> ComputeOfsets(string input1, string input2)
        {
            List<int> offsets = new List<int>();
            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != input2[i])
                {
                    offsets.Add(i);
                }
            }
            return offsets;
        }
    }
}
