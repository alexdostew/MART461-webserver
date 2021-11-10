using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Portfolio
{
    public class Database
    {
        private string getConnectionString()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            return connection;
        }

        private SqlConnection openDatabase()
        {
            string connection = getConnectionString();
            SqlConnection myConnection;
            myConnection = new SqlConnection(connection);
            myConnection.Open();

            return myConnection;
        }

        private void closeDatabase(SqlConnection myConnection)
        {
            myConnection.Close();
        }

        public DataSet getData(string myQuery)
        {
            SqlConnection myConnection = openDatabase();
            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);

            closeDatabase(myConnection);

            return myDataSet;
        }

        public DataSet getDataWithParameters(SqlParameter[] sqlParameters, string myQuery)
        {
            SqlConnection myConnection = openDatabase();
            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddRange(sqlParameters);

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);

            closeDatabase(myConnection);

            return myDataSet;
        }

        public void executeNonQueryWithParameters(SqlParameter[] sqlParameters, string myQuery)
        {
            SqlConnection myConnection = openDatabase();

            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddRange(sqlParameters);
            myCommand.ExecuteNonQuery();

            closeDatabase(myConnection);
        }

        public int countQuery(SqlParameter[] sqlParameters, string myQuery)
        {
            int count = 0;
            SqlConnection myConnection = openDatabase();

            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddRange(sqlParameters);
            count = (int)myCommand.ExecuteScalar();

            closeDatabase(myConnection);
            return count;
        }
    }
}