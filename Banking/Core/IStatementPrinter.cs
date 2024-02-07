namespace Core
{
    public interface IStatementPrinter
    {
        string PrintStatement(IList<Statement> statements);
    }
}
