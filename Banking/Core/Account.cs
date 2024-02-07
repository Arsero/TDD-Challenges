namespace Core
{
    public class Account
    {
        private int _balance;
        private readonly IList<Statement> _statements;
        private readonly IStatementPrinter _statementPrinter;

        public Account(IStatementPrinter statementPrinter)
        {
            _balance = 0;
            _statements = new List<Statement>();
            _statementPrinter = statementPrinter;
        }

        public int Balance { get { return _balance; } }

        public void Deposit(int amount, DateOnly? date = null)
        {
            if(amount < 1)
                throw new InvalidAmountException();

            _balance += amount;
            _statements.Add(new Statement(_balance, amount, date ?? new DateOnly()));
        }

        public void Withdraw(int amount, DateOnly? date = null)
        {
            if (_balance < amount)
                throw new InsufficientBalanceException();

            _balance -= amount;
            _statements.Add(new Statement(_balance, amount * -1, date ?? new DateOnly()));
        }

        public string PrintStatement()
        {
            return _statementPrinter.PrintStatement(_statements);
        }
    }
}