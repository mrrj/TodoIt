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
            PersonSequencer.Reset();
            People peopleTest = new People();
            int before = peopleTest.Size();

            peopleTest.MakePerson("Glade", "Johan");
            int after = peopleTest.Size();

            Assert.Equal(before + 1, after);
            peopleTest.Clear();
            PersonSequencer.Reset();
        }
       
        [Fact]
        public void SizeIsZeroAfterClear()
        {
            People peopleTest = new People();

            peopleTest.MakePerson("Anna", "Johansson");
            peopleTest.MakePerson("Evert", "Taube");
            peopleTest.MakePerson("Lille", "Skutt");

            peopleTest.Clear();

            int expectedLength = 0;
            int actualLength = peopleTest.Size();

            Assert.Equal(expectedLength, actualLength);
            peopleTest.Clear();
            PersonSequencer.Reset();
        }

        [Fact]
        public void SizeReturnsCorrectLength()
        {
            People peopleTest = new People();

            peopleTest.MakePerson("Anna", "Johansson");
            peopleTest.MakePerson("Evert", "Taube");
            peopleTest.MakePerson("Lille", "Skutt");

            int expectedLength = 3;
            int actualLength = peopleTest.Size();

            Assert.Equal(expectedLength, actualLength);
            peopleTest.Clear();
            PersonSequencer.Reset();

        }

        [Fact]
        public void FindByIdReturnsRightPerson()
        {
            People peopleTest = new People();

            Person anna = peopleTest.MakePerson("Anna", "Johansson");
            Person evert = peopleTest.MakePerson("Evert", "Taube");
            Person lilleSkutt = peopleTest.MakePerson("Lille", "Skutt");

            Person expectedPerson = evert;
            int idOfExpected = expectedPerson.PersonId;

            Person actualPerson = peopleTest.FindById(idOfExpected);

            Assert.Equal(expectedPerson, actualPerson);
            peopleTest.Clear();
            PersonSequencer.Reset();
        }

        [Fact]
        public void NonExistantIdThrowsException()
        {
            People peopleTest = new People();

            peopleTest.MakePerson("Anna", "Johansson");
            peopleTest.MakePerson("Evert", "Taube");
            peopleTest.MakePerson("Lille", "Skutt");

            int failId = PersonSequencer.NextPersonId();

            Assert.Throws<ArgumentException>(() => peopleTest.FindById(failId));
            peopleTest.Clear();
            PersonSequencer.Reset();
        }

    }
}
