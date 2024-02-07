namespace Core
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base("Your balance is insufficient.")
        { 
        }
    }
}