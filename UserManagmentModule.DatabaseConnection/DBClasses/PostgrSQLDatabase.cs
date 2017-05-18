using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentModule.DatabaseConnection.Common;

namespace UserManagmentModule.DatabaseConnection.DBClasses
{
    public class PostgrSQLDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
        public override IDbCommand CreateCommand()
        {
            return new NpgsqlCommand();
        }
        public override IDbConnection CreateOpenConnection()
        {
            NpgsqlConnection connection = (NpgsqlConnection)CreateConnection();
            connection.Open();
            return connection;
        }
        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.Text;
            return command;
        }
        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            NpgsqlCommand command = (NpgsqlCommand)CreateCommand();
            command.CommandText = procName;
            command.Connection = (NpgsqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new NpgsqlParameter(parameterName, parameterValue);
        }
    }
}
