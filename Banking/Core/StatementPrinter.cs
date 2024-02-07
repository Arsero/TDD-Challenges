using System.Text;

namespace Core
{
    public class StatementPrinter : IStatementPrinter
    {
        public string PrintStatement(IList<Statement> statements)
        {
            var builder = new StringBuilder();

            builder.AppendLine("Date\t\tAmount\tBalance");
            foreach (Statement statement in statements)
            {
                builder.Append(statement.Date.ToString("dd.MM.yyyy") + "\t");
                if (statement.Amount > -1)
                    builder.Append("+");

                builder.Append(statement.Amount + "\t");
                builder.AppendLine(statement.Balance.ToString());
            }

            return builder.ToString();
        }
    }
}
