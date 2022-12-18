using CleanArchitecture.Data;
using CleanArchitecture.Data.Constants;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Interfaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CleanArchitecture.EF.Repositories
{
    public class Context : DbContext
    {
        public Context() : base(DataConstants.ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Employee> Employees { get; set; }
    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly Context _context = new Context();

        public override async Task<Employee> Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employee;
        }

        public override async Task Delete(Employee employee)
        {
            var dbEmployee = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (dbEmployee != null)
            {
                _context.Employees.Remove(dbEmployee);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Employee Not Found with id " + employee.Id);
            }
        }

        public override async Task<IEnumerable<Employee>> Get()
        {
            return _context.Employees;
        }

        public override async Task<Employee> Get(int id)
        {
            var dbEmployee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (dbEmployee == null)
            {
                Console.WriteLine("Employee Not Found with id " + id);
                dbEmployee = new Employee();
            }
            return dbEmployee;
        }

        public override async Task<bool> Update(Employee employee)
        {
            var updated = true;
            var dbEmployee = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (dbEmployee != null)
            {
                dbEmployee.Name = employee.Name;
                dbEmployee.Age = employee.Age;
                dbEmployee.Gender = employee.Gender;
                _context.SaveChanges();
            }
            else
            {
                updated = false;
                Console.WriteLine("Employee Not Found with id " + employee.Id);
            }
            return updated;
        }
    }
}
