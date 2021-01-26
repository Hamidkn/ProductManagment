using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Productmanagement.Model.Models;

namespace Productmanagement.Model.BaseClasses
{
  public class EmployeeCollection
  {
    public EmployeeCollection()
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
          Id = 0,
          FirstName = "Hamid",
          LastName = "Keshmiri",
          PhoneNumber = 773569389,
          Address = "Plzen",
          Department = Department.Production
        });
    }

    private ObservableCollection<Employee> _employeesCollection =
      new ObservableCollection<Employee>();

    public ObservableCollection<Employee> Employeescollection
    {
      get
      {
        return _employeesCollection;
      }
    }
  }
}
