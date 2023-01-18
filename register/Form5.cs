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

namespace register
{
    public partial class Form5 : Form
    {
        SqlConnection con;
        int id;
        DataTable dt;
        public Form5()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
           
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlCommand selectStudent_course = new SqlCommand($"select C.* ,T.Top_Name from Course C inner join Topic T on T.Top_Id=C.top_Id", con);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand= selectStudent_course;
            dt= new DataTable();
            adapt.Fill(dt);
            Student_course.DataSource = dt;
            Student_course.Columns[3].Visible= false;
            Update_btn.Visible = false;
            Delete_btn.Visible = false;
            SqlCommand drop_Down = new SqlCommand("select distinct T.* from Course C inner join Topic T on T.Top_Id=C.top_Id ", con);
            SqlDataAdapter adapt2 = new SqlDataAdapter();
            adapt2.SelectCommand = drop_Down;
            DataTable d= new DataTable();
            adapt2.Fill(d);
            comboBox1.DataSource = d;
            comboBox1.DisplayMember = "Top_Name";
            comboBox1.ValueMember = "Top_Id";


        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DataRow dr=dt.NewRow();
            dr["Crs_Name"] = textBox1.Text;
            dr["Crs_Duration"] = textBox2.Text;
            dr["Top_Id"] = comboBox1.SelectedValue;
            dt.Rows.Add(dr);
            Student_course.DataSource = dt;
            textBox1.Text = textBox2.Text=" ";
            comboBox1.SelectedValue = Student_course.Rows[2].Cells[3].Value;
            MessageBox.Show("Done");

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in dt.Rows)
            {
                if (((int)item["Crs_Id"]) == id)
                {
                    item["Crs_Name"] = textBox1.Text;
                    item["Crs_Duration"] = textBox2.Text;
                    item["Top_Id"] = comboBox1.SelectedValue;

                    btn_add.Visible = true;
                    Update_btn.Visible = false;
                    Delete_btn.Visible = false;
                    textBox2.Text = textBox1.Text =  "";
                    comboBox1.SelectedValue = Student_course.Rows[2].Cells[3].Value;
                    Student_course.DataSource = dt;
                }
            }
        }

        private void Student_course_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }

        private void Student_course_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Student_course_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = (int)Student_course.SelectedRows[0].Cells[0].Value;

            textBox1.Text = Student_course.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = Student_course.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.SelectedValue = Student_course.SelectedRows[0].Cells[3].Value.ToString();


            Update_btn.Visible = true;
            Delete_btn.Visible = true;

            btn_add.Visible = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlCommand insertcmd = new SqlCommand("insert into Course (Crs_Name , Crs_Duration,Top_Id)values(@Crs_Name , @Crs_Duration ,@Top_Id )", con);
            insertcmd.Parameters.Add("Crs_Name ", SqlDbType.NVarChar, 50, "Crs_Name");
            insertcmd.Parameters.Add("Crs_Duration", SqlDbType.Int, 4, "Crs_Duration");
            insertcmd.Parameters.Add("Top_Id", SqlDbType.Int, 4, "Top_Id");

            SqlCommand updatecmd = new SqlCommand("update  Course set Crs_Name=@Crs_Name ,Crs_Duration=@Crs_Duration ,Top_Id=@Top_Id where Crs_Id=@Crs_Id", con);
            updatecmd.Parameters.Add("Crs_Id", SqlDbType.Int, 4, "Crs_Id");
            updatecmd.Parameters.Add("Crs_Name", SqlDbType.NVarChar, 50, "Crs_Name");
            updatecmd.Parameters.Add("Crs_Duration", SqlDbType.Int, 4, "Crs_Duration");
           
            updatecmd.Parameters.Add("Top_Id", SqlDbType.Int, 4, "Top_Id");

            SqlCommand deletedcmd = new SqlCommand("delete from Course  where Crs_Id=@Crs_Id", con);
            deletedcmd.Parameters.Add("Crs_Id", SqlDbType.Int, 4, "Crs_Id");

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.InsertCommand = insertcmd;
            adpt.UpdateCommand = updatecmd;
            adpt.DeleteCommand = deletedcmd;


            adpt.Update(dt);
            Form5_Load(null,null);
            btn_add.Visible = true;
            Update_btn.Visible = false;
            Delete_btn.Visible = false;



        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in dt.Rows)
            {
                if (((int)item["Crs_Id"]) == id)
                {
                    item.Delete();
                    btn_add.Visible = true;
                    Update_btn.Visible = false;
                    Delete_btn.Visible = false;
                    textBox2.Text = textBox1.Text = "";
                    comboBox1.SelectedValue = Student_course.Rows[2].Cells[3].Value;
                    Student_course.DataSource = dt;
                }
            }

        }
    }
}
