using System;
using System.Data;

namespace Northwind
{
    public class NorthwindDb
    {
        public static string GetData()
        {
            var result = "";
            var dataSet = new DataSet();
            dataSet.ReadXml(@"P:\fringe\northwind.xml");

            var employeeTable = dataSet.Tables["Employees"];

            foreach (DataRow row in employeeTable.Rows)
            {
                var firstName = Convert.ToString(row["FirstName"]);
                var lastName = Convert.ToString(row["LastName"]);
                var birthdate = Convert.ToDateTime(row["Birthdate"]);
                var retirementDate = birthdate.AddYears(65);

                var isRetired = retirementDate < DateTime.Now;
                if (!isRetired)
                    continue;

                result += $"{firstName} {lastName}: {retirementDate}\r\n";
            }

            return result;
        }
    }
}
