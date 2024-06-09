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
        public EditCategoryWindow(int selectedID)
        {
            InitializeComponent();
            Edit_LabelID.Content = "Customer ID: " + SelectedID.ToString();
            SelectedID = selectedID;
        }

        private void Edit_Category_ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Edit_CategoryName.Text = string.Empty;
            Edit_CategoryDescription.Text = string.Empty;
        }

        private void Edit_Category_EditBtn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
