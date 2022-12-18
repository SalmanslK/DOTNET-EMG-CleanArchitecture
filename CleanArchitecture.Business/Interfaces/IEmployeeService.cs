using CleanArchitecture.Business.DTOs;

namespace CleanArchitecture.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> Get();
        Task<EmployeeDTO> Get(int id);
        Task<EmployeeDTO> Add(AddEmployeeDTO entity);
        Task<bool> Update(EmployeeDTO entity);
        Task Delete(EmployeeDTO entity);
    }
}
