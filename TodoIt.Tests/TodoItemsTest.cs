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
            TodoSequencer.Reset();
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
            TodoSequencer.Reset();
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
            TodoSequencer.Reset();
        }

        [Fact]
        public void FindByDoneStatusContainsCorrectItems()
        {

            TodoItems items = new TodoItems();

            Todo eatApple = items.MakeTodoItem("Eat an apple.");
            Todo makeCoffee = items.MakeTodoItem("Make coffee");
            Todo getPen = items.MakeTodoItem("Get a pen.");

            eatApple.Done = true;
            getPen.Done = true;

            Todo[] doneItems = items.FindByDoneStatus(true);

            Assert.Contains<Todo>(eatApple, doneItems);
            Assert.Contains<Todo>(getPen, doneItems);
            Assert.DoesNotContain<Todo>(makeCoffee, doneItems);
            
            items.Clear();
            TodoSequencer.Reset();
        }

        [Fact]
        public void FindByAssigneeIdReturnsCorrectItems()
        {

            TodoItems items = new TodoItems();

            Todo eatApple = items.MakeTodoItem("Eat an apple.");
            Todo makeCoffee = items.MakeTodoItem("Make coffee");
            Todo getPen = items.MakeTodoItem("Get a pen.");
            Person ellen = new Person("Ellen", "Skog");
            eatApple.Assignee = ellen;
            int ellensId = ellen.PersonId;

            Todo[] ellensItems = items.FindByAssignee(ellensId);
            
            Assert.Contains<Todo>(eatApple, ellensItems);
            Assert.DoesNotContain<Todo>(makeCoffee,ellensItems);
            Assert.DoesNotContain<Todo>(getPen, ellensItems);

            items.Clear();
            TodoSequencer.Reset();
            PersonSequencer.Reset();
        }

        [Fact]
        public void FindByAssigneePersonReturnsCorrectItems()
        {

            TodoItems items = new TodoItems();

            Todo eatApple = items.MakeTodoItem("Eat an apple.");
            Todo makeCoffee = items.MakeTodoItem("Make coffee");
            Todo getPen = items.MakeTodoItem("Get a pen.");
            Person ellen = new Person("Ellen", "Skog");
            eatApple.Assignee = ellen;

            Todo[] ellensItems = items.FindByAssignee(ellen);

            Assert.Contains<Todo>(eatApple, ellensItems);
            Assert.DoesNotContain<Todo>(makeCoffee, ellensItems);
            Assert.DoesNotContain<Todo>(getPen, ellensItems);

            items.Clear();
            TodoSequencer.Reset();
            PersonSequencer.Reset();
        }

        [Fact]
        public void FindUnnassignedItemsReturnsCorrectItems()
        {

            TodoItems items = new TodoItems();

            Todo eatApple = items.MakeTodoItem("Eat an apple.");
            Todo makeCoffee = items.MakeTodoItem("Make coffee");
            Todo getPen = items.MakeTodoItem("Get a pen.");
            Person ellen = new Person("Ellen", "Skog");
            eatApple.Assignee = ellen;

            Todo[] unassignedItems = items.FindUnassignedTodoItems();

            Assert.Contains<Todo>(makeCoffee, unassignedItems);
            Assert.Contains<Todo>(getPen, unassignedItems);
            Assert.DoesNotContain<Todo>(eatApple, unassignedItems);

            items.Clear();
            TodoSequencer.Reset();
            PersonSequencer.Reset();
        }


    }
}
