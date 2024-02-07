namespace Core
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException() : base("Your amount must be greater than 0.")
        {
            
        }
    }
}