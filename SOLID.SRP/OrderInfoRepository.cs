using System;
using System.IO;

namespace SOLID.SRP
{
    class OrderInfoRepository 
    {
        public static void SaveOrderInformation(Person person, PersonOder order)
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

        private static string CreateFolderIfDoesNotExist(DateTime date)
        {
            string DirectoryPath = @"E:\Code\DevEnv\SOLID";
            var currentPath = Path.Combine(DirectoryPath, $"{date:yyyy-dd-MM}");
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }

            return currentPath;
        }
    }
}
