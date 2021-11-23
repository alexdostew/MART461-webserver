using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HW2
{
    public class Users
    {
        public DataSet getAllUsers()
        {
            Database myDatabase = new Database();

            string myQuery = "spSelectAllUsers";

            DataSet myDataSet = myDatabase.getData(myQuery);
            return myDataSet;
        }

        public DataSet getSpecificUser(int userID)
        {
            Database myDatabase = new Database();

            string myQuery = "spSelectSpecificUser";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("userId", userID);

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

        public DataSet getSpecificUsername(string username)
        {
            Database myDatabase = new Database();

            string myQuery = "spSelectUsername";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("username", username);

            DataSet myDataSet = myDatabase.getDataWithParameters(sqlParameters, myQuery);
            return myDataSet;
        }

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

        public void updateUser(int userID, string userName, string fName, string lName, string email)
        {
            Database myDatabase = new Database();

            string myQuery = "spUpdateUser";

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("userId", userID);
            sqlParameters[1] = new SqlParameter("username", userName);
            sqlParameters[2] = new SqlParameter("firstname", fName);
            sqlParameters[3] = new SqlParameter("lastname", lName);
            sqlParameters[4] = new SqlParameter("email", email);

            myDatabase.executeNonQueryWithParameters(sqlParameters, myQuery);
        }

        public void deleteUser(int userID)
        {
            Database myDatabase = new Database();

            string myQuery = "spDeleteUser";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("userId", userID);

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
            }
            else
            {
                return false;
            }
        }
    }
}