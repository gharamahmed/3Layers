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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace register
{
    public partial class Form6 : Form
    {
        SqlConnection con;
        int id;
       
        public Form6()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Student_course.DataSource = Bussiness.getall();
            Student_course.Columns[3].Visible= false;
            Update_btn.Visible = false;
            Delete_btn.Visible = false;
            comboBox1.DataSource=Bussiness.getall2();
            comboBox1.DisplayMember = "Top_Name";
            comboBox1.ValueMember = "Top_Id";

        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int roweffect = Bussiness.Delete(id);
            if (roweffect > 0)
            {
                Student_course.DataSource = Bussiness.getall();
                textBox1.Text = textBox2.Text =  " ";
                comboBox1.SelectedValue = Student_course.Rows[2].Cells[3].Value;
                MessageBox.Show("Done");
                btn_add.Visible = true;
                Update_btn.Visible = false;
                Delete_btn.Visible = false;

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int roweffect = Bussiness.add(textBox1.Text,textBox2.Text.ToString(),comboBox1.SelectedValue.ToString());

            if (roweffect > 0)
            {
                Student_course.DataSource = Bussiness.getall();
                textBox1.Text = textBox2.Text  = " ";
                comboBox1.SelectedValue = Student_course.Rows[2].Cells[3].Value;
                MessageBox.Show("Done");

            }

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            int roweffect = Bussiness.Update(id,textBox1.Text, textBox2.Text.ToString(), comboBox1.SelectedValue.ToString());
            if (roweffect > 0)
            {
                Student_course.DataSource = Bussiness.getall();
                textBox1.Text = textBox2.Text =  " ";
                comboBox1.SelectedValue = Student_course.Rows[2].Cells[3].Value;
                MessageBox.Show("Done");
                btn_add.Visible = true;
                Update_btn.Visible = false;
                Delete_btn.Visible = false;

            }

        }

        private void Save_Click(object sender, EventArgs e)
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
    }
}
