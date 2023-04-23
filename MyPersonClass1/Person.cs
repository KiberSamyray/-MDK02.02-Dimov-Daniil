﻿using System;
using System.Globalization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyPersonClass1
{  
    public class Person
    {
        private string firstName;
        private string lastName;
        public string FirstName { get { return firstName; } set { firstName = value; firstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName.ToLower()); } }
        public string LastName { get { return lastName; } set { lastName = value;  lastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastName.ToLower()); } }
        public int Age(DateTime Birthday)
        {
            return (int)(DateTime.Now.Subtract(Birthday).Days / 365.25);
        }
    }
}