using DiscountDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDiscountDll
{
    [TestClass]
    public class UnitTestDiscountCalculation
    {
        [TestMethod]
        public void Check_3_Book_1250_Cost()
        {
            int result = 7;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(3, 1250);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Check_5_Book_1670_Cost()
        {
            int result = 13;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(5, 1670);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Check_15_Book_2780_Cost()
        {
            int result = 20;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(15, 2780);

            Assert.AreEqual(result, actual);
        }


        [TestMethod]
        public void WrongBookCount()
        {
            int result = -1;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(-2, 2780);

            Assert.AreEqual(result, actual);
        }


        [TestMethod]
        public void WrongCost()
        {
            int result = -1;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(7, -1250);

            Assert.AreEqual(result, actual);
        }
    }
}
