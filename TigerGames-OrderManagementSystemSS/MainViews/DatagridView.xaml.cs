﻿using System;
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

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (CurrentTable)
            {
                case "Customer":
                    new AddCustomersWindow().Show();
                    break;
                case "Order":
                    new AddOrdersWindow().Show();
                    break;
                case "Product":
                    new AddProductsWindow().Show();
                    break;
                default:
                    new AddCategoryWindow().Show();
                    break;
            }
        }

        private int EntryID;

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

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to remove CategoryID: {EntryID} from the Database?", "Remove Category", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
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
