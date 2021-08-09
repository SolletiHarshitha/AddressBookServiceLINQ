using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLINQ
{
    public class AddressBookManagement
    {
        //Creating Data Table
        public readonly DataTable dataTable = new DataTable();

        public AddressBookManagement()
        {
            //Adding Columns to the Data Table
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("State");
            dataTable.Columns.Add("Zip");
            dataTable.Columns.Add("PhoneNumber");
            dataTable.Columns.Add("Email");
            //Adding AddressBookName and Type
            dataTable.Columns.Add("AddressBookName");
            dataTable.Columns.Add("ContactType");

            //Adding Rows to the Data Table
            dataTable.Rows.Add("Koushik", "V", "TekkaMitta", "Nellore", "Andhra Pradesh", 524003, 9878686765, "koushik@gmail.com","Family","Family");
            dataTable.Rows.Add("Nikitha", "S", "SriSainath Nagar", "Tirupathi", "Andhra Pradesh", 517102, 8939302849, "nikitha@gmail.com","Friend","Friend");
            dataTable.Rows.Add("Mukesh", "S", "Magunta Layout", "Nellore", "Andhra Pradesh", 524003, 90504039690, "mukesh@gmail.com","Professtion","Profession");
            dataTable.Rows.Add("Sushmitha", "T", "Kanigiri Road", "Pamur", "Andhra Pradesh", 523108, 8494839494, "sushmitha@gmail.com", "Professtion", "Profession");
            dataTable.Rows.Add("Akhilesh", "S", "Anna Nagar", "Chennai", "Tamil Nadu", 600102, 8393993894, "akhilesh@gmail.com", "Family", "Family");
            dataTable.Rows.Add("Snehitha", "T", "Kanigiri Road", "Pamur", "Andhra Pradesh", 523108, 8949894859, "snehitha@gmail.com", "Friend", "Friend");
            dataTable.Rows.Add("Shanthan", "V", "CMBT", "Chennai", "Tamil Nadu", 600107, 9409490394, "shanthan@gmail.com", "Friend", "Friend");
            dataTable.Rows.Add("Bhuvana", "T", "TekkaMitta", "Nellore", "Andhra Pradesh", 524003, 8943949949, "bhuvana@gmail.com", "Family", "Family");
            dataTable.Rows.Add("Satya", "T", "MG Road", "Chennai", "Tamil Nadu",600020 , 9484948494, "satya@gmail.com", "Friend", "Friend");
            dataTable.Rows.Add("Ajith", "T", "Mogalrajapuram", "Vijaywada", "Andhra Pradesh", 520010, 9904949430, "ajith@gmail.com", "Professtion", "Profession");

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["PhoneNumber"] };
            
        }
        //Edit the Data Table 
        public void EditByName()
        {
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                if(dataTable.Rows[i][0].ToString()=="Mukesh")
                {
                    dataTable.Rows[i][0] = "Rajesh";
                }
            }
        }
        //Display the Data Table
        public void Display()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach(DataColumn column in dataTable.Columns)
                {
                    Console.Write(row[column] +"\t");
                }
                Console.WriteLine("\n");
            }
        }
        //Delete a row in Data Table by Name
        public void DeleteByName()
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][0].ToString() == "Mukesh")
                {
                    dataTable.Rows[i].Delete();
                }
            }
        }
        //Retrieve by city or state
        public void RetrieveByCityOrState()
        {
            Console.WriteLine("1.Search by city\n2.Search by State\nChoose an options");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    Console.WriteLine("Choose a City");
                    string city = Console.ReadLine();
                    var result = dataTable.AsEnumerable().Where(x => x.Field<string>("City").Contains(city));
                    foreach (var contact in result)
                    {
                        foreach (var data in contact.ItemArray)
                        {
                            Console.Write(data + " ");
                        }
                        Console.WriteLine("\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Choose a State");
                    string state = Console.ReadLine();
                    var res = dataTable.AsEnumerable().Where(x => x.Field<string>("State").Contains(state));
                    foreach (var contact in res)
                    {
                        foreach (var data in contact.ItemArray)
                        {
                            Console.Write(data + " ");
                        }
                        Console.WriteLine("\n");
                    }
                    break;
            }
            
        }
        //Count by city or state
        public void CountByCityOrState()
        {
            Console.WriteLine("1.Count by city\n2.Count by State\nChoose an options");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter name of the City");
                    string city = Console.ReadLine();
                    var result = dataTable.AsEnumerable().Where(x => x.Field<string>("City").Contains(city));
                    int cityCount = result.Count();
                    Console.WriteLine("Count of contacts in {0} is {1}", city, cityCount);
                    break;
                case 2:
                    Console.WriteLine("enter name of the State");
                    string state = Console.ReadLine();
                    var res = dataTable.AsEnumerable().Where(x => x.Field<string>("State").Contains(state));
                    int stateCount = res.Count();
                    Console.WriteLine("Count of contacts in {0} is {1}",state,stateCount);
                    break;
            }

        }   
        //Sort name for given city
        public void SortNameByCity()
        {
            Console.WriteLine("Enter name of the city");
            string city = Console.ReadLine();
            var result = dataTable.AsEnumerable().OrderBy(x => x.Field<string>("FirstName"))
                .Where(x => x.Field<string>("City").Contains(city));
            foreach (var contact in result)
            {
                foreach (var data in contact.ItemArray)
                {
                    Console.Write(data + " ");
                }
                Console.WriteLine("\n");
            }
        } 
        //Retrieve Count by Type
        public void RetrieveCountByType()
        {
            string str = null;
            var result = (from ContactDetails in dataTable.AsEnumerable()
                          .GroupBy(x => new { ContactType = x["ContactType"] })
                          select ContactDetails);
            foreach(var res in result)
            {
                str = res.Count() + " ";
                Console.WriteLine("Count of {0} is {1}",res.Key,str);
            }
        }
    }
}
