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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace register
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        public Form3()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string Log_email = Login_Email.Text;
            string Log_password = Login_Password.Text;
            SqlCommand selectLogin = new SqlCommand($"select * from Student where Email='{Log_email}' and Password='{Log_password}'", con);
            con.Open();
            //exceute query
            SqlDataReader dr = selectLogin.ExecuteReader();
            if (dr.Read())
            { 
                this.Hide(); 

                Form frm4 = new Form4((int)dr[0]);

                frm4.Show();
            }
            else
            {
                MessageBox.Show("Enail or password may be Incorrect");
            }
         
            con.Close();

        }
    }
}
