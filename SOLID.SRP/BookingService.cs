using System;

namespace SOLID.SRP
{
    public class BookingService
    {
        public PersonOder CreateOrder(Person person, Product product)
        {
            if (person.Age < 18)
            {
                Console.WriteLine("Too young to buy!!!!");
                throw new Exception();
            }

            decimal basePrice = 0.0m;

            switch (product)
            {
                case Product.MoneyTransfer:
                    basePrice = 25.0m;
                    break;
                case Product.Newspaper:
                    basePrice = 15.0m;
                    break;
                case Product.Ticket:
                    basePrice = 15.0m;
                    break;
            }

            int discount = 0;
            if (person.Age == 66 && person.IsStudent)
            {
                discount =  35;
                Console.WriteLine($"Discounts for old student: 35%");
            }
            else if (person.Age > 65)
            {
                discount =  32;
                Console.WriteLine($"Discounts for old: {discount}%");
            }
            else if (person.IsStudent)
            {
                discount = 25;
                Console.WriteLine("Discounts for student: 25%");
            }

            var order = new PersonOder
            {
                Person = person,
                Product = product,
                Price = basePrice -  basePrice * (discount / 100.0m),
                Discount = discount
            };
            return order; 
        }
    }
}
