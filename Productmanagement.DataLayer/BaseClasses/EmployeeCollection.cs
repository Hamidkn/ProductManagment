using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Productmanagement.Model.Models;

namespace Productmanagement.Model.BaseClasses
{
  public class EmployeeCollection
  {
    private ObservableCollection<Employee> _employeesCollection =
      new ObservableCollection<Employee>();

    public ObservableCollection<Employee> Employeescollection
    {
      get
      {
        return _employeesCollection;
      }
    }

    public EmployeeCollection()
    {
      ReadEmployees();
    }

    private void ReadEmployees()
    {
      _employeesCollection.Add(
        new Employee()
        {
          Id = 0,
          FirstName = "Hamid",
          LastName = "Keshmiri",
          PhoneNumber = 773569389,
          Address = "Plzen",
          Department = Department.Production
        });
      _employeesCollection.Add(
        new Employee()
        {
          Id = 1,
          FirstName = "Franta",
          LastName = "Mach",
          PhoneNumber = 773569564,
          Address = "Plzen",
          Department = Department.Advertisement
        });
    }

    public void AddProduct(Employee employee)
    {
      if (employee != null)
      {
        _employeesCollection.Add(employee);
      }
    }

    public bool DeleteProduct(string employeeName)
    {
      var employee = _employeesCollection.First(e => e.FullName == employeeName);
      _employeesCollection.Remove(employee);
      return true;
    }

    public void UpdateProduct(Employee employee)
    {
      var newemployee = _employeesCollection.First(p => p.Id == employee.Id);
      var index = _employeesCollection.IndexOf(newemployee);
      _employeesCollection[index] = employee;
    }
  }
}
