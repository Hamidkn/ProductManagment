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

namespace WPFProductManagment.View.Pages
{
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Index : Window
  {
    private Border border;

    public Index()
    {
      InitializeComponent();
    }

    private void Btn_OnClick(object sender, RoutedEventArgs e)
    {
      border.Name = (string) ((Button)sender).Content;
      var result = border.Name;
      border.Visibility = Visibility.Visible;
    }

    /*private void BtnHome_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Visible;
      EmployeesPanel.Visibility = Visibility.Collapsed;
      ProductsPanel.Visibility = Visibility.Collapsed;
      CustomersPanel.Visibility = Visibility.Collapsed;
    }

    private void BtnCustomer_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Collapsed;
      EmployeesPanel.Visibility = Visibility.Collapsed;
      ProductsPanel.Visibility = Visibility.Collapsed;
      CustomersPanel.Visibility = Visibility.Visible;
    }

    private void BtnEmployee_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Collapsed;
      EmployeesPanel.Visibility = Visibility.Visible;
      ProductsPanel.Visibility = Visibility.Collapsed;
      CustomersPanel.Visibility = Visibility.Collapsed;
    }

    private void BtnProducts_OnClick(object sender, RoutedEventArgs e)
    {
      HomePanel.Visibility = Visibility.Collapsed;
      EmployeesPanel.Visibility = Visibility.Collapsed;
      ProductsPanel.Visibility = Visibility.Visible;
      CustomersPanel.Visibility = Visibility.Collapsed;
    }*/

    /*private void Twitter_OnClick(object sender, RoutedEventArgs e)
    {
      var url = new ProcessStartInfo("http://www.twitter.com")
      {
        UseShellExecute = true,
        Verb = "open"
      };
      System.Diagnostics.Process.Start(url);
    }

    private void Facebook_OnClick(object sender, RoutedEventArgs e)
    {
      var url = new ProcessStartInfo("http://www.facebook.com")
      {
        UseShellExecute = true,
        Verb = "open"
      };
      Process.Start(url);
    }

    private void Linkedin_OnClick(object sender, RoutedEventArgs e)
    {
      var url = new ProcessStartInfo("http://www.linkedin.com")
      {
        UseShellExecute = true,
        Verb = "open"
      };
      Process.Start(url);
    }

    private void Blogger_OnClick(object sender, RoutedEventArgs e)
    {
      var url = new ProcessStartInfo("http://www.blogger.com")
      {
        UseShellExecute = true,
        Verb = "open"
      };
      Process.Start(url);
    }*/

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
