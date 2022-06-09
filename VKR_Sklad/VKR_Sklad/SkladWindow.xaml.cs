using System;
using System.Collections.ObjectModel;
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
using System.ComponentModel;

namespace VKR_Sklad
{
    /// <summary>
    /// Логика взаимодействия для SkladWindow.xaml
    /// </summary>
    public partial class SkladWindow : Window
    {
        class Filter
        {
            public bool IsActive { get; set; } = false;
            public Sklad sklad { get; set; }
        }
        class Sort : INotifyPropertyChanged
        {
            public int ID { get; set; }
            public string Title { get; set; }
            private bool _asc = false;
            private bool _desc = false;
            public event PropertyChangedEventHandler PropertyChanged;
            public bool ASC
            {
                get => _asc;
                set
                {
                    if (value)
                        _desc = false;
                    _asc = value;
                    Update();
                }
            }
            public bool DESC
            {
                get => _desc;
                set
                {
                    if (value)
                        _asc = false;
                    _desc = value;
                    Update();
                }
            }
            private void Update()
            {
                OnChange("ASC");
                OnChange("DESC");
            }
            private void OnChange(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        List<Filter> filters;
        List<Sort> sorts;



        public SkladWindow()
        {
            InitializeComponent();
            var converter = new BrushConverter();

            filters = new List<Filter>();
            sorts = new List<Sort>()
            {
                new Sort(){Title="По названию",ID=1},
                new Sort(){Title="По цене", ID=2}
            };
            foreach (Sklad tip in LearnBD.GetContext().Sklad)
            {
                filters.Add(new Filter { sklad = tip });
            }

            UpdateData();
            comboBox_filtr.ItemsSource = filters;
            comboBox_sort.ItemsSource = sorts;





           
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = false;
                }
            }
        }



        public void UpdateData()
        {           
            LearnBD.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List<Tovar> tovars = LearnBD.GetContext().Tovar.ToList();
            List<Sklad> sklads = filters.Where(p => p.IsActive == true).Select(p => p.sklad).ToList();
            if (sklads.Count != 0) tovars = tovars.Where(p => sklads.Contains(p.Sklad)).ToList();
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
                tovars = tovars.Where(p => p.Nazvanie.ToLower().Contains(txtSearch.Text.ToLower().Trim())).ToList();
            foreach (Sort sort in sorts)
            {
                switch (sort.ID)
                {
                    case 1:
                        if (sort.ASC) tovars = tovars.OrderBy(p => p.Nazvanie).ToList();
                        else if (sort.DESC) tovars = tovars.OrderByDescending(p => p.Nazvanie).ToList();
                        break;
                    case 2:
                        if (sort.ASC) tovars = tovars.OrderBy(p => p.Thena_za_upakowku).ToList();
                        else if (sort.DESC) tovars = tovars.OrderByDescending(p => p.Thena_za_upakowku).ToList();
                        break;
                }
            }













            memberDataGrid.ItemsSource = tovars.ToList();
        }

        private void but_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void but_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void but_barcode_Click(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Barcode_creator barcode_Creator = new Barcode_creator(but.Tag);
            barcode_Creator.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void comboBox_filtr_SelectionChanged(object sender, SelectionChangedEventArgs e) => (sender as ComboBox).SelectedIndex = -1;

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void but_add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }
    }
    public class Member
    {
        public string Character { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Brush BgColor { get; set; }

    }

}
