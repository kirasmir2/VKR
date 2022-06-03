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

namespace VKR_Sklad
{
    /// <summary>
    /// Логика взаимодействия для SkladWindow.xaml
    /// </summary>
    public partial class SkladWindow : Window
    {
        public SkladWindow()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();
            //Инфо
            members.Add(new Member { Number = "1", Character = "sad", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "dasd", Position = "fsdf", Email = "123", Phone = "fsdf" });
            members.Add(new Member { Number = "1", Character = "sad", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "dasd", Position = "fsdf", Email = "123", Phone = "fsdf" });
            members.Add(new Member { Number = "1", Character = "sad", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "dasd", Position = "fsdf", Email = "123", Phone = "fsdf" });

            memberDataGrid.ItemsSource = members;
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
