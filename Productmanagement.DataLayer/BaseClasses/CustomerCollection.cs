using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Productmanagement.Model.Models;

namespace Productmanagement.Model.BaseClasses
{
  public class CustomerCollection
  {
    private ObservableCollection<Customer> _customerCollection =
      new ObservableCollection<Customer>();

    public ObservableCollection<Customer> Customercollection
    {
      get
      {
        return _customerCollection;
      }
    }

    public CustomerCollection()
    {
      ReadCustomers();
    }

    private void ReadCustomers()
    {
      _customerCollection.Add(
        new Customer()
        {
          Id = 0,
          FirstName = "Hamid",
          LastName = "Keshmiri",
          PhoneNumber = 773569389,
          Address = "Plzen",
        });
      _customerCollection.Add(
        new Customer()
        {
          Id = 1,
          FirstName = "Franta",
          LastName = "Mach",
          PhoneNumber = 773569564,
          Address = "Plzen",
        });
      _customerCollection.Add(
        new Customer()
        {
          Id = 2,
          FirstName = "Mohsen",
          LastName = "Rezaei",
          PhoneNumber = 773585564,
          Address = "Plzen",
        });
    }

    public void AddCustomer(Customer customer)
    {
      _customerCollection.Add(customer);
    }

    public bool DeleteCustomer(string customerName)
    {
      var customer = _customerCollection.First(c => c.FullName == customerName);
      _customerCollection.Remove(customer);
      return true;
    }

    public void UpdateCustomer(Customer customer)
    {
      var newCustomer = _customerCollection.First(c => c.Id == customer.Id);
      int index = _customerCollection.IndexOf(newCustomer);
      _customerCollection[index] = customer;
    }
  }
}
