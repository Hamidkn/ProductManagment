using System;
using System.Collections.Generic;
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
using Productmanagement.Model.Models;

namespace WPFProductManagment.View.Pages
{
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Index : Window
  {
    private Border border = new Border();
    private EmployeeCollection emCollection = new EmployeeCollection();
    private CustomerCollection cmCollection = new CustomerCollection();
    private ProductCollection prCollection = new ProductCollection();

    public Index()
    {
      InitializeComponent();
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
        listViewEmployee.ItemsSource = emCollection.Employeescollection;
        ProductsPanel.Visibility = Visibility.Collapsed;
        CustomersPanel.Visibility = Visibility.Collapsed;
      }
      else if ((string)((Button)sender).Content == "Customers")
      {
        HomePanel.Visibility = Visibility.Collapsed;
        EmployeesPanel.Visibility = Visibility.Collapsed;
        ProductsPanel.Visibility = Visibility.Collapsed;
        CustomersPanel.Visibility = Visibility.Visible;
        listViewCustomer.ItemsSource = cmCollection.Customercollection;
      }
      else if ((string)((Button)sender).Content == "Products")
      {
        HomePanel.Visibility = Visibility.Collapsed;
        EmployeesPanel.Visibility = Visibility.Collapsed;
        ProductsPanel.Visibility = Visibility.Visible;
        listViewProduct.ItemsSource = prCollection.Productcollection;
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
          return;
        }
        else if (MessageBox.Show("Are you sure for delete?", "Delete employee", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          emCollection.Employeescollection.Remove((Employee)listViewEmployee.SelectedItem);
        }
      }
      else if (((Button)sender).Name == "BtnDeleteCustomer")
      {
        if (listViewCustomer.SelectedItem == null)
        {
          return;
        }
        else if (MessageBox.Show("Are you sure for delete?", "Delete customer", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          cmCollection.Customercollection.Remove((Customer)listViewCustomer.SelectedItem);
        }
      }
      else if (((Button)sender).Name == "BtnDeleteProduct")
      {
        if (listViewProduct.SelectedItem == null)
        {
          return;
        }
        else if (MessageBox.Show("Are you sure for delete?", "Delete product", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          prCollection.Productcollection.Remove((Product)listViewProduct.SelectedItem);
        }
      }
    }

    private void BtnEditEmployee_OnClick(object sender, RoutedEventArgs e)
    {
      EditEmployeeWindow edit = new EditEmployeeWindow();
      edit.Show();
      var itemList = listViewEmployee.SelectedItem;
    }
  }
}
