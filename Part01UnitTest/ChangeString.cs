using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parte01;

namespace Part01UnitTest
{
    [TestClass]
    public class ChangeStringTest
    {
        [TestMethod]
        public void build()
        {

            string cadena = "244434 bchksthk ZdA 7778";
            ChangeString ts = new ChangeString();
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
