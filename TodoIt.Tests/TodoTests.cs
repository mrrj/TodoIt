using System;
using Xunit;
using TodoIt.Model;

namespace TodoIt.Tests
{
    public class TodoTests
    {
        [Fact]
        public void CorrectDescription()
        {
            String testDescription = "Get a pen.";

            Todo todo = new Todo(5, testDescription);

            Assert.Equal(testDescription, todo.Description);
        }


    }
}
