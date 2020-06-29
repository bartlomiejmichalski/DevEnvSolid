namespace SOLID.SRP
{
    internal class BookingService
    {
        public bool CreateOrder(Person person, Product product)
        {
            AgePersonValidator.Validate(person);

            if (person.Money > 0)
            {
                PersonOder order = PersonOrderFactory.Create(person, product);
                OrderInfoRepository.SaveOrderInformation(person, order);
                return true;
            }
            return false;
        }
    }
}
