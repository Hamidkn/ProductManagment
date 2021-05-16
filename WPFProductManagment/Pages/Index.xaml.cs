using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Productmanagement.Model.BaseClasses;
using Productmanagement.Model1;
using Customer = Productmanagement.Models.Customer;
using Employee = Productmanagement.Model.Models.Employee;
using Product = Productmanagement.Model.Models.Product;

namespace WPFProductManagment.View.Pages
{
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Index : Window
  {
    public static ProductManagementEntities dataset = new ProductManagementEntities();
    private Border border = new Border();
    private EmployeeCollection emCollection = new EmployeeCollection();
    private CustomerCollection cmCollection = new CustomerCollection(dataset);
    private ProductCollection prCollection = new ProductCollection();

    ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
    ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();
    ObservableCollection<Product> Products = new ObservableCollection<Product>();

    public Employee CurrentEmployee { get; set; } = new Employee();
    public Customer CurrentCustomer { get; set; } = new Customer();
    public Product CurrentProduct { get; set; } = new Product();

    public Index()
    {
      InitializeComponent();
      FillData();
      listViewCustomer.ItemsSource = Customers;
      listViewEmployee.ItemsSource = Employees;
      listViewProduct.ItemsSource = Products;
    }

    private void FillData()
    {
      Employees = emCollection.Employeescollection;
      Customers = cmCollection.Customercollection;
      Products = prCollection.Productcollection;
    }

    private void Btn_OnClick(object sender, RoutedEventArgs e)
    {
      if ((string)((Button)sender).Content == "Home")
      {
        HomePanel.Visibility = Visibility.Visible;
        EmployeesPanel.Visibility = Visibility.Collapsed;
        ProductsPanel.Visibility = Visibility.Collapsed;
        CustomersPanel.Visibility = Visibility.Collapsed;
      }
      else if ((string)((Button)sender).Content == "Employees")
      {
        HomePanel.Visibility = Visibility.Collapsed;
        EmployeesPanel.Visibility = Visibility.Visible;
        ProductsPanel.Visibility = Visibility.Collapsed;
        CustomersPanel.Visibility = Visibility.Collapsed;
      }
      else if ((string)((Button)sender).Content == "Customers")
      {
        HomePanel.Visibility = Visibility.Collapsed;
        EmployeesPanel.Visibility = Visibility.Collapsed;
        ProductsPanel.Visibility = Visibility.Collapsed;
        CustomersPanel.Visibility = Visibility.Visible;
      }
      else if ((string)((Button)sender).Content == "Products")
      {
        HomePanel.Visibility = Visibility.Collapsed;
        EmployeesPanel.Visibility = Visibility.Collapsed;
        ProductsPanel.Visibility = Visibility.Visible;
        CustomersPanel.Visibility = Visibility.Collapsed;
      }
    }

    private void ImageButton_OnClick(object sender, RoutedEventArgs e)
    {
      var fileName = ((Hyperlink)sender).NavigateUri.ToString();
      var url = new ProcessStartInfo(fileName)
      {
        UseShellExecute = true,
        Verb = "open"
      };
      Process.Start(url);
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
      contextMenu.IsOpen = true;
      e.Handled = true;

      // ContextMenu cm = (ContextMenu)contextMenu;
      // cm.PlacementTarget = ((Button)sender);
      // cm.IsOpen = true;
    }

    private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
      if (((Button)sender).Name == "BtnDeleteEmployee")
      {
        if (listViewEmployee.SelectedItem == null)
        {
          MessageBox.Show("Please select a row to delete!");
        }
        else if (MessageBox.Show("Are you sure for delete?", "Delete employee", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          emCollection.Employeescollection.Remove((Employee)listViewEmployee.SelectedItem);
          EmployeeDetail.Content = "---";
        }
      }
      else if (((Button)sender).Name == "BtnDeleteCustomer")
      {
        if (listViewCustomer.SelectedItem == null)
        {
          MessageBox.Show("Please select a row to delete!");
        }
        else if (MessageBox.Show("Are you sure for delete?", "Delete customer", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          cmCollection.Customercollection.Remove((Customer)listViewCustomer.SelectedItem);
          CustomerDetail.Content = "---";
        }
      }
      else if (((Button)sender).Name == "BtnDeleteProduct")
      {
        if (listViewProduct.SelectedItem == null)
        {
          MessageBox.Show("Please select a row to delete!");
        }
        else if (MessageBox.Show("Are you sure for delete?", "Delete product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          prCollection.Productcollection.Remove((Product)listViewProduct.SelectedItem);
          ProductDetail.Content = "---";
        }
      }
    }

    private void ListViewEmployee_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (listViewEmployee.SelectedIndex >= 0)
      {
        CurrentEmployee = listViewEmployee.SelectedItem as Employee;
        EmployeeDetail.Content = CurrentEmployee.GetBasicInfo();
      }
    }

    private void ListViewCustomer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (listViewCustomer.SelectedIndex >= 0)
      {
        CurrentCustomer = listViewCustomer.SelectedItem as Customer;
        CustomerDetail.Content = CurrentCustomer.GetBasicInfo();
      }
    }

    private void ListViewProduct_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (listViewProduct.SelectedIndex >= 0)
      {
        CurrentProduct=listViewProduct.SelectedItem as Product;
        ProductDetail.Content = CurrentProduct.GetBasicInfo();
      }
    }

    private void BtnAddEmployee_OnClick(object sender, RoutedEventArgs e)
    {
      AddEmployeeWindow add = new AddEmployeeWindow(emCollection);
      add.ShowDialog();
    }

    private void BtnEditEmployee_OnClick(object sender, RoutedEventArgs e)
    {
      if (listViewEmployee.SelectedIndex >= 0)
      {
        CurrentEmployee = listViewEmployee.SelectedItem as Employee;
        AddEmployeeWindow edit = new AddEmployeeWindow(emCollection, CurrentEmployee);
        edit.ShowDialog();
      }
    }

    private void BtnAddCustomer_OnClick(object sender, RoutedEventArgs e)
    {
      AddEditCustomerWindow addcustomer = new AddEditCustomerWindow(cmCollection);
      addcustomer.ShowDialog();
    }

    private void BtnEditCustomer_OnClick(object sender, RoutedEventArgs e)
    {
      if (listViewCustomer.SelectedIndex >= 0)
      {
        CurrentCustomer = listViewCustomer.SelectedItem as Customer;
        AddEditCustomerWindow editCustomer =
          new AddEditCustomerWindow(cmCollection, CurrentCustomer);
        editCustomer.ShowDialog();
      }
    }

    private void BtnAddProduct_OnClick(object sender, RoutedEventArgs e)
    {
      AddEditProductWindow addproduct = new AddEditProductWindow(prCollection);
      addproduct.ShowDialog();
    }

    private void BtnEditProduct_OnClick(object sender, RoutedEventArgs e)
    {
      if (listViewProduct.SelectedIndex >= 0)
      {
        CurrentProduct = listViewProduct.SelectedItem as Product;
        AddEditProductWindow editProduct = new AddEditProductWindow(prCollection, CurrentProduct);
        editProduct.ShowDialog();
      }
    }
  }
}
