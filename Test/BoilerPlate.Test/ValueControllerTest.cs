using BoilerPlate.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BoilerPlateTest.Controllers
{
    public class ValueControllerTest
    {
        [Fact]
        public void GetMethodTest()
        {
            ValuesController valueController = new ValuesController();

            Assert.Equal("value", valueController.Get(1));
        }

    }
}
