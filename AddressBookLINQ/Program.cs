using System;

namespace AddressBookLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AddressBook Service Using LINQ");
            AddressBookManagement management = new AddressBookManagement();

            Console.WriteLine("\n--------------Display DataTable------------");
            management.Display();
            management.RetrieveCountByType();

            
        }
    }
}
