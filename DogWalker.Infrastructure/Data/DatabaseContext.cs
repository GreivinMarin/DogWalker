using DogWalker.Core.Interfaces;
using System;
using System.Data.SQLite;

namespace DogWalker.Infrastructure.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly SQLiteConnection _connection;

        public DatabaseContext(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }

        public SQLiteConnection Connection => _connection;

        public void Dispose()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
            _connection.Dispose();
        }
    }
}
