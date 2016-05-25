﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Durados.DataAccess;

namespace Durados.Web.Mvc.Stat
{
    public abstract class Measurement
    {
        public App App { get; private set; }
        public MeasurementType MeasurementType { get; private set; }
        public Measurement(App app, MeasurementType measurementType)
        {
            MeasurementType = measurementType;
            App = app;
        }
        
        protected virtual IDbConnection GetSystemConnection(MapDataSet.durados_AppRow appRow)
        {
            SqlPersistency persistency = new SqlPersistency();
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

            persistency.SystemConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SystemMapsConnectionString"].ConnectionString;
            int systemSqlProduct = appRow.durados_SqlConnectionRowByFK_durados_App_durados_SqlConnection_System.SqlProductId;

            string connectionString = persistency.GetSystemConnection(appRow, builder).ToString();

            return SqlAccess.GetNewConnection((SqlProduct)systemSqlProduct, connectionString);

        }

        protected virtual IDbConnection GetConnection(MapDataSet.durados_AppRow appRow)
        {
            SqlPersistency persistency = new SqlPersistency();
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();

            persistency.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MapsConnectionString"].ConnectionString;
            int sqlProduct = appRow.durados_SqlConnectionRowByFK_durados_App_durados_SqlConnection.SqlProductId;

            string connectionString = persistency.GetConnection(appRow, builder).ToString();

            return SqlAccess.GetNewConnection((SqlProduct)sqlProduct, connectionString);

        }

        protected virtual IDbCommand GetSystemCommand(MapDataSet.durados_AppRow appRow)
        {
            int systemSqlProduct = appRow.durados_SqlConnectionRowByFK_durados_App_durados_SqlConnection_System.SqlProductId;

            return GetCommand(systemSqlProduct);

        }

        protected virtual IDbCommand GetCommand(MapDataSet.durados_AppRow appRow)
        {
            int sqlProduct = appRow.durados_SqlConnectionRowByFK_durados_App_durados_SqlConnection.SqlProductId;

            return GetCommand(sqlProduct);
        }

        protected virtual IDbCommand GetCommand(int sqlProduct)
        {
            
            switch ((SqlProduct)sqlProduct)
            {
                case SqlProduct.MySql:
                    return new MySql.Data.MySqlClient.MySqlCommand();

                case SqlProduct.SqlServer:
                    return new System.Data.SqlClient.SqlCommand();

                case SqlProduct.Postgre:
                    return new Npgsql.NpgsqlCommand();

                case SqlProduct.Oracle:
                    return new Oracle.ManagedDataAccess.Client.OracleCommand();

                default:
                    return null;
            }

        }

        protected virtual SqlSchema GetSchema(SqlProduct sqlProduct)
        {

            switch (sqlProduct)
            {
                case SqlProduct.MySql:
                    return new MySqlSchema();

                case SqlProduct.SqlServer:
                    return new SqlSchema();

                case SqlProduct.Postgre:
                    return new PostgreSchema();

                case SqlProduct.Oracle:
                    return new OracleSchema();

                default:
                    return null;
            }

        }

        protected virtual ISqlTextBuilder GetSqlTextBuilder(SqlProduct sqlProduct)
        {
            switch (sqlProduct)
            {
                case SqlProduct.MySql:
                    return new MySqlTextBuilder();

                case SqlProduct.SqlServer:
                    return new SqlTextBuilder();

                default:
                    return null;
            }

        }

        public virtual void Persist(DateTime date, object value, SqlCommand command)
        {
            int sqlConnId = App.GetAppRow().durados_SqlConnectionRowByFK_durados_App_durados_SqlConnection_System.Id;
                
            command.CommandText = "select Id from modubiz_LogStats2 with(nolock) where SqlConId = @SqlConId and LogDate = @LogDate";
            command.Parameters.AddWithValue("SqlConId", sqlConnId);
            command.Parameters.AddWithValue("LogDate", date);
            object scalar = command.ExecuteScalar();
            if (scalar == null || scalar == DBNull.Value)
            {
                command.CommandText = "insert into modubiz_LogStats2 (SqlConId, LogDate) values (@SqlConId, @LogDate); SELECT IDENT_CURRENT(N'[modubiz_LogStats2]') AS ID; ";
                scalar = command.ExecuteScalar();

            }

            
            command.Parameters.Clear();
            command.CommandText = "update modubiz_LogStats2 set " + MeasurementType.ToString() + " = @value where Id = @Id";
            command.Parameters.AddWithValue("value", value is ulong ? System.Convert.ToInt64(value) : value);
            command.Parameters.AddWithValue("Id", scalar);
            command.ExecuteNonQuery();


        }

        

        protected virtual MapDataSet.durados_AppRow GetAppRow()
        {
            return App.GetAppRow();
        }

        protected virtual string GetSql(SqlProduct sqlProduct)
        {
            return null;
        }

        public virtual object Get(DateTime date)
        {

            var appRow = GetAppRow();
            int systemSqlProduct = appRow.durados_SqlConnectionRowByFK_durados_App_durados_SqlConnection_System.SqlProductId;
            object value = null;

            using (IDbConnection connection = GetSystemConnection(appRow))
            {
                connection.Open();
                using (IDbCommand command = GetSystemCommand(appRow))
                {
                    command.Connection = connection;
                    command.CommandText = GetSql((SqlProduct)systemSqlProduct);
                    value = command.ExecuteScalar();
                }
                connection.Close();
                connection.Dispose();
            }

            return value;
        }

    }
}
