using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShutDown
{
    public partial class WinOFF : Form
    {
        private Timer countdownTimer;
        private int remainingTime;
        public WinOFF()
        {
            InitializeComponent();
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; 
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                if (int.TryParse(textBox1.Text, out int hours) &&
                    int.TryParse(textBox4.Text, out int minutes))
                {
                    remainingTime = hours * 3600 + minutes * 60;
                    if (remainingTime > 0)
                    {
                        try
                        {
                        ProcessStartInfo info = new ProcessStartInfo()
                        {
                            FileName = @"C:\Windows\System32\shutdown.exe",
                            Arguments = $"-s -t {remainingTime}",
                            UseShellExecute = true,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };


                        Process.Start(info);
                            MessageBox.Show($"Выключение через {hours} ч. {minutes} мин.");
                            countdownTimer.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                }
            




        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = @"C:\Windows\System32\shutdown.exe",
                Arguments = "-a",
                UseShellExecute = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(info);
            countdownTimer.Stop();
            label1.Text = "Таймер остановлен";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = $"Осталось: {remainingTime / 3600:D2}:{(remainingTime % 3600) / 60:D2}:{remainingTime % 60:D2}";

        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                label1.Text = $"Осталось: {remainingTime / 3600:D2}:{(remainingTime % 3600) / 60:D2}:{remainingTime % 60:D2}";
            }
            else
            {
                countdownTimer.Stop();
            }
        }

    }
}
