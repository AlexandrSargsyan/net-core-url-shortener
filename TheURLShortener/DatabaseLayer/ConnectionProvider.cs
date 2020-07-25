using Microsoft.Extensions.Configuration;

namespace TheURLShortener.DatabaseLayer
{
    public class ConnectionProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration["ConnectionString"];
    }
}
