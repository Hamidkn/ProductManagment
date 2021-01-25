﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Productmanagement.DataLayer.Models
{
  public enum Department
  {
    Production,
    Sales,
    Advertisement,
    Management
  }
  public class Employee : IPerson
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Address { get; set; }
    public decimal BaseSalary { get; set; }
    public Department Department { get; set; }
    public string GetBasicInfo()
    {
      return $"Name: {FirstName} {LastName}, Phone: {PhoneNumber},\nAddress: {Address}, Department: {Department}, Base Salary: {BaseSalary}";
    }
  }
}