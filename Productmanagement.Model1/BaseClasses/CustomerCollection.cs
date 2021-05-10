using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Productmanagement.Model.Models;
using Productmanagement.Model1;
using Customer = Productmanagement.Models.Customer;

namespace Productmanagement.Model.BaseClasses
{
  public class CustomerCollection
  {
    private ObservableCollection<Customer> _customerCollection =
      new ObservableCollection<Customer>();

    ProductManagementEntities Dataset = new ProductManagementEntities();

    public ObservableCollection<Customer> Customercollection
    {
      get
      {
        return _customerCollection;
      }
    }

    public CustomerCollection(ProductManagementEntities db)
    {
      Dataset = db;
      Dataset.Customers.ToList();
      //ReadCustomers();
    }

    private void ReadCustomers()
    {
      //Dataset.Customers.ToList();
      /*_customerCollection.Add(
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
        });*/
    }

    public void AddCustomer(Model1.Customer customer)
    {
      Dataset.Customers.Add(customer);
    }

    public bool DeleteCustomer(string customerName)
    {
      try
      {
        Dataset.Entry(customerName).State = EntityState.Deleted;
        return true;
      }
      catch
      {
        return false;
      }
    }

    public void UpdateCustomer(Customer customer)
    {
      var newCustomer = Dataset.Customers.First(c => c.Id == customer.Id);
      newCustomer = new Model1.Customer
      {
        Address = customer.Address,
        FirstName = customer.FirstName,
        Id = customer.Id,
        LastName = customer.LastName,
        PhoneNumber = customer.PhoneNumber
      };
      Dataset.Customers.Add(newCustomer);
    }

    public int GetNextId()
    {
      return Dataset.Customers.Any() ? Dataset.Customers.Max(c => c.Id) + 1 : 1;
    }
  }
}
