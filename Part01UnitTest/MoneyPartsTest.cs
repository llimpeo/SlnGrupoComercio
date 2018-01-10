using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parte01;

namespace Part01UnitTest
{
    [TestClass]
    public class MoneyPartsTest
    {
        [TestMethod]
        public void build()
        {

            string cadena = "0.25";
            MoneyParts ts = new MoneyParts();
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
