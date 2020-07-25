namespace TheURLShortener.DatabaseLayer
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
