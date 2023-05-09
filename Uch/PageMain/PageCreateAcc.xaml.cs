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

namespace Uch.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();

        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }



        private void psbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != txbPass.Text)
            {
                btnCreate.IsEnabled = false;
                psbPass.Background = Brushes.LightCoral;
                psbPass.BorderBrush = Brushes.Red;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.BorderBrush = Brushes.Green;
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model0db.User.Count(x => x.Login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = txbLogin.Text,
                    Name = txbName.Text,
                    Password = txbPass.Text,
                    IdRole = 2
                };
                AppConnect.model0db.User.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
