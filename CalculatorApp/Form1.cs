using System.Diagnostics.Metrics;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        char process = ' ';
        double number = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonClick(Button button)
        {
            if (process == '=')
            {
                textBox.Clear();
                number = 0;
                process = ' ';
            }
            textBox.Text += button.Text;
        }

        private void buttonZero_Click(object sender, EventArgs e) => ButtonClick(buttonZero);

        private void buttonOne_Click(object sender, EventArgs e) => ButtonClick(buttonOne);

        private void buttonTwo_Click(object sender, EventArgs e) => ButtonClick(buttonTwo);

        private void buttonThree_Click(object sender, EventArgs e) => ButtonClick(buttonThree);

        private void buttonFour_Click(object sender, EventArgs e) => ButtonClick(buttonFour);

        private void buttonFive_Click(object sender, EventArgs e) => ButtonClick(buttonFive);

        private void buttonSix_Click(object sender, EventArgs e) => ButtonClick(buttonSix);

        private void buttonSeven_Click(object sender, EventArgs e) => ButtonClick(buttonSeven);

        private void buttonEight_Click(object sender, EventArgs e) => ButtonClick(buttonEight);

        private void buttonNine_Click(object sender, EventArgs e) => ButtonClick(buttonNine);

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            number = 0;
            process = ' ';
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
            if (textBox.Text.Length == 0)
            {
                number = 0;
                process = ' ';
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!textBox.Text.Contains('.'))
                textBox.Text += buttonDot.Text;
        }

        private void CheckProcess()
        {
            if (number == 0)
                number = double.Parse(textBox.Text);
            else
                switch (process)
                {
                    case '+':
                        number += double.Parse(textBox.Text);
                        break;
                    case '-':
                        number -= double.Parse(textBox.Text);
                        break;
                    case '/':
                        number /= double.Parse(textBox.Text);
                        break;
                    case '*':
                        number *= double.Parse(textBox.Text);
                        break;
                    case '^':
                        number *= number;
                        break;
                    case '#':
                        number = Math.Sqrt(double.Parse(textBox.Text));
                        break;
                    default:
                        break;
                }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '+';
            textBox.Clear();
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '*';
            textBox.Clear();
        }
        private void buttonDevide_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '/';
            textBox.Clear();
        }
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '-';
            textBox.Clear();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '=';
            textBox.Text = number.ToString();
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            process = '^';
            CheckProcess();
            textBox.Text = number.ToString();
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '#';
            textBox.Text = number.ToString();
        }
    }
}