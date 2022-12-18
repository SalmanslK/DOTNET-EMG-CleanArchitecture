using CleanArchitecture.Business.DTOs;
using CleanArchitecture.Business.Interfaces;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CleanArchitecture.Business.Decorators
{
    public class EmployeeServiceLoggingDecorator : IEmployeeService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeServiceLoggingDecorator> _logger;

        public EmployeeServiceLoggingDecorator(IEmployeeService employeeService,
                                              ILogger<EmployeeServiceLoggingDecorator> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<EmployeeDTO> Add(AddEmployeeDTO entity)
        {
            _logger.LogInformation("Starting to add data...");

            var stopwatch = Stopwatch.StartNew();

            var employee = await _employeeService.Add(entity);

            _logger.LogInformation($"Employee ID: {employee.Id} is successfully added.");

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished adding data in {elapsedTime} milliseconds.");

            return employee;
        }

        public async Task Delete(EmployeeDTO entity)
        {
            _logger.LogInformation("Starting to delete data...");

            var stopwatch = Stopwatch.StartNew();

            await _employeeService.Delete(entity);

            _logger.LogInformation($"Employee ID: {entity.Id} is now deleted if existed before.");

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished deleting data in {elapsedTime} milliseconds.");
        }

        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            _logger.LogInformation("Starting to fetch data...");

            var stopwatch = Stopwatch.StartNew();

            var employees = await _employeeService.Get();

            foreach (var employee in employees)
            {
                _logger.LogInformation($"Employee ID: {employee.Id}, Name: {employee.Name}");
            }

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds.");

            return employees;
        }

        public async Task<EmployeeDTO> Get(int id)
        {
            _logger.LogInformation("Starting to fetch data...");

            var stopwatch = Stopwatch.StartNew();

            var employee = await _employeeService.Get(id);

            _logger.LogInformation($"Employee ID: {employee.Id}, Name: {employee.Name}");

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds.");

            return employee;
        }

        public async Task<bool> Update(EmployeeDTO entity)
        {
            _logger.LogInformation("Starting to update data...");

            var stopwatch = Stopwatch.StartNew();

            var isUpdated = await _employeeService.Update(entity);

            _logger.LogInformation($"Employee ID: {entity.Id} is {(isUpdated ? "successfully" : "not")} updated.");

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished updating data in {elapsedTime} milliseconds.");

            return isUpdated;
        }
    }
}
