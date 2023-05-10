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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            first:
            MailAddress from = new MailAddress("k_aguero@list.ru", "卐Виталику卐");
            MailAddress to = new MailAddress(mailBox.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Лох";
            m.Body = $"<html><body><br><img src=\"https://img.netnaija.com/hsi/aHR0cHM6Ly9ndWFyZGlhbi5uZy93cC1jb250ZW50L3VwbG9hZHMvMjAxNy8xMi8zMGViMzVlZWZmMmY3ZmFkNTM3YzcxZWVjOWJkZDUwNS1hZnJpY2FuLW1lbi1ibGFjay1tYW4uanBn/images/30eb35eeff2f7fad537c71eec9bdd505-african-men-black-man.jpg\"><br><body><html>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("k_aguero@list.ru", "DFH10VkWEttxTW5QdP5e");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
            Thread.Sleep(1000);
            goto first;
        }
    }
}
