using NUnit.Framework;
using Radio_Free_Europe.Services.MainServices.Models;

namespace Radio_Free_Europe_UnitTest
{
    public class LocalDiffStorageTests
    {
       
        [Test]
        public void GivenLeftInput_WhenGet_ThenOnlyLeftPresent()
        {

            string Input = "ratan";
            long Id = 1;
            LocalDiffStorage Storage = new LocalDiffStorage();
            Storage.StoreLeft(Id, Input);
            var data = Storage.Get(Id);


            Assert.AreEqual(Input, data.InputLeft);
            Assert.AreEqual(null, data.InputRight);

        }
        [Test]
        public void GivenRightInput_WhenGet_ThenOnlyRightPresent()
        {

            string Input = "ratan";
            long Id = 1;
            LocalDiffStorage Storage = new LocalDiffStorage();
            Storage.StoreRight(Id, Input);
            var data = Storage.Get(Id);


            Assert.AreEqual(Input, data.InputRight);
            Assert.AreEqual(null, data.InputLeft);

        }
        [Test]
        public void GivenBothInput_WhenGet_ThenBothArePresent()
        {


            string left = "VALUE1";
            string right = "VALUE2";
            long Id = 1;
            LocalDiffStorage Storage = new LocalDiffStorage();
            Storage.StoreRight(Id, right);
            Storage.StoreLeft(Id, left);
            var data = Storage.Get(Id);


            Assert.AreEqual(right, data.InputRight);
            Assert.AreEqual(left, data.InputLeft);

        }
        [Test]
        public void GiveNoneExistingId_WhenGetValue_ThenReturnDefaultObject()
        {
    
            long Id = 5;
            LocalDiffStorage Storage = new LocalDiffStorage(); 
            var data = Storage.Get(Id);
            Assert.AreEqual(null, data.InputRight);
            Assert.AreEqual(null, data.InputLeft);

        }
        [Test]
        public void GivenMultibleRecords_WhenGetValue_ThenALLObjectsAreStored()
        {

            long FirstId = 1;
            long SecondId = 2;
            string FirstLeft = "FirstLeft";
            string SecondLeft = "SecondLeft";
            LocalDiffStorage Storage = new LocalDiffStorage();
            Storage.StoreLeft(FirstId, FirstLeft);
            Storage.StoreLeft(SecondId, SecondLeft);
            var FirstData = Storage.Get(FirstId);
            var SecondData = Storage.Get(SecondId);
            Assert.AreEqual(FirstLeft, FirstData.InputLeft);
            Assert.AreEqual(SecondLeft, SecondData.InputLeft);

        }
    }
}