using Moq;
using NUnit.Framework;
using Radio_Free_Europe.Models;
using Radio_Free_Europe.Services.MainServices;
using Radio_Free_Europe.Services.MainServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radio_Free_Europe_UnitTest.Services.MainServices
{
    class MainServiceTests
    {
        [Test]
        public void GivenLeftValue_WhenSetLeft_ThenStorageIsCallded()
        {
            // prepare
            string LeftInput = "LeftData";
            long id = 1;
            Mock<IDiffStorage> diffStorage =new  Mock<IDiffStorage>();
            Mock<DiffFinder> diffFinder = new Mock<DiffFinder>();
            //act
            MainService service = new MainService(diffStorage.Object, diffFinder.Object);
            //check
            service.setLeft(id, new DiffData { Input = LeftInput });
            diffStorage.Verify(x => x.StoreLeft(id, LeftInput), Times.Once());
           
        }
        [Test]
        public void GivenRightValue_WhenSetRight_ThenStorageIsCallded()
        {
            // prepare
            string RightInput = "RightData";
            long id = 1;
            Mock<IDiffStorage> diffStorage = new Mock<IDiffStorage>();
            Mock<DiffFinder> diffFinder = new Mock<DiffFinder>();
            //act
            MainService service = new MainService(diffStorage.Object, diffFinder.Object);
            //check
            service.setRight(id, new DiffData { Input = RightInput });
            diffStorage.Verify(x => x.StoreRight(id, RightInput), Times.Once());

        }
        [Test]
        public void GivenId_WhenGetDiff_ThenDiffFinderIsCalled()
        {
            // prepare
            long id = 1;
            string LeftInput = "left";
            string RightInput = "right";
            var DiffResult = new DiffResults
            {
                DiffStates = Radio_Free_Europe.Enums.DiffStates.InputIncomplete.ToString(),
                DiffOffsets = null
            };
            Mock <IDiffStorage> diffStorage = new Mock<IDiffStorage>();
            Mock<IDiffFinder> diffFinder = new Mock<IDiffFinder>();
            diffStorage.Setup(x => x.Get(id)).Returns(new DIffRecord { InputLeft = LeftInput, InputRight = RightInput });
            diffFinder.Setup(x => x.Compute(LeftInput, RightInput)).Returns(DiffResult);

            //act
            MainService service = new MainService(diffStorage.Object, diffFinder.Object);

            //check
            var result = service.GetDiff(id);
            var expected = new BaseResponse<DiffResults>(DiffResult);
            Assert.AreEqual(expected.Data, result.Data);
            Assert.AreEqual(expected.ErrorCode, result.ErrorCode);
            Assert.AreEqual(expected.ErrorMessage, result.ErrorMessage);
        }
    }
}
