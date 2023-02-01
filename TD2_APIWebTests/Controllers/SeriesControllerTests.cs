using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD2_APIWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TD2_APIWeb.Models.EntityFramework;

namespace TD2_APIWeb.Controllers.Tests
{
    [TestClass()]
    public class SeriesControllerTests        
    {
        [TestInitialize]
        public void SeriesControllerInitTest()
        {
            var builder = new DbContextOptionsBuilder<Td2Context>().UseNpgsql();
            Td2Context _context = new Td2Context(builder.Options);
        }


        [TestMethod()]
        public void GetSeriesTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void GetSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetSerieTestFail()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteSerieTestFail()
        {
            Assert.Fail();
        }




        [TestMethod()]
        public void PutSerieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostSerieTest()
        {
            Assert.Fail();
        }

        
    }
}