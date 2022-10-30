using NUnit.Framework;
using Radio_Free_Europe.Enums;
using Radio_Free_Europe.Services.MainServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_Free_Europe_UnitTest.Services.MainServices.Models
{
    class DiffFinderTests
    {
        [Test]
        public void GivenSameValue_whenCompare_ThenInputsAreEqualResult()
        {
            // prepare
            DiffFinder finder = new DiffFinder();
            //act
            var response = finder.Compute("Test1", "Test1");
            //check
            Assert.AreEqual(DiffStates.InputsAreEqual.ToString(), response.DiffStates);
            Assert.IsNull(response.DiffOffsets);
        }
        [Test]
        public void GivenDIfferentValueSameLength_whenCompare_ThenInputAreDifferentResult()
        {
            // prepare
            DiffFinder finder = new DiffFinder();
            //act
            var response = finder.Compute("Test1", "Test2");
            //check
            Assert.AreEqual(DiffStates.InputAreDifferent.ToString(), response.DiffStates);
            Assert.AreEqual(response.DiffOffsets, new List<long> { "Test2".IndexOf("2") });
        }
        [Test]
        public void GivenDIfferentValueSameDifferentLength_whenCompare_ThenInputsOfDifferentSizeResult()
        {
            // prepare
            DiffFinder finder = new DiffFinder();
            //act
            var response = finder.Compute("Test1", "Test12");
            //check
            Assert.AreEqual(DiffStates.InputsOfDifferentSize.ToString(), response.DiffStates);
            Assert.IsNull(response.DiffOffsets);
        }
        [Test]
        public void GivenNullValues_whenCompare_ThenInputIncompleteResult()
        {   // prepare
            DiffFinder finder = new DiffFinder();
            //act
            var response = finder.Compute(null, null);
            //check
            Assert.AreEqual(DiffStates.InputIncomplete.ToString(), response.DiffStates);
            Assert.IsNull(response.DiffOffsets);
        }
    }
}
