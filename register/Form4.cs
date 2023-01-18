using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace register
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        int id;
        public Form4(int qs)
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            id = qs;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlCommand selectStudent_course = new SqlCommand($"select Crs_Name,Crs_Duration,Grade from  Stud_Course SC inner join Course c on SC.St_Id= {id} and Sc.Crs_Id=c.Crs_Id", con);
            con.Open();

            //exceute query

            SqlDataReader dr = selectStudent_course.ExecuteReader();
            List<Student_course> St_course = new List<Student_course>();
            while (dr.Read())
            {
                Student_course SC = new Student_course();
                SC.course_name=dr[0].ToString();
                SC.duration = (int)dr[1];
                SC.Grade = (int)dr[2];
                St_course.Add(SC);
            }
            Student_course.DataSource = St_course;
            SqlCommand student = new SqlCommand($"select St_Fname+' '+St_Lname,Dept_Name from student S inner join Department D on S.St_id={id} and D.Dept_Id=S.Dept_Id ",con);
            dr.Close();
            dr = student.ExecuteReader();
            if (dr.Read())
            {
                label2.Text= $"Name : {dr[0].ToString()}";
                label1.Text =$"Deptartment Name : { dr[1].ToString()}";
            }
            con.Close();
        }
    }
}
