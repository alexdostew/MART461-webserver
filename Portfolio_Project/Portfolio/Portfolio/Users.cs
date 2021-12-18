using System.Data;
using System.Data.SqlClient;

namespace Portfolio
{
    public class Users
    {
        public void insertNewUser(string username, byte[] pwd, string email, string firstname, string lastname, string saltstring)
        {
            Database myDatabase = new Database();

            string myQuery = "spInsertNewUser";

            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("username", username);
            sqlParameters[1] = new SqlParameter("pwd", pwd);
            sqlParameters[2] = new SqlParameter("email", email);
            sqlParameters[3] = new SqlParameter("firstname", firstname);
            sqlParameters[4] = new SqlParameter("lastname", lastname);
            sqlParameters[5] = new SqlParameter("salt", saltstring);

            myDatabase.executeNonQueryWithParameters(sqlParameters, myQuery);

        }

        public bool checkUsername(string username)
        {
            Database myDatabase = new Database();

            string myQuery = "spCountUsername";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("username", username);
            if (myDatabase.countQuery(sqlParameters, myQuery) > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public DataSet getSpecificUser(string username)
        {
            Database myDatabase = new Database();

            string myQuery = "spSelectUsername";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("username", username);

            DataSet myDataSet = myDatabase.getDataWithParameters(sqlParameters, myQuery);
            return myDataSet;
        }

        public DataSet getSpecificUserWithID(int userID)
        {
            Database myDatabase = new Database();

            string myQuery = "spSelectUserWithID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("userID", userID);

            DataSet myDataSet = myDatabase.getDataWithParameters(sqlParameters, myQuery);
            return myDataSet;
        }

        public DataSet getSpecificUserWithPwd(string username, byte[] pwd)
        {
            Database myDatabase = new Database();

            string myQuery = "spSelectUserWithPwd";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("username", username);
            sqlParameters[1] = new SqlParameter("pwd", pwd);

            DataSet myDataSet = myDatabase.getDataWithParameters(sqlParameters, myQuery);
            return myDataSet;
        }
    }
}