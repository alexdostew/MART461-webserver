using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portfolio
{
    public class Images
    {
        public void InsertImage(int userID, string imageTitle, string imageDesc, DateTime date, string imagePath)
        {
            Database myDatabase = new Database();

            string myQuery = "spInsertImage";

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("userid", userID);
            sqlParameters[1] = new SqlParameter("imgname", imageTitle);
            sqlParameters[2] = new SqlParameter("imgdesc", imageDesc);
            sqlParameters[3] = new SqlParameter("dateposted", date);
            sqlParameters[4] = new SqlParameter("imgpath", imagePath);

            myDatabase.executeNonQueryWithParameters(sqlParameters, myQuery);

        }

        public DataSet getImages(int userID)
        {
            Database myDatabase = new Database();

            string myQuery = "spGetImagesForUser";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("userid", userID);

            DataSet myDataSet = myDatabase.getDataWithParameters(sqlParameters, myQuery);
            return myDataSet;
        }
    }
}