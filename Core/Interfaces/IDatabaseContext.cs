using System;
using System.Data.SQLite;

namespace DogWalker.Core.Interfaces
{
    public interface IDatabaseContext : IDisposable
    {
        SQLiteConnection Connection { get; }
    }
}
