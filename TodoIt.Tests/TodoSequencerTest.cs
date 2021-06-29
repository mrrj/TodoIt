using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoIt.Data;

namespace TodoIt.Tests
{
    public class TodoSequencerTest
    {
        [Fact]
        public void PersonIdZeroAfterReset()
        {
            TodoSequencer.Reset();

            Assert.Equal(0, TodoSequencer.TodoId);
        }

    }
}
