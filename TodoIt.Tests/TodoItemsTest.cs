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
        public void PersonIdZeroAfterReset()
        {
            TodoItems.Reset();

            Assert.Equal(0, TodoItems.TodoId);
        }

    }
}
