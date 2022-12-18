using CleanArchitecture.Data.Interfaces;
using CleanArchitecture.DataFactory.Interfaces;

namespace CleanArchitecture.DataFactory
{
    public class DataFactory : IDataFactory
    {
        public IEmployeeRepository FactoryMethod(string type)
        {

            return type switch
            {
                "ADO" => new CleanArchitecture.ADO.Repositories.EmployeeRepository(),
                "EF" => new CleanArchitecture.EF.Repositories.EmployeeRepository(),
                _ => throw new ArgumentException("Invalid type", nameof(type)),
            };
        }
    }
}