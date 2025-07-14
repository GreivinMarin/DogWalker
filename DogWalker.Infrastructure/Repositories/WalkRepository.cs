using Dapper;
using DogWalker.Core.Classes;
using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;
using System;
using System.Collections.Generic;

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

        protected override string SearchAsyncQuery(object searchCriteria)                                  
        {
            var criteria = searchCriteria as WalkSearchCriteria;
            if (criteria == null)
                throw new ArgumentException("Invalid search criteria for WalkRepository");

            var sql = @"
                SELECT 
                    w.id AS Id,
                    w.date AS Date,
                    w.duration AS Duration,
                    c.name || ' ' || c.lastname AS ClientName,
                    d.name AS DogName
                FROM walk w
                INNER JOIN client c ON w.idClient = c.id
                INNER JOIN dog d ON w.idDog = d.id
                WHERE 1=1
            ";

            var parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(criteria.ClientName))
            {
                sql += " AND (c.name || ' ' || c.lastname) LIKE @ClientName";
                parameters.Add("@ClientName", $"%{criteria.ClientName}%");
            }

            if (!string.IsNullOrWhiteSpace(criteria.DogName))
            {
                sql += " AND d.name LIKE @DogName";
                parameters.Add("@DogName", $"%{criteria.DogName}%");
            }

            if (criteria.FromDate.HasValue)
            {
                sql += " AND date(w.date) >= date(@FromDate)";
                parameters.Add("@FromDate", criteria.FromDate.Value.ToString("yyyy-MM-dd"));
            }

            if (criteria.ToDate.HasValue)
            {
                sql += " AND date(w.date) <= date(@ToDate)";
                parameters.Add("@ToDate", criteria.ToDate.Value.ToString("yyyy-MM-dd"));
            }

            return sql;
        }
    }
}
