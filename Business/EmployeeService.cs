using Business.Domain;
using Business.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Business
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployees(string filePath)
        {

            filePath = @"C:\Users\Robin\file.csv"; // Local path
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = false,
                MissingFieldFound=null
            };

            List<Employee> employees = new List<Employee>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                employees = csv.GetRecords<Employee>().ToList();

                return employees;
            }
        }
    }
}
