using System;
using TodoIt.Data;
using TodoIt.Model;

namespace TodoIt
{
    class Program
    {
        static void Main(string[] args)
        {

            PersonSequencer.Reset();
            People peopleTest = new People();

            Console.WriteLine("People size: " + peopleTest.Size());

            peopleTest.MakePerson("Anna", "Johansson");
            Console.WriteLine("People size: " + peopleTest.Size());
            peopleTest.MakePerson("Evert", "Taube");
            Console.WriteLine("People size: " + peopleTest.Size());
            peopleTest.MakePerson("Lille", "Skutt");
            Console.WriteLine("People size: " + peopleTest.Size());

            TodoSequencer.Reset();
            TodoItems items = new TodoItems();

            Console.WriteLine("Items size: " + items.Size());

            items.MakeTodoItem("Eat an apple.");
            Console.WriteLine("Items size: " + items.Size());
            items.MakeTodoItem("Make coffee");
            Console.WriteLine("Items size: " + items.Size());
            items.MakeTodoItem("Get a pen.");
            Console.WriteLine("Items size: " + items.Size());


        }
    }
}
