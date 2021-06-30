using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void PersonsLengthIncreasesByOne()
        {
            People peopleTest = new People();
            int before = peopleTest.Size();

            peopleTest.MakePerson("Glade", "Johan");
            int after = peopleTest.Size();

            Assert.Equal(before + 1, after);

        }
       

        
    }
}
