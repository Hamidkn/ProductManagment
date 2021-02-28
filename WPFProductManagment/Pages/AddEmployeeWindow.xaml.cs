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
  /// Interaction logic for EditWindow.xaml
  /// </summary>
  public partial class AddEmployeeWindow : Window
  {
    private EmployeeCollection _employeeCollection;
    private bool isEdit = false;
    private Employee _employee;

    public AddEmployeeWindow(EmployeeCollection employeeCollection)
    {
      InitializeComponent();
      _employeeCollection = employeeCollection;
    }

    public AddEmployeeWindow(EmployeeCollection employeeCollection, Employee em)
    {
      InitializeComponent();
      _employeeCollection = employeeCollection;
      _employee = em;
      isEdit = true;
      TxtFirstName.Text = em.FirstName;
      TxtLastName.Text = em.LastName;
      TxtAddress.Text = em.Address;
      TxtPhone.Text = em.PhoneNumber.ToString();
      cmbDepartment.SelectedIndex = (int)em.Department;
    }

    private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void BtnSave_OnClick(object sender, RoutedEventArgs e)
    {
      bool isValid = true;
      isValid = Validation();

      if (isValid)
      {
        if (isEdit)
        {
          Employee employee = new Employee()
          {
            Id = _employee.Id,
            FirstName = TxtFirstName.Text,
            LastName = TxtLastName.Text,
            PhoneNumber = Convert.ToUInt64(TxtPhone.Text),
            Address = TxtAddress.Text,
            Department = (Department)cmbDepartment.SelectedIndex,
          };
          _employeeCollection.UpdateEmployee(employee);
        }
        else
        {
          Employee employee = new Employee()
          {
            Id = _employeeCollection.GetNextId(),
            FirstName = TxtFirstName.Text,
            LastName = TxtLastName.Text,
            PhoneNumber = Convert.ToUInt64(TxtPhone.Text),
            Address = TxtAddress.Text,
            Department = (Department)cmbDepartment.SelectedIndex
          };
          _employeeCollection.AddEmployee(employee);
        }

        Close();
      }
    }

    private bool Validation()
    {
      bool isValid = true;
      string firstName = TxtFirstName.Text.Trim();
      string lastName = TxtLastName.Text.Trim();
      string phoneNumber = TxtPhone.Text.Trim();
      string address = TxtAddress.Text.Trim();
      int department = cmbDepartment.SelectedIndex;

      if (string.IsNullOrEmpty(firstName))
      {
        isValid = false;
        lblError.Content = "Enter a valid firstname!";
        TxtFirstName.Text = "";
      }

      else if (string.IsNullOrEmpty(lastName))
      {
        isValid = false;
        lblError.Content = "Enter a valid lastname!";
        TxtLastName.Text = "";
      }

      else if (!ulong.TryParse(phoneNumber, out ulong p))
      {
        isValid = false;
        lblError.Content = "Enter valid phone number!";
        TxtPhone.Text = "";
      }
      else if (string.IsNullOrEmpty(address) || address.Contains("Korea"))
      {
        isValid = false;
        lblError.Content = "Enter a valid address!";
        TxtAddress.Text = "";
      }
      else if (department < 0)
      {
        isValid = false;
        lblError.Content = "**Department is not valid!";
      }

      return isValid;
    }

    private void TxtPhone_OnTextChanged(object sender, TextChangedEventArgs e)
    {
      string phoneNumber = TxtPhone.Text.Trim();
      if (!ulong.TryParse(phoneNumber, out ulong p))
      {
        lblError.Content = "**Enter valid phone number!";
      }
      else
      {
        lblError.Content = "";
      }
    }
  }
}
