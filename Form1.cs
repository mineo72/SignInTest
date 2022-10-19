using System.Media;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WinFormsApp16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer soundPlayer = new();
            soundPlayer.SoundLocation = @"C:\Users\23OlsonM\Downloads\[ONTIVA.COM] cringe, there's no other word for it-HQ.wav";
            soundPlayer.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignIn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=dotnet;port=3306;password=Got22259";
            MySqlConnection conn = new(connStr);
            conn.Open();
            string takenCheck = $"SELECT userName FROM user WHERE userName = '{textBox1.Text}'";
            MySqlCommand cmd = new(takenCheck, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                MessageBox.Show("Taken");
                conn.Close();
            }
            else
            {
                rdr.Close();
                MySqlCommand insComm = new($"INSERT INTO user(userName, userPass) VALUES('{textBox1.Text}', '{textBox2.Text}')",conn);
                insComm.ExecuteNonQuery();
                MessageBox.Show("Signed Up!");
                conn.Close();
            }
        }

        void SignIn()
        {
            string connStr = "server=localhost;user=root;database=dotnet;port=3306;password=Got22259";
            MySqlConnection conn = new(connStr);
            conn.Open();
            string takenCheck = $"SELECT userName FROM user WHERE userName = '{textBox1.Text}' AND userPass ='{textBox2.Text}'";
            MySqlCommand cmd = new(takenCheck, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                MessageBox.Show("Logged in");
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
            conn.Close();
        }
    }
}