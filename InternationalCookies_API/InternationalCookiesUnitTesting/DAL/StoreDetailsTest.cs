using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using InternationalCookies_DAL;
using InternationalCookies_DAL.Implementation;

namespace InternationalCookiesUnitTesting.DAL
{
    /// <summary>
    /// Summary description for StoreDetailsTest
    /// </summary>
    [TestClass]
    public class StoreDetailsTest
    {
        private readonly Mock<CookieStoreDBContext> context;
        public StoreDetailsTest()
        {
            context = new Mock<CookieStoreDBContext>();
            
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
        public void AddStoreDetailsTest()
        {
            int callCount = 0;
            int addStore = 0;
            int saveChanges = 0;
            var storeMock = new Mock<DbSet<StoreDetail>>();
            context.Setup(m => m.StoreDetails).Returns(storeMock.Object);

            context.Setup(m => m.StoreDetails.Add(It.IsAny<StoreDetail>())).Callback(() => addStore = callCount++);
            context.Setup(m => m.SaveChanges()).Callback(() => saveChanges = callCount++);

            var TestAddStore = new StoreDetailsImplementation();
            //storeMock.Verify(m => m.Add(It.IsAny<StoreDetail>()), Times.Once());
            StoreDetail storeDetails = new StoreDetail()
            {
                StoreID = 1,
                StoreLocation = "United Kingdom",
                StoreName = "Sainsbury's"
            };
            TestAddStore.AddStoreDetails(storeDetails);
            context.Verify(m => m.StoreDetails.Add(It.IsAny<StoreDetail>()), Times.Once);
            context.Verify(m => m.SaveChanges(), Times.Once);

            Assert.AreEqual(0, addStore);
            Assert.AreEqual(1, saveChanges);
        }
    }
}
