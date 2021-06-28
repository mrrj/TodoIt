using System;
using Xunit;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class PersonTests

    {
        [Fact]
        public void EmptyNameThrowsException()
        {
            Person person = new Person("Eva", "Johnsson");

            Assert.Throws<ArgumentException>(() => person.FirstName = "");
            Assert.Throws<ArgumentException>(() => person.LastName = "");

        }

        [Fact]
        public void CorrectNameAfterCreation()
        {
            String firstName = "Lady";
            String lastName = "Gaga";

            Person person = new Person("Lady","Gaga");

            Assert.Equal(firstName,person.FirstName);
            Assert.Equal(lastName,person.LastName);
            
        }
    }
}
