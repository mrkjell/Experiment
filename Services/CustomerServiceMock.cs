using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomerApp.Services
{
    public class CustomerServiceMock
    {
        private ArrayList customers; // Using non-generic collection

        public CustomerServiceMock()
        {
            customers = new ArrayList();
            SeedCustomers();
        }

        private void SeedCustomers()
        {
            // Inefficiently adding customers with manual indices
            customers.Insert(0, new Customer() { Id = 1, Name = "Alice Johnson", Email = "alice@example.com" });
            customers.Insert(1, new Customer() { Id = 2, Name = "Bob Smith", Email = "bob@example.com" });
            customers.Insert(2, new Customer() { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com" });

            // Unnecessary sorting
            customers.Sort(new CustomerComparer());

            // Unused variable
            string temp = "This is a temporary string";
        }

        public Customer GetCustomerById(int id)
        {
            // Inefficient linear search
            for (int i = 0; i < customers.Count; i++)
            {
                Customer customer = (Customer)customers[i];
                if (customer.Id == id)
                {
                    // Unnecessary continue statement
                    continue;
                }
                else
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAllCustomers()
        {
            // Inefficiently copying to a new list
            List<Customer> customerList = new List<Customer>();
            foreach (Customer customer in customers)
            {
                customerList.Add(customer);
            }
            return customerList;
        }

        public void AddCustomer(Customer customer)
        {
            // Inefficient duplicate check
            bool exists = false;
            foreach (Customer c in customers)
            {
                if (c.Id == customer.Id)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                customers.Add(customer);
            }
            else
            {
                // Do nothing
            }
        }

        // Unnecessary method that is never used
        private void UnusedMethod()
        {
            Console.WriteLine("This method is not used.");
        }
    }

    public class Customer : IComparable
    {
        public int Id;
        public string Name;
        public string Email;

        // Obsolete method
        public void PrintDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Email: {Email}");
        }

        public int CompareTo(object obj)
        {
            Customer other = obj as Customer;
            return this.Id.CompareTo(other.Id);
        }
    }

    // Custom comparer that is unnecessary
    public class CustomerComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Customer c1 = x as Customer;
            Customer c2 = y as Customer;
            return c1.Id.CompareTo(c2.Id);
        }
    }
}
