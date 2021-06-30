using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class TodoItems
    {
        private static Todo[] items = new Todo[0];

        public static Todo[] Items { get => items; }

        public int Size()
        {
            return Items.Length;
        }

        public Todo[] FindAll()
        {
            return Items;
        }

        public Todo FindById(int todoId)
        {

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].TodoId == todoId)
                {
                    return Items[i];
                }
            }

            throw new ArgumentException("There is no Todo item with that ID.");

        }

        public Todo MakeTodoItem(int todoId, String description)
        {
            Todo todo = new Todo(todoId, description);
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = todo;
            return todo;
        }

        public void Clear()
        {
            Array.Resize(ref items, 0);
            TodoSequencer.Reset();
        }

    }
}
