using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;

namespace DogWalker.Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IDatabaseContext context) : base(context)
        {
        }

        protected override string GetSelectAllQuery()
        {
            return @"SELECT 
                        id AS Id, 
                        name AS Name, 
                        lastname AS LastName, 
                        identification AS Identification, 
                        phone AS Phone 
                     FROM client";
        }

        protected override string GetSelectByIdQuery()
        {
            return @"SELECT 
                        id AS Id, 
                        name AS Name, 
                        lastname AS LastName, 
                        identification AS Identification, 
                        phone AS Phone 
                     FROM client 
                     WHERE id = @Id";
        }

        protected override string GetInsertQuery()
        {
            return @"INSERT INTO client (name, lastname, identification, phone) 
                     VALUES (@Name, @LastName, @Identification, @Phone); 
                     SELECT last_insert_rowid();";
        }

        protected override string GetUpdateQuery()
        {
            return @"UPDATE client 
                     SET name = @Name, 
                         lastname = @LastName, 
                         identification = @Identification, 
                         phone = @Phone 
                     WHERE id = @Id";
        }

        protected override string GetDeleteQuery()
        {
            return @"DELETE FROM client WHERE id = @Id";
        }

        protected override (string, Dapper.DynamicParameters) SearchAsyncQuery(object searchCriteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
