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
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = @"C:\Users\23OlsonM\Downloads\[ONTIVA.COM] cringe, there's no other word for it-HQ.wav";
            soundPlayer.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=dotnet;port=3306;password=Got22259";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string takenCheck = $"SELECT userName FROM user WHERE userName = '{textBox1.Text}'";
            MySqlCommand cmd = new MySqlCommand(takenCheck, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr[0].ToString() == textBox1.Text)
            {
                MessageBox.Show("Taken");
            }
            else
            {
                MySqlCommand insComm = new($"INSERT INTO user (userName, userPassword) VALUES ({textBox1.Text}, {textBox2.Text})");
                insComm.ExecuteNonQuery();
                MessageBox.Show("Signed Up!");
            }
        }
    }
}