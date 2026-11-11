using System.Runtime.InteropServices;

namespace AppUI
{
    public partial class Form1 : Form
    {
        [DllImport("AsmLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double AddAsm(double a, double b);

        [DllImport("CppLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double AddCpp(double a, double b);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string input1 = num1.Text;
            string input2 = num2.Text;
            bool isFirstValid = double.TryParse(input1, out double number1);
            bool isSecondValid = double.TryParse(input2, out double number2);
            if (isFirstValid && isSecondValid)
            {
                double sum;
                if (cppBtn.Checked)
                {
                    sum = AddCpp(number1, number2);
                }
                else
                {
                    sum = AddAsm(number1, number2);
                }
                result.Text = sum.ToString();
            }
            else
            {
                result.Text = "Błąd!";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void num1_TextChanged(object sender, EventArgs e)
        {

        }

        private void library_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
