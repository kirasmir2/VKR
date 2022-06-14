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

namespace VKR_Sklad
{

    public partial class AddWindow : Window
    {
        public Tovar tovar { get; set; }
        bool isAdd = false;
        public AddWindow(Tovar tovar_window)
        {
            InitializeComponent();
            this.tovar = tovar_window;
            DataContext = tovar;
            tipSklada_combo.ItemsSource = LearnBD.GetContext().Sklad.ToList();
            proizvoditel_combo.ItemsSource = LearnBD.GetContext().Proizvoditel.ToList();
        }
        public AddWindow()
        {
            InitializeComponent();
            isAdd = true;
            tovar = new Tovar();
            DataContext = tovar;
            tipSklada_combo.ItemsSource = LearnBD.GetContext().Sklad.ToList();
            proizvoditel_combo.ItemsSource = LearnBD.GetContext().Proizvoditel.ToList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dob_but_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd == true)
                LearnBD.GetContext().Tovar.Add(tovar);
            LearnBD.GetContext().SaveChanges();
            (this.Owner as SkladWindow).UpdateData();
            this.Close();
        }
    }
}
