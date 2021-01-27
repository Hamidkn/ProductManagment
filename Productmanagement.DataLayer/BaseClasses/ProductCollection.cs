using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Productmanagement.Model.Models;

namespace Productmanagement.Model.BaseClasses
{
  public class ProductCollection
  {
    public ProductCollection()
    {
      _productCollection.Add(
        new Product()
        {
          Id = 0,
          Name = "The subtle art of Not giving a fuck",
          Author = "Mark Menson",
          Price = 350,
          Availablecount = 20
        });
    }

    private ObservableCollection<Product> _productCollection =
      new ObservableCollection<Product>();

    public ObservableCollection<Product> Productcollection
    {
      get
      {
        return _productCollection;
      }
    }
  }
}
