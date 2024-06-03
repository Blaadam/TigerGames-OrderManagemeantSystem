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

namespace TigerGames_OrderManagementSystemSS.AddWindows
{
    /// <summary>
    /// Interaction logic for AddCustomersWindow.xaml
    /// </summary>
    public partial class AddCustomersWindow : Window
    {
        public AddCustomersWindow()
        {
            InitializeComponent();
        }

        private void Add_Customer_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_CustomerFirstName.Text = string.Empty;
            Add_CustomerSurname.Text = string.Empty;
            Add_CustomerHouseNumber.Text = string.Empty;
            Add_CustomerAddress.Text = string.Empty;
            Add_CustomerPostCode.Text = string.Empty;
            Add_CustomerCity.Text = string.Empty;
            Add_CustomerCountry.Text = string.Empty;
            Add_CustomerHomeTel.Text = string.Empty;
            Add_CustomerMobile.Text = string.Empty;
        }

        private void Add_Customer_AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputFirstName = Add_CustomerFirstName.Text.Trim();
            string inputSurname = Add_CustomerSurname.Text.Trim();
            string inputHouseNumber = Add_CustomerHouseNumber.Text.Trim();
            string inputStreetName = Add_CustomerAddress.Text.Trim();
            string inputPostCode = Add_CustomerPostCode.Text.Trim();
            string inputCity = Add_CustomerCity.Text.Trim();
            string inputCountry = Add_CustomerCountry.Text.Trim();
            string inputHomeTel = Add_CustomerHomeTel.Text.Trim();
            string inputMobileNo = Add_CustomerMobile.Text.Trim();

            if (string.IsNullOrEmpty(inputFirstName) || string.IsNullOrEmpty(inputSurname) || string.IsNullOrEmpty(inputHouseNumber) || string.IsNullOrEmpty(inputStreetName) || string.IsNullOrEmpty(inputPostCode) || string.IsNullOrEmpty(inputCity) || string.IsNullOrEmpty(inputCountry) || string.IsNullOrEmpty(inputHomeTel) || string.IsNullOrEmpty(inputMobileNo) || string.IsNullOrEmpty(inputStreetName))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedCategory = (from user in context.tblCustomers
                                    where user.CustomerFirstName == inputFirstName && user.CustomerSurname == inputSurname && user.CustomerAddress == inputStreetName
                                    select user).FirstOrDefault();

            if (selectedCategory != null)
            {
                MessageBox.Show("This Customer already Exists.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            tblCustomer newCustomer = new tblCustomer();
            newCustomer.CustomerFirstName = inputFirstName;
            newCustomer.CustomerSurname = inputSurname;
            newCustomer.CustomerHouseNumber = Convert.ToInt32(Add_CustomerHouseNumber);
            newCustomer.CustomerAddress = inputStreetName;
            newCustomer.CustomerPostcode = inputPostCode;
            newCustomer.CustomerCity = inputCity;
            newCustomer.CustomerCountry = inputCountry;
            newCustomer.CustomerHomeTel = Convert.ToInt32(inputHomeTel);
            newCustomer.CustomerMobile = Convert.ToInt32(inputMobileNo);

            context.tblCustomers.Add(newCustomer);
            context.SaveChanges();

            MessageBox.Show($"Customer \"{inputFirstName + " " + inputSurname}\" has been created.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();

        }
    }
}
