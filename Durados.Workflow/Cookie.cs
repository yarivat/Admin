﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backand
{
    public class Cookie : ICookie
    {
        public object get(string key)
        {
            return Database.Read(key);
        }
        public void put(string key, object value)
        {
            Database.CreateOrUpdate(key, value.ToString());
        }
        public void remove(string key)
        {
            Database.Delete(key);
        }
    }

    internal class Database
    {
        internal static object Read(string key)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Durados.Workflow.JavaScript.GetCacheInCurrentRequest(Durados.Workflow.JavaScript.ConnectionStringKey).ToString()))
            {
                connection.Open();
                string sql = string.Format("select scalar from durados_session where sessionId = '{0}' and [name] = '{1}'", key, System.Web.HttpContext.Current.Items[Durados.Database.Username].ToString());
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, connection))
                {
                    object scalar = command.ExecuteScalar();
                    if (scalar == null || scalar == DBNull.Value)
                        return null;
                    else
                        return scalar.ToString();
                }
            }
        }

        internal static void Update(string key, object value)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Durados.Workflow.JavaScript.GetCacheInCurrentRequest(Durados.Workflow.JavaScript.ConnectionStringKey).ToString()))
            {
                connection.Open();
                string sql = string.Format("update durados_session set scalar = '{1}' where sessionId = '{0}' and [name] = '{2}'", key, value, System.Web.HttpContext.Current.Items[Durados.Database.Username].ToString());
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        internal static void Create(string key, object value)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Durados.Workflow.JavaScript.GetCacheInCurrentRequest(Durados.Workflow.JavaScript.ConnectionStringKey).ToString()))
            {
                connection.Open();
                string sql = string.Format("insert into durados_session (sessionId, [name], scalar, TypeCode) values('{0}','{2}','{1}','String')", key, value, System.Web.HttpContext.Current.Items[Durados.Database.Username].ToString());
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CreateOrUpdate(string key, object value)
        {
            if (Read(key) == null)
            {
                Create(key, value);
            }
            else
            {
                Update(key, value);
            }

        }

        public static void Delete(string key)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(Durados.Workflow.JavaScript.GetCacheInCurrentRequest(Durados.Workflow.JavaScript.ConnectionStringKey).ToString()))
            {
                connection.Open();
                string sql = string.Format("delete durados_session where sessionId = '{0}' and [name] = '{1}'", key, System.Web.HttpContext.Current.Items[Durados.Database.Username].ToString());
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public interface ICookie
    {
        object get(string key);
        void put(string key, object value);
        void remove(string key);
    }

    public class Convert
    {
        public static string btoa(string text)
        {
            return System.Convert.ToBase64String(Encoding.Default.GetBytes(text));
        }
    }
}
