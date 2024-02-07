namespace Core
{
    public class Statement
    {
        public Statement(int balance, int amount, DateOnly date)
        {
            Balance = balance;
            Amount = amount;
            Date = date;
        }

        public int Balance { get; }
        public int Amount { get; }
        public DateOnly Date { get; }
    }
}