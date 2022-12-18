using CleanArchitecture.Business.DTOs;
using CleanArchitecture.Business.Interfaces;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Interfaces;
using CleanArchitecture.DataFactory.Enumerations;

namespace CleanArchitecture.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new DataFactory.DataFactory().FactoryMethod(DomainEnum.ADO.ToString());
        }

        /// <summary>    
        /// Get all employee records from the DB    
        /// </summary>    
        /// <returns>List<Employee></returns>    
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            return (await _employeeRepository.Get()).Select(x => new EmployeeDTO()
            {

                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Gender = x.Gender
            }).ToList();
        }

        /// <summary>    
        /// Get employee detail by id    
        /// </summary>    
        /// <param name="id"></param>    
        /// <returns>Employee</returns>    
        public async Task<EmployeeDTO> Get(int id)
        {
            var data = await _employeeRepository.Get(id);
            return new EmployeeDTO()
            {
                Id = data.Id,
                Name = data.Name,
                Age = data.Age,
                Gender = data.Gender
            };
        }

        /// <summary>    
        /// Update the employee details    
        /// </summary>    
        /// <param name="employee"></param>
        /// <returns></returns>    
        public async Task<bool> Update(EmployeeDTO employee)
        {
            var data = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Gender = employee.Gender
            };
            return await _employeeRepository.Update(data);
        }

        /// <summary>    
        /// Insert employee record into DB    
        /// </summary>    
        /// <param name="employee"></param>  
        /// <returns></returns>    
        public async Task<EmployeeDTO> Add(AddEmployeeDTO employee)
        {
            var data = new Employee()
            {
                Name = employee.Name,
                Age = employee.Age,
                Gender = employee.Gender
            };

            data = await _employeeRepository.Add(data);

            var result = new EmployeeDTO()
            {
                Id = data.Id,
                Name = data.Name,
                Age = data.Age,
                Gender = data.Gender
            };

            return result;
        }

        /// <summary>    
        /// Delete employee based on ID    
        /// </summary>    
        /// <param name="id"></param>    
        /// <returns></returns>    
        public async Task Delete(EmployeeDTO employee)
        {
            var data = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Gender = employee.Gender
            };
            await _employeeRepository.Delete(data);
        }
    }
}
