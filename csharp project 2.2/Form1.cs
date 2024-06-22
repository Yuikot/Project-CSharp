using System.Diagnostics;

namespace csharp_project__2._2
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            stopwatch.Stop();
            TimeSpan initTime = stopwatch.Elapsed;

            TimeSpan threshold = TimeSpan.FromSeconds(5);

            if (initTime > threshold)
            {
                string logMessage = $"Czas inicjalizacji komponentów przekroczy³ próg: {initTime.TotalSeconds} sekund.";
                EventLog.WriteEntry("Application", logMessage, EventLogEntryType.Warning);
            }
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text;
            try
            {
                double result = EvaluateExpression(expression);
                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
        private double EvaluateExpression(string expression)
        {
            char op = ' ';
            int opIndex = expression.IndexOfAny(new char[] { '+', '-', '*', '/' });
            if (opIndex != -1)
            {
                op = expression[opIndex];
            }

            string[] numbers = expression.Split(new char[] { '+', '-', '*', '/' });
            double left = double.Parse(numbers[0]);
            double right = double.Parse(numbers[1]);

            switch (op)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    if (right == 0)
                    {
                        throw new DivideByZeroException("Nie mo¿na dzieliæ przez zero.");
                    }
                    return left / right;
                default:
                    throw new InvalidOperationException("Niepoprawne wyra¿enie arytmetyczne.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";

        }

        private void buttonTimes_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";

        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";

        }

        private void ButtonEquals_Click_1(object sender, EventArgs e)
        {
            string expression = textBox1.Text;
            try
            {
                double result = EvaluateExpression(expression);
                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void ButtonClearEntry_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
    }
}