using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Configuration;
 
/// <summary>
/// Summary description for clsDB
/// </summary>
public class clsDB
{

    private string ConnectionString;

    private string strError;
    SqlConnection connection = new SqlConnection();
    SqlTransaction Txn = null;

    string errorMsg = "";
    bool _beginTxn = false;
    public bool OpenConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection = null;
                connection = new SqlConnection();
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();




            }

            return true;
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            return false;
        }
    }


    public bool BeginTransation()
    {
        try
        {
            Txn = connection.BeginTransaction();
            _beginTxn = true;
            return true;
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            return false;
        }
    }

    public bool CommitTransaction()
    {
        try
        {
            if (Txn != null)
            {
                Txn.Commit();
            }
            return true;
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            if (_beginTxn)
                RollBackTransaction();
            return false;
        }
    }

    public bool RollBackTransaction()
    {
        try
        {
            if (Txn != null)
            {
                Txn.Rollback();
            }
            _beginTxn = false;

            return true;
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            return false;
        }
    }

    public bool Execute(string SQL, ref DataTable DT)
    {
        bool bRetVal = false;
        SqlDataAdapter adapter = default(SqlDataAdapter);
        SqlCommand CMD = default(SqlCommand);

        try
        {
            bRetVal = false;
            if (!OpenConnection())
            {
                return false;
            }

            //check data exsist

            DataSet d = new DataSet();
            Execute(SQL, ref d);

            if (d.Tables[0].Rows.Count > 0)
            {
                CMD = new SqlCommand(SQL, connection);

                if (Txn != null)
                {
                    CMD.Transaction = Txn;
                }

                adapter = new SqlDataAdapter(CMD);
                adapter.SelectCommand.CommandTimeout = 300;

                adapter.Fill(DT);
            }
            else
            {
                DT = new DataTable();
            }
            ////////////


            bRetVal = true;

        }
        catch (Exception ex)
        {
            strError = ex.Message;
            if (_beginTxn)
                RollBackTransaction();
        }

        return bRetVal;
    }

    public bool Execute(string SQL, ref DataSet DT)
    {
        bool bRetVal = false;
        SqlDataAdapter adapter = default(SqlDataAdapter);
        SqlCommand CMD = default(SqlCommand);

        try
        {
            bRetVal = false;
            if (!OpenConnection())
            {
                return false;
            }

            CMD = new SqlCommand(SQL, connection);

            if (Txn != null)
            {
                CMD.Transaction = Txn;
            }

            adapter = new SqlDataAdapter(CMD);
            adapter.SelectCommand.CommandTimeout = 300;

            adapter.Fill(DT);

            bRetVal = true;

        }
        catch (Exception ex)
        {
            strError = ex.Message;
            if (_beginTxn)
                RollBackTransaction();
        }

        return bRetVal;
    }
    public bool Execute(string SQL)
    {
        
        bool bRetVal = false;
        SqlCommand CMD = default(SqlCommand);

        try
        {
            bRetVal = false;
            if (!OpenConnection())
            {
                return false;
            }

            CMD = new SqlCommand(SQL, connection);
            CMD.ExecuteScalar();
            bRetVal = true;

        }
        catch (SqlException sqlex)
        {
            string errorMsg = "_";
            int ecode = Convert.ToInt32(sqlex.ErrorCode.ToString());

           
            strError = errorMsg;
        }
        catch (Exception ex)
        {
            strError = ex.Message;
        }

        return bRetVal;
    }

    public bool Execute(string SQL, ref int rowCount)
    {
        bool bRetVal = false;
        SqlDataAdapter adapter = default(SqlDataAdapter);
        SqlCommand CMD = default(SqlCommand);

        try
        {
            bRetVal = false;
            if (!OpenConnection())
            {
                return false;
            }

            CMD = new SqlCommand(SQL, connection);

            if (Txn != null)
            {
                CMD.Transaction = Txn;
            }

            adapter = new SqlDataAdapter(CMD);
            adapter.SelectCommand.CommandTimeout = 300;
            DataSet DT = new DataSet();
            adapter.Fill(DT);
            rowCount = DT.Tables[0].Rows.Count;

            bRetVal = true;

        }
        catch (Exception ex)
        {
            strError = ex.Message;
            if (_beginTxn)
                RollBackTransaction();
        }

        return bRetVal;
    }
    public bool ExecuteCommand(ref SqlCommand CMD, ref DataSet DS, ref DataTable DT)
    {
        bool bRetVal = false;
        SqlDataAdapter adapter = default(SqlDataAdapter);

        try
        {
            bRetVal = false;
            if (!OpenConnection())
            {
                return false;
            }

            CMD.Connection = connection;
            if (Txn != null)
            {
                CMD.Transaction = Txn;
            }

            if ((DS != null))
            {
                adapter = new SqlDataAdapter(CMD);
                adapter.SelectCommand.CommandTimeout = 300;

                adapter.Fill(DS);
            }
            else if ((DT != null))
            {
                adapter = new SqlDataAdapter(CMD);
                adapter.SelectCommand.CommandTimeout = 300;

                adapter.Fill(DT);
            }
            else
            {
                CMD.ExecuteScalar();
            }

            bRetVal = true;

        }
        catch (Exception ex)
        {
            strError = ex.Message;
            if (_beginTxn)
                RollBackTransaction();
        }

        return bRetVal;
    }

    public string GetLastError()
    {
        return strError;
    }

    public clsDB()
    {
        ConnectionString = ConfigurationManager.ConnectionStrings["SFASyncContext"].ConnectionString;
        strError = "";
    }

    ~clsDB()
    {
        try
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection = null;
            }
        }
        catch (Exception ex)
        {

        }
    }

}