using StringCalculatorKata;

namespace StringCalculatorKataTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Add_EmptyString_Returns0()
        {
            //Arrange
            StringCalculator  cal = new StringCalculator();
            //ACT
            int result = cal.Add("");
            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Add_SingleNumber_ReturnSameNumbers()
        {
            //Arrange
            StringCalculator cal = new StringCalculator();
            //ACT
            int result = cal.Add("5");
            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_ThreeNumbers_ReturnSumOfNumbers()
        {
            //Arrange
            StringCalculator cal = new StringCalculator();
            //ACT
            int result = cal.Add("1,8,3");
            //Assert
            Assert.AreEqual(12, result);
        }
    }
}