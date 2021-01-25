using System;
using System.Collections.Generic;
using System.Text;

namespace Productmanagement.DataLayer.Interface
{
  public interface IProduct
  {
    int Id { get; set; }
    string Name { get; set; }
    string Author { get; set; }
    decimal Price { get; set; }

    string GetBasicInfo();
  }
}
