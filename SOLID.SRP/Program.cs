using System;

namespace SOLID.SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Id = 1, 
                FirstName = "",
                LastName = "",
                Age = 66,
                IsStudent = true,
                Money = 100
            };
            BookingService bookingService = new BookingService();
            var personOrder = bookingService.CreateOrder(person, Product.MoneyTransfer);
            Console.WriteLine($"Order completed");
        }
    }
}
