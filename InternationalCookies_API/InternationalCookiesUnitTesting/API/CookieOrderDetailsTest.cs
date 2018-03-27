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
    [TestClass]
    public class CookieOrderDetailsTest
    {
        private Mock<ICookieOrders> _cookieOrders;
        [TestInitialize]
        public void Initialize()
        {
            _cookieOrders = new Mock<ICookieOrders>();
        }

        [TestMethod]
        public void GetCookieDetailsTest()
        {
            var controller = new CookieOrderController(_cookieOrders.Object);
            _cookieOrders.Setup(m => m.GetCookieOrderOfStore(It.IsAny<int>())).Returns(new List<CookieOrder>()
            {
                new CookieOrder() {StoreID =1, CookiesRequired=120 }
            });
            var response = controller.Get(1);
            var contentResult = response as OkNegotiatedContentResult<List<CookieOrder>>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.Exists(m => m.StoreID == 1));
        }

        [TestMethod]
        public void GetCookieDetailsNotFoundTest()
        {
            var controller = new CookieOrderController(_cookieOrders.Object);
            _cookieOrders.Setup(m => m.GetCookieOrderOfStore(It.IsAny<int>())).Returns(new List<CookieOrder>());
            var response = controller.Get(1);
            var contentResult = response as NotFoundResult;
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void PostCookieDetails()
        {
            var controller = new CookieOrderController(_cookieOrders.Object);
            bool AddCookieCalled = false;
            _cookieOrders.Setup(m => m.AddCookieOrder(It.IsAny<CookieOrder>())).Callback(() => AddCookieCalled = true);
            controller.Post(new CookieOrder());
            Assert.IsTrue(AddCookieCalled);
        }        
    }
}
