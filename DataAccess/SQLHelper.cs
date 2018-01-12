using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public static class SQLHelper
    {
        private static string CONNECTION_STRING = @"Server=XLLIMPE;Database=GrupoComercio;User Id=user;Password=user;";
        public static string ConnectionString { get { return CONNECTION_STRING; } }

        public static int ExecuteNonQuery(string cmdText, SqlParameter[] cmdParms)
        {
            var conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            PrepareCommand(conn, cmd, null, CommandType.Text, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            var conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            using (conn)
            {
                PrepareCommand(conn, cmd, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            var conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            PrepareCommand(conn, cmd, null, cmdType, cmdText, cmdParms);
            var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return rdr;
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            var conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = conn.CreateCommand();
            PrepareCommand(conn, cmd, null, cmdType, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        private static void PrepareCommand(SqlConnection conn, SqlCommand cmd, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] commandParameters)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (commandParameters != null)
            {
                AttachParameters(cmd, commandParameters);
            }
        }
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }
    }
}