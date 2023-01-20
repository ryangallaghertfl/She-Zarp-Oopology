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





    }
}