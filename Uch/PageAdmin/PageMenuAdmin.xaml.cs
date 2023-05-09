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
using Uch.ApplicationData;
using Uch.Model;
using Uch.PageMain;

namespace Uch.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageMenuAdmin.xaml
    /// </summary>
    public partial class PageMenuAdmin : Page
    {
        public PageMenuAdmin()
        {
            InitializeComponent();
            Loaded += PageAddCar_Loaded;
        }



        private void PageAddCar_Loaded(object sender, RoutedEventArgs e)
        {
            Data.ItemsSource = AppData.db.Car_Uche.ToList();
        }
        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Изменить данные?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.db.SaveChanges();
                Data.ItemsSource = AppData.db.Car_Uche.ToList();
                MessageBox.Show("Изменено!");
            }
            AppData.db.SaveChanges();
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                if (MessageBox.Show("Удалить?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var CurrentClient = Data.SelectedItem as Car_Uche;
                    AppData.db.Car_Uche.Remove(CurrentClient);
                    AppData.db.SaveChanges();
                    Data.ItemsSource = AppData.db.Car_Uche.ToList();
                    MessageBox.Show("Успешно!");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAddCar());
        }

        private void Data_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
