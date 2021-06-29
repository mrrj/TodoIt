using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class TodoSequencer
    {

        private static int todoId;
        public static int TodoId { get => todoId; set => todoId = value; }

        public static int NextTodoId()
        {
            TodoId++;
            return TodoId;
        }

        public static void Reset()
        {
            TodoId = 0;
        }
    }
}
