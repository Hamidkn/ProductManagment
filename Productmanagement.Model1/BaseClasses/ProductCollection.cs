using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Productmanagement.Model.Models;

namespace Productmanagement.Model.BaseClasses
{
  public class ProductCollection
  {
    private ObservableCollection<Product> _productCollection =
      new ObservableCollection<Product>();

    public ObservableCollection<Product> Productcollection
    {
      get
      {
        return _productCollection;
      }
    }

    public ProductCollection()
    {
      ReadProducts();
    }

    private void ReadProducts()
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

    public void AddProduct(Product product)
    {
      if (product != null)
      {
        _productCollection.Add(product);
      }
    }

    public bool DeleteProduct(string productName)
    {
      var product = _productCollection.First(p => p.Name == productName);
      _productCollection.Remove(product);
      return true;
    }

    public void UpdateProduct(Product product)
    {
      var newProduct = _productCollection.First(p => p.Id == product.Id);
      var index = _productCollection.IndexOf(newProduct);
      _productCollection[index] = product;
    }

    public int GetNextId()
    {
      return _productCollection.Any() ? _productCollection.Max(p => p.Id) + 1 : 1;
    }
  }
}
