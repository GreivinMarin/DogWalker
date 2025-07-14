using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;

namespace DogWalker.Infrastructure.Repositories
{
    public class DogRepository : RepositoryBase<Dog>, IDogRepository
    {
        public DogRepository(IDatabaseContext context) : base(context) { }

        protected override string GetSelectAllQuery()
        {
            return @"SELECT 
                        id AS Id,
                        name AS Name,
                        birthDate AS BirthDate,
                        idBreed AS IdBreed
                     FROM dog";
        }

        protected override string GetSelectByIdQuery()
        {
            return @"SELECT 
                        id AS Id,
                        name AS Name,
                        birthDate AS BirthDate,
                        idBreed AS IdBreed
                     FROM dog WHERE id = @Id";
        }

        protected override string GetInsertQuery()
        {
            return @"INSERT INTO dog (name, birthDate, idBreed)
                     VALUES (@Name, @BirthDate, @IdBreed);
                     SELECT last_insert_rowid();";
        }

        protected override string GetUpdateQuery()
        {
            return @"UPDATE dog SET
                        name = @Name,
                        birthDate = @BirthDate,
                        idBreed = @IdBreed
                     WHERE id = @Id";
        }

        protected override string GetDeleteQuery()
        {
            return "DELETE FROM dog WHERE id = @Id";
        }

        protected override string SearchAsyncQuery(object searchCriteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
