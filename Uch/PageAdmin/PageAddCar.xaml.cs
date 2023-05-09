using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace Uch.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAddCar.xaml
    /// </summary>
    public partial class PageAddCar : Page
    {
        public PageAddCar()
        {
            InitializeComponent();
            
        }



        private void Button_Back(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMenuAdmin());
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            using (var context = new UcheAppEntitie())
            {
                string typeName = Name.Text;
                string decorRegNum = RegNum.Text;
                string decorYear = Year.Text;
                string decorColor = Color.Text;

                context.Car_Uche.Add(new Car_Uche
                {
                    Name = typeName,
                    RegNum = decorRegNum,
                    Year = decorYear,
                    Color = decorColor,
                });
                int result = context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Добавлено!");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так. Попробуйте еще раз.");
                }
            }
        }
    }
    
    
}
