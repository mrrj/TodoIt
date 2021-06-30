using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;

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
            TodoSequencer.Reset();

        }

        [Fact]
        public void ClearReturnsArrayOfLengthZero()
        {
            TodoItems itemsTest = new TodoItems();

            itemsTest.MakeTodoItem("Pick flowers");
            itemsTest.MakeTodoItem("Bake cake");

            itemsTest.Clear();

            int expectedLength = 0;
            int actualLength = itemsTest.Size();

            Assert.Equal(expectedLength, actualLength);

        }


    }
}
