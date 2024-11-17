namespace Lab1_23520734
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num1, num2;
            long sum = 0;
            num1 = Int32.Parse(textBox1.Text.Trim());
            num2 = Int32.Parse(textBox2.Text.Trim());
            sum = num1 + num2;
            textBox3.Text = sum.ToString();
        }
    }
}
