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

namespace VKR_Sklad
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

        private void But_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void but_log_Click(object sender, RoutedEventArgs e)
        {

            if (!String.IsNullOrEmpty(log_textbox.Text))
            {
                if (!String.IsNullOrEmpty(Pas_passbox.Password))
                {
                    IQueryable<Sotrudnik> Пользователь_list = LearnBD.GetContext().Sotrudnik.Where(p => p.Login == log_textbox.Text && p.Parol == Pas_passbox.Password);
                    if (Пользователь_list.Count() == 1)
                    {                       
                        SkladWindow window = new SkladWindow();
                        window.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }

        private void but_exit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
