using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId;
        private String description;
        private bool done;
        private Person assignee;

        public string Description
        { 
            get => description;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description cannot be empty or whitespace.");
                }
                else
                {
                    description = value;
                }
            }
        }

        public int TodoId => todoId;

        public Todo(int todoId, String description)
        {
            this.todoId = todoId;
            this.Description = description;

        }

    }
}
