using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Mvc;

namespace HR_Example.Models
{
    public class DBHelper
    {
        private static string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        SqlConnection cn;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
        DataTable dt;


        public SqlConnection fireConnection()
        {
            cn = new SqlConnection(cs);

            return cn;
        }

        public DBHelper()
        {
            cn = fireConnection();

        }

        //-------------------------------
        // insert - update - delete - select

        public string fireSQL(string sql)
        {
            try
            {

                if (cn.State == ConnectionState.Closed) cn.Open();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                if (cmd.ExecuteScalar() != null)
                {
                    return cmd.ExecuteScalar().ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                cmd.Dispose();
            }

        }
        public DataTable FireDataTable(string sql)
        {
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                dt = new DataTable();
                SqlDataAdapter.SelectCommand = cmd;
                SqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                cmd.Dispose();
            }
        }

        public int ExecuteNonQuery(string sql, SqlParameter[] p)
        {
            SqlConnection cnn = new SqlConnection(cs);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (p != null)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }
            int e = cmd.ExecuteNonQuery();
            cnn.Close();
            return e;
        }
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }

        public SqlDataReader ExecuteReader (string sql, SqlParameter[] p)
        {
            SqlConnection cnn = new SqlConnection(cs);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (p != null)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            }
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dataReader;
        }
        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null); 
        }
        
        }
}