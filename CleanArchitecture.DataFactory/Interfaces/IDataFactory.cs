using CleanArchitecture.Data.Interfaces;

namespace CleanArchitecture.DataFactory.Interfaces
{
    public interface IDataFactory
    {
        IEmployeeRepository FactoryMethod(string type);
    }
}
