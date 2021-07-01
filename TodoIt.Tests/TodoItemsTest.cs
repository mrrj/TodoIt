using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class TodoItemsTest
    {

        [Fact]
        public void ItemsLengthIncreasesByOne()
        {
            TodoItems itemsTest = new TodoItems();
            int before = itemsTest.Size();

            String description = "Pick flowers";

            itemsTest.MakeTodoItem(description);
            int after = itemsTest.Size();

            Assert.Equal(before + 1, after);
            itemsTest.Clear();
        }

        [Fact]
        public void SizeIsZeroAfterClear()
        {
            TodoItems itemsTest = new TodoItems();

            itemsTest.MakeTodoItem("Pick flowers");
            itemsTest.MakeTodoItem("Bake cake");

            itemsTest.Clear();

            int expectedLength = 0;
            int actualLength = itemsTest.Size();

            Assert.Equal(expectedLength, actualLength);
            itemsTest.Clear();

        }

        [Fact]
        public void SizeReturnsCorrectLength()
        {
            TodoItems items = new TodoItems();

            items.MakeTodoItem("Eat an apple.");
            items.MakeTodoItem("Make coffee");
            items.MakeTodoItem("Get a pen.");


            int expectedLength = 3;
            int actualLength = items.Size();

            Assert.Equal(expectedLength, actualLength);
            TodoSequencer.Reset();

        }

        [Fact]
        public void FindByIdReturnsRightItem()
        {
            TodoItems items = new TodoItems();

            Todo eatApple = items.MakeTodoItem("Eat an apple.");
            Todo makeCoffee = items.MakeTodoItem("Make coffee");
            Todo getPen = items.MakeTodoItem("Get a pen.");

            Todo expectedItem = makeCoffee;
            int idOfExpected = expectedItem.TodoId;

            Todo actualItem= items.FindById(idOfExpected);

            Assert.Equal(expectedItem, actualItem);
            items.Clear();
        }

        [Fact]
        public void NonExistantIdThrowsException()
        {
            
            TodoItems items = new TodoItems();

            Todo eatApple = items.MakeTodoItem("Eat an apple.");
            Todo makeCoffee = items.MakeTodoItem("Make coffee");
            Todo getPen = items.MakeTodoItem("Get a pen.");

            int failId = TodoSequencer.NextTodoId();

            Assert.Throws<ArgumentException>(() => items.FindById(failId));
            items.Clear();
        }


    }
}
