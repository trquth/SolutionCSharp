using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBy
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GroupID { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> CustomerList = new List<Customer>();
            CustomerList.Add(new Customer { ID = 1, Name = "One", GroupID = 1 });
            CustomerList.Add(new Customer { ID = 2, Name = "Two", GroupID = 1 });
            CustomerList.Add(new Customer { ID = 3, Name = "Three", GroupID = 2 });
            CustomerList.Add(new Customer { ID = 4, Name = "Four", GroupID = 1 });
            CustomerList.Add(new Customer { ID = 5, Name = "Five", GroupID = 4 });
            CustomerList.Add(new Customer { ID = 6, Name = "Six", GroupID = 4 });
            CustomerList.Add(new Customer { ID = 7, Name = "Seven", GroupID = 4 });
            CustomerList.Add(new Customer { ID = 8, Name = "Eight", GroupID = 3 });
            CustomerList.Add(new Customer { ID = 9, Name = "Nice", GroupID = 3 });
            CustomerList.Add(new Customer { ID = 10, Name = "Ten", GroupID = 5 });
            var result = CustomerList.OrderBy(x => x.GroupID);
            foreach (var item in result)
            {
                Console.WriteLine("----->Name: {0}", item.Name);
            }
            Console.ReadLine();

        }
    }
}
