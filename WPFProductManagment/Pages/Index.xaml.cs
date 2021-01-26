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

namespace WPFProductManagment.View.Pages
{
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Index : Window
  {
    private Border border = new Border();

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
        ProductsPanel.Visibility = Visibility.Collapsed;
        CustomersPanel.Visibility = Visibility.Collapsed;
        List<EmployeeCollection> emCollection = new List<EmployeeCollection>();
        //DataContext = emCollection.Employeescollection;
        dataGrid.ItemsSource = emCollection;
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
  }
}
