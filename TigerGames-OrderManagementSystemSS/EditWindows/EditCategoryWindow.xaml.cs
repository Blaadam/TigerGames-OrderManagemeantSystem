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

namespace TigerGames_OrderManagementSystemSS.EditWindows
{
    /// <summary>
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private int SelectedID;
        public EditCategoryWindow(int EntryID)
        {
            InitializeComponent();
            Edit_LabelID.Content = "Customer ID: " + SelectedID.ToString();
            SelectedID = EntryID;

            var context = new AW_Tiger_GamesEntities();
            var existingData = context.tblCategories.Where(c => c.CategoryID == SelectedID).FirstOrDefault();
            Edit_CategoryName.Text = existingData.CategoryName;
            Edit_CategoryDescription.Text = existingData.CategoryDescription;
        }

        private void Edit_Category_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_CategoryName.Text = string.Empty;
            Edit_CategoryDescription.Text = string.Empty;
        }

        private void Edit_Category_EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new AW_Tiger_GamesEntities();

            string inputCategoryName = Edit_CategoryName.Text.Trim();
            string inputCategoryDesc = Edit_CategoryDescription.Text.Trim();

            if (string.IsNullOrEmpty(inputCategoryName) || string.IsNullOrEmpty(inputCategoryDesc))
            {
                MessageBox.Show("One or more field(s) are empty.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingData = context.tblCategories.Where(c => c.CategoryID == SelectedID).FirstOrDefault();

            if (existingData == null)
            {
                MessageBox.Show("This customer does not exist.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            existingData.CategoryName = inputCategoryName;
            existingData.CategoryDescription = inputCategoryDesc;

            context.SaveChanges();

            MessageBox.Show($"Category \"{inputCategoryName}\" has been updated.", "Tiger Games v1.0", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
