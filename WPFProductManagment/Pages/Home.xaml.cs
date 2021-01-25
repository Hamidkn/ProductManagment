using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFProductManagment.Pages
{
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Home : Window
  {
    public Home()
    {
      InitializeComponent();
    }

    private void BtnHome_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Visible;
      EmployessPanel.Visibility = Visibility.Collapsed;
      ProductsPanel.Visibility = Visibility.Collapsed;
      CustomersPanel.Visibility = Visibility.Collapsed;
    }

    private void BtnCustomer_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Collapsed;
      EmployessPanel.Visibility = Visibility.Collapsed;
      ProductsPanel.Visibility = Visibility.Collapsed;
      CustomersPanel.Visibility = Visibility.Visible;
    }

    private void BtnEmployee_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Collapsed;
      EmployessPanel.Visibility = Visibility.Visible;
      ProductsPanel.Visibility = Visibility.Collapsed;
      CustomersPanel.Visibility = Visibility.Collapsed;
    }

    private void BtnProducts_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Collapsed;
      EmployessPanel.Visibility = Visibility.Collapsed;
      ProductsPanel.Visibility = Visibility.Visible;
      CustomersPanel.Visibility = Visibility.Collapsed;
    }
  }
}
