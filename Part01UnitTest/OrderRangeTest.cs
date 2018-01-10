using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parte01;

namespace Part01UnitTest
{
    [TestClass]
    public class OrderRangeTest
    {
        [TestMethod]
        public void build()
        {

            int[] cadena = { 1,2,4,5,6,7,8,5,4,3};
            OrderRange ts = new OrderRange();
            try
            {
                // Act
                string result = ts.build(cadena);
                // Assert
                Assert.IsNotNull(result);

            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }
    }
}
