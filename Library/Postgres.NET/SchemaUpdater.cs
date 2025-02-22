﻿using System;
using Dapper;
using Npgsql;

namespace Postgres.NET
{
    public class SchemaUpdater: IDisposable
    {
        private readonly NpgsqlConnection databaseConnection;

        public SchemaUpdater(NpgsqlConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public int CreateTable(string tableName)
        {
            return databaseConnection.Execute(
                $"CREATE TABLE {tableName} ( id serial PRIMARY KEY );");
        }

        public void Dispose()
        {
            databaseConnection.Dispose();
        }
    }
}
