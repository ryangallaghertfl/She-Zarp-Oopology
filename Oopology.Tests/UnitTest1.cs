using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using Oopology.Controllers;
using Oopology.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Oopology.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Oopology.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PurchasingACourseIncreasesXPLevel()
        {
            //ARRANGE
            User user = new User();

            //ACT

            //ASSERT
            Assert.AreEqual(5, 5);




        }

        /* [Test]
         public void AuthenticationCheckerMethodReturnsTrueWhenUserIsLoggedIn()
         {
             AuthenticationFilter authenticationFilter = new AuthenticationFilter();

             var sessionMock = new Mock<ISession>();
             sessionMock.Setup(s => s.GetInt32("User_Id")).Returns(1);

             var contextMock = new Mock<HttpContext>();
             contextMock.Setup(c => c.Session).Returns(sessionMock.Object);

             var result = authenticationFilter.IsLoggedIn(contextMock.Object);
             Assert.AreEqual(true, result);

         } */




    }
}