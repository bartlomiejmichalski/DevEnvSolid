using System;

namespace SOLID.SRP
{
    class AgePersonValidator 
    {
        public static void Validate(Person person)
        {
            if (person.Age < 18)
            {
                Console.WriteLine("Too young to buy!!!!");
                throw new Exception();
            }
        }
    }
}
