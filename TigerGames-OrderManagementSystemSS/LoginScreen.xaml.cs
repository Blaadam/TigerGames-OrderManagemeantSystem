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

namespace TigerGames_OrderManagementSystemSS
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();

            UsernameTb.Focus();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            UsernameTb.Text = string.Empty;
            PasswordTb.Password = string.Empty;

            UsernameTb.Focus();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputtedUsername = UsernameTb.Text.Trim();
            string inputtedPassword = PasswordTb.Password.Trim();

            var userData = context.tblUsers.Where(u => u.UserName == inputtedUsername).FirstOrDefault();

            if (userData == null || userData.Password != inputtedPassword)
            {
                MessageBox.Show("Incorrect Login Credentials", "Tiger Games v1.0");
                return;
            }

            MessageBox.Show($"Welcome, {inputtedUsername}", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Information);

            MainWindow window = new MainWindow();
            this.Close();
            window.ShowDialog();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("If you would like to create an account to use the Stock Management System, contact the Tiger Games IT Team.", "Tiger Games v1.0");
        }
    }
}
