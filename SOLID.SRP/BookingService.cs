using System;
using System.IO;

namespace SOLID.SRP
{
    internal class BookingService
    {
        public bool CreateOrder(Person person, Product product)
        {
            ValidateAgeOfPerson(person);

            if (person.Money > 0)
            {
                PersonOder order = CreatePersonOrder(person, product);
                SaveOrderInformation(person, order);
                return true;
            }
            return false;
        }

        private void SaveOrderInformation(Person person, PersonOder order)
        {
            var date = DateTime.Now;
            string currentPath = CreateFolderIfDoesNotExist(date);

            SaveOrderInfo(person, order, currentPath);
        }

        private static void SaveOrderInfo(Person person, PersonOder order, string currentPath)
        {
            string orderInfo = $"{order.Person.Id}-{order.Product}-{order.Price}";
            Console.WriteLine($"Order Info: {orderInfo}");
            File.WriteAllText(Path.Combine(currentPath, $"{person.Id}.txt"), orderInfo);
        }

        private string CreateFolderIfDoesNotExist(DateTime date)
        {
            string DirectoryPath = @"E:\Code\DevEnv\SOLID";
            var currentPath = Path.Combine(DirectoryPath, $"{date:yyyy-dd-MM}");
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            return currentPath;
        }

        private static PersonOder CreatePersonOrder(Person person, Product product)
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

        private static void ValidateAgeOfPerson(Person person)
        {
            if (person.Age < 18)
            {
                Console.WriteLine("Too young to buy!!!!");
                throw new Exception();
            }
        }
    }
}
