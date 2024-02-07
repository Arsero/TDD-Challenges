using Core;

namespace BankingTest
{
    public class AccountTest
    {
        private readonly Account account;
        private readonly IStatementPrinter printer;
        public AccountTest()
        {
            printer = new StatementPrinter();
            account = new Account(printer);
        }

        [Fact]
        public void NewAccount_ShouldBalanceZero()
        {
            account.Balance.Should().Be(0);
        }

        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            account.Deposit(500);
            account.Balance.Should().Be(500);
        }

        [Fact]
        public void Withdraw_ShouldThrowException_WhenInsufficientBalance()
        {
            Action act = () => account.Withdraw(100);

            var exception = Assert.Throws<InsufficientBalanceException>(act);
            Assert.Equal("Your balance is insufficient.", exception.Message);
        }

        [Fact]
        public void DepositAndWithdraw_ShoudBalanceZero()
        {
            account.Deposit(100);
            account.Withdraw(100);

            account.Balance.Should().Be(0);
        }

        [Fact]
        public void PrintStatement_ShouldDisplayDateAmountAndBalance()
        {
            account.Deposit(500, new DateOnly(2015, 12, 24));
            account.Withdraw(100, new DateOnly(2016, 8, 23));

            account.PrintStatement().Should().ContainAll(
                "Date\t\tAmount\tBalance",
                "24.12.2015\t+500\t500",
                "23.08.2016\t-100\t400");
        }

        [Fact]
        public void Deposit_ShouldThrowException_WhenAmountLessOne()
        {
            Action act = () => account.Deposit(0);

            act.Should()
                .Throw<InvalidAmountException>()
                .Which.Message
                .Should()
                .Be("Your amount must be greater than 0.");
        }
    }
}
