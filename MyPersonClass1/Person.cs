using System;
using System.Globalization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyPersonClass1
{  
    public class Person
    {
        private string firstName;
        private string lastName;
        public string FirstName { get { return firstName; } set { firstName = value;  } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public int Age(DateTime Birthday)
        {
            int age = DateTime.Now.Year - Birthday.Year;
            if(DateTime.Now.Month < Birthday.Month || DateTime.Now.Month == Birthday.Month && DateTime.Now.Day < Birthday.Day)
            {
                age--;
            }
            return age;
        }
    }
}
