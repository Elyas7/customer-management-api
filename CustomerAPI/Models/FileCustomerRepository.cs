using Newtonsoft.Json;

namespace CustomerAPI.Models
{
    public class FileCustomerRepository: ICustomerRepositorycs
    {
        private readonly string _filePath = "customers.txt";

        public void AddCustomer(Customer customer)
        {
            try
            {
                var customers = GetAllCustomer();
                customers.Add(customer);
                SaveCustomersToFile(customers);
            }
            catch(IOException ioEx)
            {
                throw new Exception("Error writing to the file.", ioEx);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurrred while adding to the customer. ", ex);
            }
            
        }

        public List<Customer> GetAllCustomer()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Customer>(); // Return an empty list if the file doesn't exist
                }

                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }
            catch (IOException ioEx)
            {
                // Handle file I/O errors
                throw new Exception("Error reading the file.", ioEx);
            }
            catch (JsonException jsonEx)
            {
                // Handle JSON deserialization errors
                throw new Exception("Error parsing customer data.", jsonEx);
            }
            catch (Exception ex)
            {
                // General exception handling
                throw new Exception("An error occurred while retrieving customers.", ex);
            }
        }

        private void SaveCustomersToFile(List<Customer> customers)
        {
            try
            {
                var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (IOException ioEx)
            {
                throw new Exception("Error saving customer data to the file.", ioEx);
            }
        }

    }
}
