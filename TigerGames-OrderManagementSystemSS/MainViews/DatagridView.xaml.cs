using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace TigerGames_OrderManagementSystemSS.MainViews
{
    /// <summary>
    /// Interaction logic for DatagridView.xaml
    /// </summary>
    public partial class DatagridView : Page
    {
        public DatagridView(string TableName)
        {
            InitializeComponent();

            GetDataTable(TableName, null);
        }

        private async void GetDataTable(string Table, string? Filter)
        {
            var context = new AW_Tiger_GamesEntities();
            IQueryable queryResult = null;

            switch (Table)
            {
                case "Customer":
                    queryResult = context.tblCustomers;
                    break;
                case "Order":
                    queryResult = context.tblOrders;
                    break;
                case "Product":
                    queryResult = context.tblProducts;
                    break;
                default:
                    queryResult = context.tblCategories;
                    break;
            }

            if (queryResult == null)
            {
                return;
            }

            try
            {
                IEnumerable result = await queryResult.ToListAsync();
                PageDG.ItemsSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}
