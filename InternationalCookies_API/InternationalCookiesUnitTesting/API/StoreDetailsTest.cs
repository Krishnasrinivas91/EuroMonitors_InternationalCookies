using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InternationalCookies_API.Controllers;
using InternationalCookies_DAL.Interfaces;
using InternationalCookies_DAL;
using System.Web.Http;
using System.Web.Http.Results;

namespace InternationalCookiesUnitTesting.API
{
    /// <summary>
    /// Summary description for StoreDetailsTest
    /// </summary>
    [TestClass]
    public class StoreDetailsTest
    {
        private Mock<IStoreDetails> _moqStoreDetails;
        [TestInitialize]
        public void TestIntialize()
        {
            _moqStoreDetails = new Mock<IStoreDetails>();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetStoreDetails()
        {
            var controller = new StoreDetailsController(_moqStoreDetails.Object);
            _moqStoreDetails.Setup(m => m.GetStoreDetails())
                .Returns(new List<StoreDetail>()
                { new StoreDetail { StoreID = 1, StoreLocation = "UK", StoreName="Tesco"} });
            var response = controller.Get();
            var contentResult = response as OkNegotiatedContentResult<List<StoreDetail>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count, 1);
        }

        [TestMethod]
        public void GetStoreDetailsNotFound()
        {
            var controller = new StoreDetailsController(_moqStoreDetails.Object);
            _moqStoreDetails.Setup(m => m.GetStoreDetails())
                .Returns(new List<StoreDetail>());
            var response = controller.Get();
            var contentResult = response as NotFoundResult;
            Assert.IsNotNull(contentResult);            
        }

        [TestMethod]
        public void GetStoreDetail()
        {
            var controller = new StoreDetailsController(_moqStoreDetails.Object);
            _moqStoreDetails.Setup(m => m.GetStoreDetail(It.IsAny<int>()))
                .Returns( new StoreDetail { StoreID = 1, StoreLocation = "UK", StoreName="Tesco"});
            var response = controller.Get(1);
            var contentResult = response as OkNegotiatedContentResult<StoreDetail>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.StoreID);
        }

        [TestMethod]
        public void GetStoreDetailNotFound()
        {
            var controller = new StoreDetailsController(_moqStoreDetails.Object);
            _moqStoreDetails.Setup(m => m.GetStoreDetail(It.IsAny<int>()));
            var response = controller.Get(1);
            var contentResult = response as NotFoundResult;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void PostStoreDetails()
        {
            var controller = new StoreDetailsController(_moqStoreDetails.Object);
            bool isPostCalled = false;
            _moqStoreDetails.Setup(m => m.AddStoreDetails(It.IsAny<StoreDetail>())).Callback(() => isPostCalled = true);
            controller.Post(new StoreDetail());
            Assert.IsTrue(isPostCalled);
        }
    }
}
