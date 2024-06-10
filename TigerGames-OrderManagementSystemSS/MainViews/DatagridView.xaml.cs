using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using TigerGames_OrderManagementSystemSS.AddWindows;
using TigerGames_OrderManagementSystemSS.EditWindows;

namespace TigerGames_OrderManagementSystemSS.MainViews
{
    /// <summary>
    /// Interaction logic for DatagridView.xaml
    /// </summary>
    public partial class DatagridView : Page
    {
        private string CurrentTable;

        public DatagridView(string TableName)
        {
            InitializeComponent();
            CurrentTable = TableName;
            GetDataTable(TableName, null);
        }

        private async void GetDataTable(string Table, string? Filter)
        {
            var context = new AW_Tiger_GamesEntities();
            IQueryable queryResult;
            List<DataGridColumn> columns = new List<DataGridColumn>();

            switch (Table)
            {
                case "Customer":
                    queryResult = context.tblCustomers;
                    columns.Add(new DataGridTextColumn { Header = "Customer ID", Binding = new Binding("CustomerID") });

                    columns.Add(new DataGridTextColumn { Header = "First Name", Binding = new Binding("CustomerFirstName") });
                    columns.Add(new DataGridTextColumn { Header = "Surname", Binding = new Binding("CustomerSurname") });
                    columns.Add(new DataGridTextColumn { Header = "House Number", Binding = new Binding("CustomerHouseNumber") });
                    columns.Add(new DataGridTextColumn { Header = "Street Name", Binding = new Binding("CustomerAddress") });
                    columns.Add(new DataGridTextColumn { Header = "City", Binding = new Binding("CustomerCity") });
                    columns.Add(new DataGridTextColumn { Header = "Country", Binding = new Binding("CustomerCountry") });
                    columns.Add(new DataGridTextColumn { Header = "PostCode", Binding = new Binding("CustomerPostcode") });
                    columns.Add(new DataGridTextColumn { Header = "Home Telephone", Binding = new Binding("CustomerHomeTel") });
                    columns.Add(new DataGridTextColumn { Header = "Mobile Number", Binding = new Binding("CustomerMobile") });
                    break;
                case "Order":
                    columns.Add(new DataGridTextColumn { Header = "Order ID", Binding = new Binding("OrderID") });

                    columns.Add(new DataGridTextColumn { Header = "Customer ID", Binding = new Binding("CustomerID") });
                    columns.Add(new DataGridTextColumn { Header = "Surname", Binding = new Binding("CustomerSurname") });

                    columns.Add(new DataGridTextColumn { Header = "Product ID", Binding = new Binding("ProductID") });
                    columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("ProductName") });
                    columns.Add(new DataGridTextColumn { Header = "Quantity", Binding = new Binding("ProductQty") });
                    columns.Add(new DataGridTextColumn { Header = "Order Status", Binding = new Binding("OrderStatus") });

                    columns.Add(new DataGridTextColumn { Header = "Cost", Binding = new Binding("OrderCost") });
                    columns.Add(new DataGridTextColumn { Header = "Shipping Cost", Binding = new Binding("OrderShippingCost") });
                    columns.Add(new DataGridTextColumn { Header = "Final Total", Binding = new Binding("OrderFinalTotal") });
                    columns.Add(new DataGridTextColumn { Header = "Order Date", Binding = new Binding("OrderDate") });

                    columns.Add(new DataGridTextColumn { Header = "House Number", Binding = new Binding("CustomerHouseNumber") });
                    columns.Add(new DataGridTextColumn { Header = "Street Name", Binding = new Binding("CustomerAddress") });
                    columns.Add(new DataGridTextColumn { Header = "City", Binding = new Binding("CustomerCity") });
                    columns.Add(new DataGridTextColumn { Header = "Country", Binding = new Binding("CustomerCountry") });
                    columns.Add(new DataGridTextColumn { Header = "PostCode", Binding = new Binding("CustomerPostcode") });
                    queryResult = context.tblOrders;
                    break;
                case "Product":
                    columns.Add(new DataGridTextColumn { Header = "Product ID", Binding = new Binding("ProductID") });
                    columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("ProductName") });
                    columns.Add(new DataGridTextColumn { Header = "Serial Number", Binding = new Binding("ProductSerialNumber") });
                    columns.Add(new DataGridTextColumn { Header = "Category", Binding = new Binding("ProductCategory") });
                    columns.Add(new DataGridCheckBoxColumn { Header = "In Stock", Binding = new Binding("InStock") }) ;
                    columns.Add(new DataGridTextColumn { Header = "Quantity", Binding = new Binding("ProductQuantity") });

                    columns.Add(new DataGridTextColumn { Header = "Description", Binding = new Binding("ProductDescription"), MaxWidth = 300 });
                    columns.Add(new DataGridTextColumn { Header = "Size", Binding = new Binding("ProductSize") });
                    columns.Add(new DataGridTextColumn { Header = "Retail Cost", Binding = new Binding("ProductRetailCost") });
                    columns.Add(new DataGridTextColumn { Header = "Wholesale Cost", Binding = new Binding("ProductWholesaleCost") });
                    queryResult = context.tblProducts;
                    break;
                case "Category":
                    columns.Add(new DataGridTextColumn { Header = "CategoryID", Binding = new Binding("CategoryID") });
                    columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("CategoryName") });
                    columns.Add(new DataGridTextColumn { Header = "Description", Binding = new Binding("CategoryDescription"), MaxWidth = 300 });
                    queryResult = context.tblCategories;
                    break;
                default:
                    MessageBox.Show($"Table {Table} does not exist in the current context.", "Tiger Games v1.0");
                    return;
            }

            if (queryResult == null)
            {
                return;
            }

            try
            {
                var result = await queryResult.ToListAsync();

                PageDG.Columns.Clear();
                foreach (var column in columns)
                {
                    PageDG.Columns.Add(column);
                }

                PageDG.ItemsSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (CurrentTable)
            {
                case "Customer":
                    new AddCustomersWindow().ShowDialog();
                    break;
                case "Order":
                    new AddOrdersWindow().ShowDialog();
                    break;
                case "Product":
                    new AddProductsWindow().ShowDialog();
                    break;
                default:
                    new AddCategoryWindow().ShowDialog();
                    break;
            }
            GetDataTable(CurrentTable, null);
        }

        private int EntryID = -1;

        private void Datagrid_SelectedItemsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (PageDG.SelectedItems.Count != 0)
            {
                var selectedItem = PageDG.SelectedItems[0];
                switch (CurrentTable)
                {
                    case "Customer":
                        EntryID = (int)selectedItem.GetType().GetProperty("CustomerID").GetValue(selectedItem);
                        break;

                    case "Order":
                        EntryID = (int)selectedItem.GetType().GetProperty("OrderID").GetValue(selectedItem);
                        break;

                    case "Product":
                        EntryID = (int)selectedItem.GetType().GetProperty("ProductID").GetValue(selectedItem);
                        break;

                    case "Category":
                        EntryID = (int)selectedItem.GetType().GetProperty("CategoryID").GetValue(selectedItem);
                        break;

                    default:
                        return;
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EntryID == -1)
            {
                MessageBox.Show("You need to select a row before you can continue.", "Tiger Games v1.0");
                return;
            }
            switch (CurrentTable)
            {
                case "Customer":
                    new EditCustomersWindow(EntryID).ShowDialog();
                    break;
                case "Order":
                    new EditOrdersWindow(EntryID).ShowDialog();
                    break;
                case "Product":
                    new EditProductsWindow(EntryID).ShowDialog();
                    break;
                default:
                    new EditCategoryWindow(EntryID).ShowDialog();
                    break;
            }
            GetDataTable(CurrentTable, null);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EntryID == -1)
            {
                MessageBox.Show("You need to select a row before you can continue.", "Tiger Games v1.0");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to remove CategoryID: {EntryID} from the {CurrentTable} Database?", "Remove Category", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }

            var context = new AW_Tiger_GamesEntities();

            switch (CurrentTable)
            {
                case "Customer":
                    var Customer = context.tblCustomers.Where(c => c.CustomerID == EntryID).FirstOrDefault();
                    context.tblCustomers.Remove(Customer);
                    break;

                case "Order":
                    var Order = context.tblOrders.Where(c => c.OrderID == EntryID).FirstOrDefault();
                    context.tblOrders.Remove(Order);
                    break;

                case "Product":
                    var Product = context.tblProducts.Where(c => c.ProductID == EntryID).FirstOrDefault();
                    context.tblProducts.Remove(Product);
                    break;

                case "Category":
                    var Category = context.tblCategories.Where(c => c.CategoryID == EntryID).FirstOrDefault();
                    context.tblCategories.Remove(Category);
                    break;

                default:
                    MessageBox.Show($"Could not delete {EntryID} from {CurrentTable}");
                    return;
            }

            context.SaveChanges();

            MessageBox.Show($"CategoryID: {EntryID} has been deleted from the Database.");
            GetDataTable(CurrentTable, null);
        }
    }
}
