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
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void Add_Category_AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputCategoryName = Add_CategoryName.Text.Trim();
            string inputCategoryDesc = Add_CategoryDescription.Text.Trim();

            if (string.IsNullOrEmpty(inputCategoryName) || string.IsNullOrEmpty(inputCategoryDesc))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0 - Add Category", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedCategory = context.tblCategories.Where(c => c.CategoryName == inputCategoryName).FirstOrDefault();

            if (selectedCategory != null)
            {
                MessageBox.Show("This Category already Exists.", "Tiger Games v1.0 - Add Category", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tblCategory newCategory = new tblCategory();
            newCategory.CategoryName = inputCategoryName;
            newCategory.CategoryDescription = inputCategoryDesc;

            context.tblCategories.Add(newCategory);
            context.SaveChanges();

            MessageBox.Show("This Category has been Created", "Tiger Games v1.0 - Add Category", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void Add_Order_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Add_CategoryName.Text = string.Empty;
            Add_CategoryDescription.Text = string.Empty;
        }
    }
}
