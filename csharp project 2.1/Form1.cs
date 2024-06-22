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
                LogError("Nieprawid³owy format liczby.", ex);
                MessageBox.Show("Proszê wprowadziæ prawid³owe liczby.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                LogError("Próba dzielenia przez zero.", ex);
                MessageBox.Show("Dzielenie przez zero jest niedozwolone.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                LogError("Nieznany b³¹d.", ex);
                MessageBox.Show("Wyst¹pi³ nieznany b³¹d.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LogError(string message, Exception ex)
        {
            EventLog.WriteEntry("Application", $"{message}\n{ex.Message}\n{ex.StackTrace}", EventLogEntryType.Error);
        }
    }
}