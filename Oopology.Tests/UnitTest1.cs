using NUnit.Framework;
using Oopology.Controllers;
using Oopology.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Oopology.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Oopology.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateUserAddsAUserWhenValid()
        {
            OopologyContext oopologyContext = new OopologyContext();

            Assert.Pass();
        }
    }
}