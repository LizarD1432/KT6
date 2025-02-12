using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace another_pet_shop.pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrEmpty(LoginTextBox.Text))
                {
                    errors.AppendLine("Заполните логин");
                }

                if (string.IsNullOrEmpty(PasswordTextBox.Password))
                {
                    errors.AppendLine("Заполните пароль");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Error is accured", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (data.KT6_LenchukEntities.GetContext().user.Any(d => d.login == LoginTextBox.Text && d.password == PasswordTextBox.Password))
                {
                    var user = data.KT6_LenchukEntities.GetContext().user.FirstOrDefault(d => d.login == LoginTextBox.Text && d.password == PasswordTextBox.Password);
                    classes.Manager.CurrentUser = user;

                    switch (user.roles.roles1)
                    {
                        case "Администратор":
                            classes.Manager.MainFrame.Navigate(new AdminPage());
                            break;
                        case "Менеджер":
                            classes.Manager.MainFrame.Navigate(new ProductViewPage());
                            break;
                        case "Клиент":
                            classes.Manager.MainFrame.Navigate(new ProductViewPage());
                            break;
                    }
                    MessageBox.Show("Успешный вход", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBox.Show("Ваш логин или пароль недействительны", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Неизвестная ошибка. Программист лентяй, так и скажите ему");
            }
        }

        private void GuestEnter_Click(object sender, RoutedEventArgs e)
        {
            classes.Manager.MainFrame.Navigate(new ProductViewPage());
        }
    }
}
