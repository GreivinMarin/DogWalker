using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;

namespace DogWalker.Infrastructure.Repositories
{
    public class WalkRepository : RepositoryBase<Walk>, IWalkRepository
    {
        public WalkRepository(IDatabaseContext context) : base(context) { }

        protected override string GetSelectAllQuery()
        {
            return @"SELECT 
                w.id AS Id,
                w.idClient AS IdClient,
                w.idDog AS IdDog,
                c.name || ' ' || c.lastname AS ClientName,
                d.name AS DogName,
                w.date AS Date,
                w.duration AS Duration                
             FROM walk w
             INNER JOIN client c ON c.id = w.idClient
             INNER JOIN dog d ON d.id = w.idDog";
        }

        protected override string GetSelectByIdQuery()
        {
            return @"SELECT 
                w.id AS Id,
                w.idClient AS IdClient,
                w.idDog AS IdDog,
                w.date AS Date,
                w.duration AS Duration,
                c.name || ' ' || c.lastname AS ClientName,
                d.name AS DogName
             FROM walk w
             INNER JOIN client c ON c.id = w.idClient
             INNER JOIN dog d ON d.id = w.idDog
             WHERE w.id = @Id";
        }

        protected override string GetInsertQuery()
        {
            return @"INSERT INTO walk (idClient, idDog, date, duration)
                     VALUES (@IdClient, @IdDog, @Date, @Duration);
                     SELECT last_insert_rowid();";
        }

        protected override string GetUpdateQuery()
        {
            return @"UPDATE walk SET
                        idClient = @IdClient,
                        idDog = @IdDog,
                        date = @Date,
                        duration = @Duration
                     WHERE id = @Id";
        }

        protected override string GetDeleteQuery()
        {
            return "DELETE FROM walk WHERE id = @Id";
        }
    }
}
