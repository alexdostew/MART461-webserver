using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portfolio
{
    public class Comments
    {
        public void InsertComment(int userID, int imageID, string comment, DateTime date)
        {
            Database myDatabase = new Database();

            string myQuery = "spInsertComment";

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("userID", userID);
            sqlParameters[1] = new SqlParameter("imageID", imageID);
            sqlParameters[2] = new SqlParameter("newComment", comment);
            sqlParameters[3] = new SqlParameter("time", date);

            myDatabase.executeNonQueryWithParameters(sqlParameters, myQuery);

        }
        public void InsertCommentNoID(int imageID, string comment, DateTime date)
        {
            Database myDatabase = new Database();

            string myQuery = "spInsertCommentNoID";

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("imageID", imageID);
            sqlParameters[1] = new SqlParameter("newComment", comment);
            sqlParameters[2] = new SqlParameter("time", date);

            myDatabase.executeNonQueryWithParameters(sqlParameters, myQuery);

        }

        public DataSet getComments(int imgID)
        {
            Database myDatabase = new Database();

            string myQuery = "spGetComments";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("imgID", imgID);

            DataSet myDataSet = myDatabase.getDataWithParameters(sqlParameters, myQuery);
            return myDataSet;
        }
    }
}