using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace register
{
    internal class Bussiness
    {
        public static DataTable getall()
        {
            return DbLayer.select(new SqlCommand("select C.* ,T.Top_Name from Course C inner join Topic T on T.Top_Id=C.top_Id"));
        }
        public static DataTable getall2()
        {
            return DbLayer.select(new SqlCommand("select distinct T.* from Course C inner join Topic T on T.Top_Id=C.top_Id "));
        }


        public static DataTable getbyID(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from Course where Crs_Id=@Crs_Id");
            cmd.Parameters.AddWithValue("Crs_Id", id);
            return DbLayer.select(cmd);
        }

        public static int add(string name,string duration, string topId)
        {
            SqlCommand insertcmd = new SqlCommand("insert into Course (Crs_Name , Crs_Duration,Top_Id)values(@Crs_Name , @Crs_Duration ,@Top_Id )");
            insertcmd.Parameters.AddWithValue("Crs_Name " , name);
            insertcmd.Parameters.AddWithValue("Crs_Duration", duration);
            insertcmd.Parameters.AddWithValue("Top_Id", topId);

            return DbLayer.DML(insertcmd);
        }
        public static int Update(int id, string name, string duration, string topId)
        {
            SqlCommand updatecmd = new SqlCommand("update  Course set Crs_Name=@Crs_Name ,Crs_Duration=@Crs_Duration ,Top_Id=@Top_Id where Crs_Id=@Crs_Id");
            updatecmd.Parameters.AddWithValue("Crs_Id", id);
            updatecmd.Parameters.AddWithValue("Crs_Name", name);
            updatecmd.Parameters.AddWithValue("Crs_Duration", duration);

            updatecmd.Parameters.AddWithValue("Top_Id", topId);

            return DbLayer.DML(updatecmd);
        }
        public static int Delete(int id)
        {
            SqlCommand deletedcmd = new SqlCommand("delete from Course  where Crs_Id=@Crs_Id");
            deletedcmd.Parameters.AddWithValue("Crs_Id", id);

            return DbLayer.DML(deletedcmd);
        }
    }
}
