using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Productmanagement.Model.Models;

namespace Productmanagement.Model.BaseClasses
{
  public class CustomerCollection
  {
    public CustomerCollection()
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

    private ObservableCollection<Customer> _customerCollection =
      new ObservableCollection<Customer>();

    public ObservableCollection<Customer> Customercollection
    {
      get
      {
        return _customerCollection;
      }
    }
  }
}
