using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;

namespace DogWalker.Infrastructure.Repositories
{
    public class BreedRepository : RepositoryBase<Breed>, IBreedRepository
    {
        public BreedRepository(IDatabaseContext context) : base(context)
        {
        }

        protected override string GetSelectAllQuery()
        {
            return "SELECT id AS Id, name AS Name FROM breed";
        }

        protected override string GetSelectByIdQuery()
        {
            return "SELECT id AS Id, name AS Name FROM breed WHERE id = @Id";
        }

        protected override string GetInsertQuery()
        {
            return "INSERT INTO breed (name) VALUES (@Name); SELECT last_insert_rowid();";
        }

        protected override string GetUpdateQuery()
        {
            return "UPDATE breed SET name = @Name WHERE id = @Id";
        }

        protected override string GetDeleteQuery()
        {
            return "DELETE FROM breed WHERE id = @Id";
        }
    }
}
