using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace spam
{
    /// <summary>
    /// Логика взаимодействия для SettingsWin.xaml
    /// </summary>
    public partial class SettingsWin : Window
    {
        public SettingsWin()
        {
            InitializeComponent();
            imaga.Source = new BitmapImage(new Uri("https://i.ytimg.com/vi/nwrataz01ww/maxresdefault.jpg"));
            oglavka.Text = conClass.oglava;
            otpravka.Text = conClass.otprava;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                imaga.Source = new BitmapImage(new Uri(imageBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conClass.otprava = otpravka.Text;
                conClass.oglava = oglavka.Text;
                conClass.ssil = imageBox.Text;
                MessageBox.Show("Сохранено");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
    }
}
