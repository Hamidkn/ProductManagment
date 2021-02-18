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
}
