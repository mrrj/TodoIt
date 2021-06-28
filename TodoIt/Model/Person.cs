using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Person
    {
        private readonly int personId;

        private String firstName;
        private String lastName;

        public string FirstName 
        { get => firstName; 
          set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace.");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public string LastName 
        {          
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace.");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public Person(String firstName, String lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        
    }
}
