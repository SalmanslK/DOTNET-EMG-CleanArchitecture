using CleanArchitecture.Business.DTOs;
using CleanArchitecture.Business.Services;

Console.WriteLine("Project Starting!");

EmployeeService employeeService = new EmployeeService();

var employees = await employeeService.Get();
Console.WriteLine("Get All:");
foreach (var record in employees)
{
    Console.WriteLine($"Record: Id={record.Id}, Name={record.Name}, Age={record.Age}, Gender={record.Gender}");
}

var employee = new EmployeeDTO();
employee.Name = "Insert";
employee.Age = 25;
employee.Gender = "Female";

employee = await employeeService.Add(employee);
Console.WriteLine($"Inserted: Id={employee.Id}, Name={employee.Name}, Age={employee.Age}, Gender={employee.Gender}");

employee.Name = "Updated";
employee.Age = 26;
employee.Gender = "Male";
await employeeService.Update(employee);
employee = await employeeService.Get(employee.Id);
Console.WriteLine($"Inserted: Id={employee.Id}, Name={employee.Name}, Age={employee.Age}, Gender={employee.Gender}");

await employeeService.Delete(employee);
Console.WriteLine($"Record Deleted");

Console.ReadLine();