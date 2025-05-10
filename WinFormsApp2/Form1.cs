namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int genislik = Convert.ToInt32(textBox1.Text);
            int yukseklik = Convert.ToInt32(textBox2.Text);

            Form2 form2 = new Form2(genislik, yukseklik);
            form2.Show(); // Form2'yi göster

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}