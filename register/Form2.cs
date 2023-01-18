using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace register
{
    public partial class Form2 : Form
    {
         SqlConnection con;
        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand selectDept = new SqlCommand("select * from Department", con);
            con.Open();

            //exceute query

            SqlDataReader dr = selectDept.ExecuteReader();
            List<Department> depts = new List<Department> ();
            while (dr.Read())
            {
                Department  d = new Department();
                d.dept_Id = (int)dr[0];
                d.dept_Name = dr[1].ToString();
                d.dept_Desc = dr[2].ToString();
                d.location = dr[3].ToString();
                //d.dept_manager = (int)dr[4];
                d.hiredate = dr[5].ToString();

                depts.Add(d);
            }

            comboBox1.DataSource = depts;
            comboBox1.DisplayMember = "dept_Name";
            comboBox1.ValueMember = "dept_Id";

            SqlCommand selectSuper = new SqlCommand("select DISTINCT S.St_Fname,S.St_Id  from  Student S inner join Student Super on Super.St_super=S.St_Id", con);
            dr.Close(); 
            dr = selectSuper.ExecuteReader();
            List<Student> Super = new List<Student>();
            while (dr.Read())
            {
                Student s= new Student();
                s.Id= (int)dr[1];
                s.Fname = dr[0].ToString();
                Super.Add(s);
              
            }
            comboBox2.DataSource = Super;
            comboBox2.DisplayMember = "Fname";
            comboBox2.ValueMember = "Id";

            con.Close();

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            SqlCommand insertcmd = new SqlCommand("insert into student  values(@fname,@lname,@address , @age ,@deptid,@super,@email,@password)", con);
            insertcmd.Parameters.AddWithValue("fname", St_Fname.Text);
            insertcmd.Parameters.AddWithValue("lname", St_Lname.Text);
            insertcmd.Parameters.AddWithValue("age", St_Age.Text);
            insertcmd.Parameters.AddWithValue("address", St_Address.Text);
            insertcmd.Parameters.AddWithValue("deptid", comboBox1.SelectedValue);
            insertcmd.Parameters.AddWithValue("super", comboBox2.SelectedValue);
            insertcmd.Parameters.AddWithValue("email", St_Email.Text);
            insertcmd.Parameters.AddWithValue("password", St_Password.Text);

            con.Open();

            int roweffect = insertcmd.ExecuteNonQuery();



            con.Close();
            if (roweffect > 0)
            {
                //Form2_Load(null, null);
                // St_Id.Text=St_Fname.Text=St_Lname.Text = St_Age.Text = St_Address.Text=St_Email.Text= St_Password.Text= "";
                this.Hide(); //Close Form2,the current open form.

                Form frm3 = new Form3();

                frm3.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Close Form1,the current open form.

            Form frm1 = new Form1();

            frm1.Show();
        }
    }

}
