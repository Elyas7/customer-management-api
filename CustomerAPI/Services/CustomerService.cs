using CustomerAPI.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace CustomerAPI.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepositorycs _customerRepositorycs;

        public CustomerService(ICustomerRepositorycs customerRepositorycs)
        {
            _customerRepositorycs = customerRepositorycs;
        }

        public void AddCustomer(Customer customer)
        {
            ValidateCustomer(customer);

            _customerRepositorycs.AddCustomer(customer);

            NotifyAdmin(customer);
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerRepositorycs.GetAllCustomer();
        }

        private void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Email))
            {
                throw new Exception("Email is required");
            }

            var phoneRegex = new Regex(@"^\d{10}$");
            if (!phoneRegex.IsMatch(customer.PhoneNumber))
            {
                throw new Exception("Phone number must be 10 digits");
            }

            var nameRegex = new Regex(@"^[a-zA-Z]+$");
            if (!nameRegex.IsMatch(customer.FirstName) || !nameRegex.IsMatch(customer.LastName))
            {
                throw new Exception("First and Last Name should only contain alphabetic characters.");
            }

        }
        private void NotifyAdmin(Customer customer)
        {
            Console.WriteLine($"Notification: A new customer {customer.Email} has been added");
        }
    }
}
