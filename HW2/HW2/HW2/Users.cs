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

        public void insertNewUser(string userName, string fName, string lName, string email)
        {
            Database myDatabase = new Database();

            string myQuery = "spInsertNewUser";

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("username", userName);
            sqlParameters[1] = new SqlParameter("firstname", fName);
            sqlParameters[2] = new SqlParameter("lastname", lName);
            sqlParameters[3] = new SqlParameter("email", email);

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
    }
}