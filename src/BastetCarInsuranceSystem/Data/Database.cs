using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BastetCarInsuranceSystem.Data
{
    internal static class Database
    {
        private const string ConnectionName = "BastetCarInsuranceSystem.Properties.Settings.SSConnectionString";

        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionName];

                if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    throw new InvalidOperationException("The database connection string is missing from App.config.");
                }

                return settings.ConnectionString;
            }
        }

        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = OpenConnection())
            using (SqlCommand command = CreateCommand(connection, null, sql, parameters))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = OpenConnection())
            {
                return Execute(connection, null, sql, parameters);
            }
        }

        public static int Execute(SqlConnection connection, SqlTransaction transaction, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand command = CreateCommand(connection, transaction, sql, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = OpenConnection())
            {
                return Scalar(connection, null, sql, parameters);
            }
        }

        public static object Scalar(SqlConnection connection, SqlTransaction transaction, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand command = CreateCommand(connection, transaction, sql, parameters))
            {
                return command.ExecuteScalar();
            }
        }

        public static void ExecuteTransaction(Action<SqlConnection, SqlTransaction> work)
        {
            using (SqlConnection connection = OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    work(connection, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static bool EmployeeExists(int employeeId)
        {
            object result = Scalar(
                "SELECT COUNT(1) FROM EMPLOYEE WHERE EMPLOYEEID = @EmployeeID",
                Int("@EmployeeID", employeeId));

            return Convert.ToInt32(result) > 0;
        }

        public static SqlParameter Int(string name, int value)
        {
            return new SqlParameter(name, SqlDbType.Int) { Value = value };
        }

        public static SqlParameter NullableInt(string name, int? value)
        {
            return new SqlParameter(name, SqlDbType.Int)
            {
                Value = value.HasValue ? (object)value.Value : DBNull.Value
            };
        }

        public static SqlParameter Text(string name, string value)
        {
            return new SqlParameter(name, SqlDbType.VarChar)
            {
                Value = string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim()
            };
        }

        private static SqlCommand CreateCommand(SqlConnection connection, SqlTransaction transaction, string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = sql;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
            }

            return command;
        }
    }
}

