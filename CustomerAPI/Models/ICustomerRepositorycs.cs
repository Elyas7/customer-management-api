namespace CustomerAPI.Models
{
    public interface ICustomerRepositorycs
    {
        void AddCustomer(Customer customer);
        List<Customer> GetAllCustomer();
    }
}
