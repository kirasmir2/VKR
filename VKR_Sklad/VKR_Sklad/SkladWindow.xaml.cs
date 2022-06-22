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
using Word = Microsoft.Office.Interop.Word;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;


namespace VKR_Sklad
{
   
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
            List<Zakaz> zakaz_Tovars = LearnBD.GetContext().Zakaz.ToList();
            List<Sklad> sklads1 = LearnBD.GetContext().Sklad.ToList();
            List<Klient> klients = LearnBD.GetContext().Klient.ToList();
            List<Sotrudnik> sotrudniks = LearnBD.GetContext().Sotrudnik.ToList();
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









            klientDataGrid.ItemsSource = klients;
            skladDataGrid.ItemsSource = sklads1;
            sotrudnikDataGrid.ItemsSource = sotrudniks;
            sotrDataGrid.ItemsSource = zakaz_Tovars;
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
            addWindow.Owner = this;
            addWindow.Show();
        }

        private void Edit_but_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(memberDataGrid.SelectedItem as Tovar);
            editWindow.Owner = this;
            editWindow.Show();

        }

        private void remove_but_Click(object sender, RoutedEventArgs e)
        {
            if (memberDataGrid.SelectedItems.Count != 0) // проверка, выделен ли элемент в списке
            {
                List<Tovar> tovars = memberDataGrid.SelectedItems.OfType<Tovar>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хоите удалить?", "Удаление", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    LearnBD.GetContext().Tovar.RemoveRange(tovars);
                    LearnBD.GetContext().SaveChanges();
                    UpdateData();
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            sotrDataGrid.Visibility = Visibility.Hidden;
            sotrDataGrid.IsEnabled = false;
        }

        private void zakaz_but_Click(object sender, RoutedEventArgs e)
        {
            sotrDataGrid.Visibility = Visibility.Visible;
            sotrDataGrid.IsEnabled = true;
            memberDataGrid.Visibility = Visibility.Hidden;
            memberDataGrid.IsEnabled = false;
            klientDataGrid.Visibility = Visibility.Hidden;
            klientDataGrid.IsEnabled = false;
            sotrudnikDataGrid.Visibility = Visibility.Hidden;
            sotrudnikDataGrid.IsEnabled = false;
            skladDataGrid.Visibility = Visibility.Hidden;
            skladDataGrid.IsEnabled = false;
            all_text.Text = "Список заказов";
        }

        private void tovar_but_Click(object sender, RoutedEventArgs e)
        {
            sotrDataGrid.Visibility = Visibility.Hidden;
            sotrDataGrid.IsEnabled = false;
            memberDataGrid.Visibility = Visibility.Visible;
            memberDataGrid.IsEnabled = true;
            sotrudnikDataGrid.Visibility = Visibility.Hidden;
            klientDataGrid.Visibility = Visibility.Hidden;
            klientDataGrid.IsEnabled = false;
            sotrudnikDataGrid.IsEnabled = false;
            skladDataGrid.Visibility = Visibility.Hidden;
            skladDataGrid.IsEnabled = false;
            all_text.Text = "Список товаров";
        }

        private void sotr_but_Click(object sender, RoutedEventArgs e)
        {
            sotrudnikDataGrid.Visibility = Visibility.Visible;
            sotrudnikDataGrid.IsEnabled = true;
            sotrDataGrid.Visibility = Visibility.Hidden;
            sotrDataGrid.IsEnabled = false;
            memberDataGrid.Visibility = Visibility.Hidden;
            klientDataGrid.Visibility = Visibility.Hidden;
            klientDataGrid.IsEnabled = false;
            memberDataGrid.IsEnabled = false;
            skladDataGrid.Visibility = Visibility.Hidden;
            skladDataGrid.IsEnabled = false;
            all_text.Text = "Список сотрудников";
        }

        private void sklad_but_Click(object sender, RoutedEventArgs e)
        {
            sotrudnikDataGrid.Visibility = Visibility.Hidden;
            sotrudnikDataGrid.IsEnabled = false;
            sotrDataGrid.Visibility = Visibility.Hidden;
            sotrDataGrid.IsEnabled = false;
            memberDataGrid.Visibility = Visibility.Hidden;
            memberDataGrid.IsEnabled = false;
            klientDataGrid.Visibility = Visibility.Hidden;
            klientDataGrid.IsEnabled = false;
            skladDataGrid.Visibility = Visibility.Visible;
            skladDataGrid.IsEnabled = true;
            all_text.Text = "Список складов";
        }

        private void otwet_but_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Word documents (*.docx) |*.docx";
            if (saveFile.ShowDialog() == true)
            {
                object oMiss = System.Reflection.Missing.Value;
                Word.Application wordapp = new Word.Application();
                wordapp.Visible = true;
                Word.Document doc = wordapp.Documents.Add(ref oMiss, ref oMiss, ref oMiss, ref oMiss);
                Word.Paragraph pargar = doc.Content.Paragraphs.Add(ref oMiss);
                pargar.Range.Text = "Отчёт по товарам на складе";
                pargar.Range.Font.Color = Word.WdColor.wdColorBlack;
                pargar.Range.Font.Bold = 1;
                pargar.Range.Font.Size = 14f;
                pargar.Range.Font.Name = "Times New Roman";
                pargar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                pargar.Range.InsertParagraphAfter();
                Word.Paragraph table_par = doc.Content.Paragraphs.Add(ref oMiss);
                Word.Table table = doc.Content.Tables.Add(table_par.Range, LearnBD.GetContext().Tovar.Count(), 4, ref oMiss, ref oMiss);
                table.Range.Font.Size = 10f;
                table.Range.Font.Bold = 0;
                table.Rows[1].Range.Font.Bold = 1;
                /*Поля*/
                table.Cell(1, 1).Range.Text = "Название";
                table.Cell(1, 2).Range.Text = "Производитель";
                table.Cell(1, 3).Range.Text = "Количество";
                table.Cell(1, 4).Range.Text = "Место хранения";
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                /*Подключение базы данных*/
                for (int i = 0; i < LearnBD.GetContext().Tovar.Count(); i++)
                {
                    var zzz = LearnBD.GetContext().Tovar.ToList()[i];
                    table.Cell(i + 2, 1).Range.Text = LearnBD.GetContext().Tovar.ToList()[i].Nazvanie;
                    table.Cell(i + 2, 2).Range.Text = LearnBD.GetContext().Tovar.Where(p => p.Nomer_tovara == zzz.Nomer_tovara).First().Proizvoditel1.Nazvanie_kompanii;
                    table.Cell(i + 2, 3).Range.Text = LearnBD.GetContext().Tovar.ToList()[i].Kolitewto_upakowok;
                    table.Cell(i + 2, 4).Range.Text = LearnBD.GetContext().Tovar.Where(p => p.Nomer_tovara == zzz.Nomer_tovara).First().Sklad.Nazvanie;
                }
                doc.SaveAs2(saveFile.FileName, ref oMiss, ref oMiss, ref oMiss, ref oMiss, ref oMiss,
                ref oMiss, ref oMiss, ref oMiss, ref oMiss, ref oMiss,
                ref oMiss, ref oMiss, ref oMiss, ref oMiss, ref oMiss);
            }
        }

        private void klient_but_Click(object sender, RoutedEventArgs e)
        {
            sotrudnikDataGrid.Visibility = Visibility.Hidden;
            sotrudnikDataGrid.IsEnabled = false;
            sotrDataGrid.Visibility = Visibility.Hidden;
            sotrDataGrid.IsEnabled = false;
            memberDataGrid.Visibility = Visibility.Hidden;
            memberDataGrid.IsEnabled = false;
            skladDataGrid.Visibility = Visibility.Hidden;
            skladDataGrid.IsEnabled = false;
            klientDataGrid.Visibility = Visibility.Visible;
            klientDataGrid.IsEnabled = true;
            all_text.Text = "Список клиентов";
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
