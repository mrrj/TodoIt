using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public static int PersonId { get => personId; set => personId = value; }

        public static int NextPersonId()
        {
            PersonId++;
            return PersonId;
        }

        public static void Reset()
        {
            PersonId = 0;
        }
    }
}
