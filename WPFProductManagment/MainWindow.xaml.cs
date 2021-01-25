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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFProductManagment.View.Pages;

namespace WPFProductManagment.View
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private Home _home = new Home();

    public MainWindow()
    {
      InitializeComponent();
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      _home.Show();
    }
  }
}
