using NUnit.Framework;

namespace SOLID.SRP.Test
{
    // Dla osób starszych niz 65 lat zniżka 30 + ile lat powyżej 65. Przykład dla 67 lat zniżka 32%
    // Dla studentów zniżka 25%
    public class BookingServiceTests
    {
        public class TestDisplayer : IDisplayer
        {
            private string _previousInfo;
            public void WriteLine(string info)
            {
                _previousInfo = info;
            }   
            public bool WasDisplayed(string info)             
            {
                return _previousInfo == info;
            }
        }

        [Test]
        public void ShouldDisplayInformationForStudent()
        {
            TestDisplayer testDisplayer = new TestDisplayer();
            BookingService bookingService = new BookingService(testDisplayer);
            Person person = new Person
            {
                Id = 1, 
                FirstName = "",
                LastName = "",
                Age = 18,
                IsStudent = true,
                Money = 100
            };
            PersonOder personOder = bookingService.CreateOrder(person, Product.MoneyTransfer);
            Assert.IsTrue(testDisplayer.WasDisplayed("Discounts for student: 25%"));
        }
        [Test]
        public void ShouldReturn25ForStudent()
        {
            BookingService bookingService = new BookingService(new InfoDisplayer());
            Person person = new Person
            {
                Id = 1, 
                FirstName = "",
                LastName = "",
                Age = 18,
                IsStudent = true,
                Money = 100
            };
            PersonOder personOder = bookingService.CreateOrder(person, Product.MoneyTransfer);
            Assert.AreEqual(25, personOder.Discount);
        }
        
        [Test]
        public void ShouldReturn32ForAge67()
        {
            BookingService bookingService = new BookingService(new InfoDisplayer());
            Person person = new Person
            {
                Id = 1, 
                FirstName = "",
                LastName = "",
                Age = 67,
                IsStudent = false,
                Money = 100
            };
            PersonOder personOder = bookingService.CreateOrder(person, Product.MoneyTransfer);
            Assert.AreEqual(32, personOder.Discount);
        }

        [Test]
        public void ShouldReturn35ForAge66AndIsStudent()
        {
            BookingService bookingService = new BookingService(new InfoDisplayer());
            Person person = new Person
            {
                Id = 1, 
                FirstName = "",
                LastName = "",
                Age = 66,
                IsStudent = true,
                Money = 100
            };
            PersonOder personOder = bookingService.CreateOrder(person, Product.MoneyTransfer);
            Assert.AreEqual(35, personOder.Discount);
        }
    }
}