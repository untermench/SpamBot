using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Media;

namespace spam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "muzon.wav";
            sp.Load();
            sp.PlayLooping();
        }

        int tick = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CountBox.Text == "".Trim() || mailBox.Text == "".Trim() || TickBox.Text == "".Trim())
                {
                    MessageBox.Show("Заполните поля");
                }
                else
                {
                    if (Convert.ToUInt32(CountBox.Text) > 0 || Convert.ToInt32(TickBox.Text) < 1)
                    {
                        SoundPlayer spa = new SoundPlayer();
                        spa.SoundLocation = "start.wav";
                        spa.Load();
                        spa.Play();
                        MailAddress from = new MailAddress("k_aguero@list.ru", $"{conClass.otprava}");
                        MailAddress to = new MailAddress(mailBox.Text);
                        MailMessage m = new MailMessage(from, to);
                        m.Subject = $"{conClass.oglava}";
                        m.Body = $"<html><body><br><img src=\"{conClass.ssil}\"><br><body><html>";
                        m.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                        smtp.Credentials = new NetworkCredential("k_aguero@list.ru", "DFH10VkWEttxTW5QdP5e");
                        smtp.EnableSsl = true;
                        tick = Convert.ToInt32(CountBox.Text);
                        mailBox.IsEnabled = false;
                        TickBox.IsEnabled = false;
                        CountBox.IsEnabled = false;
                        SpamButton.IsEnabled = false;
                        while (tick > 0)
                        {
                            smtp.Send(m);
                            Console.Read();
                            Thread.Sleep(Convert.ToInt32(TickBox.Text) * 1000);
                            tick--;
                            CountBox.Text = tick.ToString();
                        }
                        SoundPlayer sp = new SoundPlayer();
                        sp.SoundLocation = "muzon.wav";
                        sp.Load();
                        sp.PlayLooping();
                        MessageBox.Show("Готово");
                        mailBox.IsEnabled = true;
                        TickBox.IsEnabled = true;
                        CountBox.IsEnabled = true;
                        SpamButton.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Кол-во сообщений или тиков не может быть меньше 1!");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "muzon.wav";
                sp.Load();
                sp.PlayLooping();
            }
            
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWin win = new SettingsWin();
            win.ShowDialog();
        }
    }
}
