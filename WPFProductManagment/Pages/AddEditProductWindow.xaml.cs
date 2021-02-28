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
using Productmanagement.Model.BaseClasses;
using Productmanagement.Model.Models;

namespace WPFProductManagment.View.Pages
{
  /// <summary>
  /// Interaction logic for AddEditProductWindow.xaml
  /// </summary>
  public partial class AddEditProductWindow : Window
  {
    private ProductCollection _productCollection;
    private Product _product;
    private bool isEdit;

    public AddEditProductWindow(ProductCollection productCollection)
    {
      InitializeComponent();
      _productCollection = productCollection;
    }

    public AddEditProductWindow(ProductCollection productCollection, Product product)
    {
      InitializeComponent();
      _productCollection = productCollection;
      _product = product;
      isEdit = true;
      TxtName.Text = product.Name;
      TxtAuthor.Text = product.Author;
      TxtPrice.Text = product.Price.ToString();
      TxtAvailable.Text = product.Availablecount.ToString();
    }
    private void BtnSave_OnClick(object sender, RoutedEventArgs e)
    {
      bool isValid = true;
      isValid = CheckValidation();
      if (isValid)
      {
        if (isEdit)
        {
          Product product = new Product()
          {
            Id = _product.Id,
            Name = TxtName.Text,
            Author = TxtAuthor.Text,
            Price = Convert.ToDecimal(TxtPrice.Text),
            Availablecount = Convert.ToInt32(TxtAvailable.Text)
          };
          _productCollection.UpdateProduct(product);
        }
        else
        {
          Product product = new Product()
          {
            Id = _productCollection.GetNextId(),
            Name = TxtName.Text,
            Author = TxtAuthor.Text,
            Price = Convert.ToDecimal(TxtPrice.Text),
            Availablecount = Convert.ToInt32(TxtAvailable.Text)
          };
          _productCollection.AddProduct(product);
        }

        Close();
      }
    }

    private bool CheckValidation()
    {
      bool isValid = true;
      string name = TxtName.Text.Trim();
      string author = TxtAuthor.Text.Trim();
      string price = TxtPrice.Text.Trim();
      string availablecount = TxtAvailable.Text.Trim();

      if (string.IsNullOrEmpty(name))
      {
        isValid = false;
        lblError.Content = "**Name is not valid!";
        TxtName.Text = "";
      }
      else if (string.IsNullOrEmpty(author))
      {
        isValid = false;
        lblError.Content = "**Author is not valid!";
        TxtAuthor.Text = "";
      }
      else if (!decimal.TryParse(price, out decimal p) || Convert.ToDecimal(price) < 10)
      {
        isValid = false;
        lblError.Content = "**Price is not valid!";
        TxtPrice.Text = "";
      }
      else if (!Int32.TryParse(availablecount, out Int32 a) || Convert.ToInt32(availablecount) < 0)
      {
        isValid = false;
        lblError.Content = "**Availablecount is not valid";
        TxtAvailable.Text = "";
      }
      else
      {
        lblError.Content = "";
      }

      return isValid;
    }

    private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
