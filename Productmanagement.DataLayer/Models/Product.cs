using System;
using System.Collections.Generic;
using System.Text;
using Productmanagement.DataLayer.Interface;

namespace Productmanagement.DataLayer.Models
{
  public class Product : IProduct
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    public int Availablecount { get; set; }

    public string GetBasicInfo()
    {
      return $"Name: {Name}, Author: {Author}, Price: {Price}, Available: {Availablecount}";
    }
  }
}
