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
  /// Interaction logic for AddEditCustomerWindow.xaml
  /// </summary>
  public partial class AddEditCustomerWindow : Window
  {
    private CustomerCollection _cmrCollection;
    private bool isEdit = false;
    private Customer _customer;
    public AddEditCustomerWindow(CustomerCollection customerCollection)
    {
      InitializeComponent();
      _cmrCollection = customerCollection;
    }

    public AddEditCustomerWindow(CustomerCollection customerCollection, Customer cm)
    {
      InitializeComponent();
      _cmrCollection = customerCollection;
      _customer = cm;
      isEdit = true;
      TxtFirstName.Text = cm.FirstName;
      TxtLastName.Text = cm.LastName;
      TxtAddress.Text = cm.Address;
      TxtPhone.Text = cm.PhoneNumber.ToString();
    }

    private void BtnSave_OnClick(object sender, RoutedEventArgs e)
    {
      if (isEdit)
      {
        Customer customer = new Customer()
        {
          Id = _customer.Id,
          FirstName = TxtFirstName.Text,
          LastName = TxtLastName.Text,
          Address = TxtAddress.Text,
          PhoneNumber = Convert.ToUInt64(TxtPhone.Text)
        };
        _cmrCollection.UpdateCustomer(customer);
      }
      else
      {
        Customer customer = new Customer()
        {
          Id = _cmrCollection.GetNextId(),
          FirstName = TxtFirstName.Text,
          LastName = TxtLastName.Text,
          Address = TxtAddress.Text,
          PhoneNumber = Convert.ToUInt64(TxtPhone.Text)
        };
        _cmrCollection.AddCustomer(customer);
      }

      Close();
    }

    private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
