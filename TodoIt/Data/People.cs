using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class People
    {
        private static Person[] persons = new Person[0];

        public static Person[] Persons { get => persons; }

        public int Size()
        {
            return Persons.Length;
        }

        public Person[] FindAll()
        {
            return Persons;
        }

        public Person FindById(int personId)
        {

            for (int i = 0; i < Persons.Length; i++)
            {
                if(Persons[i].PersonId == personId)
                {
                    return Persons[i];
                }
            }

            throw new ArgumentException("There is no person with that ID.");
            
        }

        public Person MakePerson(String firstName, String lastName)
        {
            Person person = new Person(firstName, lastName);
            Array.Resize(ref persons, persons.Length + 1);
            persons[persons.Length - 1] = person; 
            return person;
        }

        public void Clear()
        {
            Array.Resize(ref persons, 0);
        }

        public void RemovePerson(int personId)
        {
            int itemIndex = Array.FindIndex<Person>(persons, item => item.PersonId == personId);

            for (int i = itemIndex; i < persons.Length - 1; i++)
            {
                persons[i] = persons[i + 1];
            }
            Array.Resize<Person>(ref persons, persons.Length - 1);
        }

    }
}
