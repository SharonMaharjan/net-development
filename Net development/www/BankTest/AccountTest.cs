using Bank;
using static Bank.Account;

namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {

            //Arrange (Initial data)
            Account account = new Account();
            //Act (method call)
            double balance = account.Balance;
            //Assert (test the result is as expected)
            Assert.AreEqual(0, balance);

        }
        [TestMethod]
        public void Credit_999OnBalance0_Returns999()
        {
            // ARRANGE
            Account account = new Account();

            // ACT
            account.Credit(999);

            // ASSERT

            Assert.AreEqual(999, account.Balance);

        }
        [TestMethod]
        public void Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            // ARRANGE
            Account account = new Account();
            // ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(
          () => account.Credit(-200) // ACT
            );
        }

        public void Debit_500FromBalance500_Returns0()
        {
            // ARRANGE
            Account account = new Account();

            // ACT
            account.Credit(500);
            account.Debit(500);
            // ASSERT
            Assert.AreEqual(500, account.Balance);

        }

        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            //Arrange
            Account account = new Account();
            account.Credit(200);
            //Assert
            Assert.ThrowsException<BalanceInsufficientException>(() => account.Debit(500));//Act
        }
    }
}