using System;

namespace SOLID.SRP
{
    class PersonOrderFactory 
    {
        public static PersonOder Create(Person person, Product product)
        {
            decimal basePrice = CalculateBasePrice(product);
            int discount = CalculateDiscount(person);
            return new PersonOder
            {
                Person = person,
                Product = product,
                Price = basePrice - basePrice * (discount / 100.0m)
            };
        }

        private static int CalculateDiscount(Person person)
        {
            int discount = 0;
            if (person.Age > 65)
            {
                discount = 30 + person.Age - 65;
                Console.WriteLine($"Discounts for old: {discount}%");
            }
            else if (person.IsStudent)
            {
                discount = 25;
                Console.WriteLine("Discounts for student: 25%");
            }

            return discount;
        }

        private static decimal CalculateBasePrice(Product product)
        {
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

            return basePrice;
        }
 
    }
}
