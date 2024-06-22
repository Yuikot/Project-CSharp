using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace csharp_project_2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dzielnatextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dzielnikTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void wynikTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void wynikButton_Click(object sender, EventArgs e)
        {
            try
            {
                double dzielna = Convert.ToDouble(dzielnatextBox.Text);
                double dzielnik = Convert.ToDouble(dzielnikTextBox.Text);

                if (dzielnik == 0)
                {
                    throw new DivideByZeroException();
                }

                double wynik = dzielna / dzielnik;
                wynikTextBox.Text = wynik.ToString();
            }
            catch (FormatException ex)
            {
                LogError("Nieprawid�owy format liczby.", ex);
                MessageBox.Show("Prosz� wprowadzi� prawid�owe liczby.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                LogError("Pr�ba dzielenia przez zero.", ex);
                MessageBox.Show("Dzielenie przez zero jest niedozwolone.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError("Nieznany b��d.", ex);
                MessageBox.Show("Wyst�pi� nieznany b��d.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LogError(string message, Exception ex)
        {
            EventLog.WriteEntry("Application", $"{message}\n{ex.Message}\n{ex.StackTrace}", EventLogEntryType.Error);
        }
    }
}