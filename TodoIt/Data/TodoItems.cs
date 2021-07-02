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

        public Todo MakeTodoItem(String description)
        {
            Todo todo = new Todo(description);
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = todo;
            return todo;
        }

        public void Clear()
        {
            Array.Resize(ref items, 0);
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] statusItems = new Todo[0];
            for(int i = 0; i < items.Length; i++)
            {
                if(items[i].Done == doneStatus)
                {
                    Array.Resize(ref statusItems, statusItems.Length + 1);
                    statusItems[statusItems.Length - 1] = items[i];
                }
            }
            return statusItems;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] assigneeItems = new Todo[0];
            for (int i = 0; i < items.Length; i++)
            {
                Person itemAssignee = items[i].Assignee;
                if (itemAssignee != null && itemAssignee.PersonId == personId)
                {
                    Array.Resize(ref assigneeItems, assigneeItems.Length + 1);
                    assigneeItems[assigneeItems.Length - 1] = items[i];
                }
            }
            return assigneeItems;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] assigneeItems = new Todo[0];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Assignee == assignee)
                {
                    Array.Resize(ref assigneeItems, assigneeItems.Length + 1);
                    assigneeItems[assigneeItems.Length - 1] = items[i];
                }
            }
            return assigneeItems;
        }
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] noAssignee = new Todo[0];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Assignee == null)
                {
                    Array.Resize(ref noAssignee, noAssignee.Length + 1);
                    noAssignee[noAssignee.Length - 1] = items[i];
                }
            }
            return noAssignee;
        }

        public void RemoveItem(int itemId)
        {
            int itemIndex = Array.FindIndex<Todo>(items, item => item.TodoId == itemId);

            for(int i = itemIndex; i < items.Length-1 ; i++)
            {
                items[i] = items[i + 1];
            }
            Array.Resize<Todo>(ref items, items.Length - 1);
        }
    }
}
