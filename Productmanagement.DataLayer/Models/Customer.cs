using System;
using System.Collections.Generic;
using System.Text;

namespace Productmanagement.Model.Models
{
  public class Customer : IPerson
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Address { get; set; }

    public string FullName
    {
      get
      {
        return FirstName + " " + LastName;
      }
    }

    public string GetBasicInfo()
    {
      return $"Name: {FirstName} {LastName}, Phone: {PhoneNumber}, Address: {Address}";
    }
  }
}
