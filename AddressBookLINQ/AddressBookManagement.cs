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
        public AddressBookManagement()
        {
            //Creating Data Table
            DataTable dataTable = new DataTable();

            //Adding Columns to the Data Table
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("State");
            dataTable.Columns.Add("Zip");
            dataTable.Columns.Add("PhoneNumber");
            dataTable.Columns.Add("Email");
        }
    }
}
