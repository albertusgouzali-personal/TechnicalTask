using ErmPowerTask.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErmPowerTask.Test
{
    [TestClass]
    public class DecimalExtensionsTest
    {
        [TestMethod]
        public void DecimalExtensions_Median_OddNumber_Valid()
        {
            decimal[] values = {
                1,2,3,4,5
            };

            var median = values.Median();

            Assert.AreEqual(3,median);

        }

        [TestMethod]
        public void DecimalExtensions_Median_EvenNumber_Valid()
        {
            decimal[] values = {
                1,2,3,4,5,6,7,8,9,10
            };

            var median = values.Median();

            Assert.AreEqual((decimal)5.5, median);
        }

        [TestMethod]
        public void DecimalExtensions_UpperLimit_20percent_Valid()
        {
            var median = (decimal) 88;

            Assert.AreEqual((decimal)105.60, median.UpperLimit(20));
        }

        [TestMethod]
        public void DecimalExtensions_LowerLimit_15percent_Valid()
        {
            var median = (decimal)77;

            Assert.AreEqual((decimal)65.45, median.LowerLimit(15));
        }
    }
}
