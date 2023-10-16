using Npgsql;
using models;
using services;

namespace services
{
    public interface DatabaseExecutor
    {
        Task<T?> ExecuteQuery<T, D>(
            string query, List<D>? parameters = null
        ) where T : class;
    }
}
