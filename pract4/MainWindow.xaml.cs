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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pract4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool UserOpen = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserOpen = true;
            TestWindow window = new TestWindow();
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Parol.Visibility = Visibility.Visible;
            Parol.Focus();

        }

        private void Parol_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            { 
                string password = Parol.Text;

                if (password == "Пукикаки")
                {
                    UserOpen = false;

                    TestWindow window = new TestWindow(); 
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверное кодовое слово. Введите Пукикаки.");
                    Parol.Text = "";
                    Parol.Visibility = Visibility.Collapsed;
                }

            }


        }
    }

}
