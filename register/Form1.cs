namespace register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool IsLoggedIn { get; set; }

        private void Register_Click(object sender, EventArgs e)
        {
            //this.Hide(); //Close Form1,the current open form.

            Form frm3 = new Form3();

            frm3.Show();
         

        }

        private void Login_Click(object sender, EventArgs e)
        {
           // this.Hide(); //Close Form2,the current open form.

            Form frm6 = new Form6();

            frm6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide(); //Close Form2,the current open form.

            Form frm5 = new Form5();

            frm5.Show();

        }
    }
}