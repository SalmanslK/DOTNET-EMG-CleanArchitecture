using CleanArchitecture.Data;
using CleanArchitecture.Data.Constants;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CleanArchitecture.ADO.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }

        private const string _tableName = "employee";

        /// <summary>    
        /// Get all employee records from the DB    
        /// </summary>    
        /// <returns>List<Employee></returns>    
        public override async Task<IEnumerable<Employee>> Get()
        {
            IEnumerable<Employee> result;
            using SqlConnection con = new(DataConstants.ConnectionString);
            try
            {
                DataTable dt = new();
                con.Open();
                SqlCommand cmd = new($"Select * from {_tableName}", con);
                SqlDataAdapter da = new(cmd);
                da.Fill(dt);

                result = dt.AsEnumerable().Select(x => new Employee
                {
                    Id = x.Field<int>("id"),
                    Name = x.Field<string>("name") ?? string.Empty,
                    Age = x.Field<int>("age"),
                    Gender = x.Field<string>("gender") ?? string.Empty
                });
            }
            catch (Exception ex)
            {
                result = new List<Employee>();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return result;
        }

        /// <summary>    
        /// Get employee detail by id    
        /// </summary>    
        /// <param name="id"></param>    
        /// <returns>Employee</returns>    
        public override async Task<Employee> Get(int id)
        {
            Employee result;
            using SqlConnection con = new(DataConstants.ConnectionString);
            try
            {
                DataTable dt = new();
                con.Open();
                SqlCommand cmd = new($"Select * from {_tableName} where id={id}", con);
                SqlDataAdapter da = new(cmd);
                da.Fill(dt);

                result = new Employee()
                {
                    Id = (int)dt.Rows[0]["id"],
                    Name = (string)dt.Rows[0]["name"],
                    Age = (int)dt.Rows[0]["age"],
                    Gender = (string)dt.Rows[0]["gender"]

                };
            }
            catch (Exception ex)
            {
                result = new Employee();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return result;
        }

        /// <summary>    
        /// Update the employee details    
        /// </summary>    
        /// <param name="employee"></param>
        /// <returns></returns>    
        public override async Task<bool> Update(Employee employee)
        {
            bool result;
            using SqlConnection con = new(DataConstants.ConnectionString);
            try
            {
                string query = $"Update {_tableName} SET name=@name, age=@age , gender=@gender where id=@id";
                SqlCommand cmd = new(query, con);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@id", employee.Id);

                con.Open();
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return result;
        }

        /// <summary>    
        /// Insert employee record into DB    
        /// </summary>    
        /// <param name="employee"></param>  
        /// <returns></returns>    
        public override async Task<Employee> Add(Employee employee)
        {
            using SqlConnection con = new(DataConstants.ConnectionString);
            try
            {
                string query = $"Insert into {_tableName} (name, age, gender) values(@name, @age , @gender)";
                query += " SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new(query, con);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);

                con.Open();
                employee.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return employee;
        }

        /// <summary>    
        /// Delete employee based on ID    
        /// </summary>    
        /// <param name="id"></param>    
        /// <returns></returns>    
        public override async Task Delete(Employee employee)
        {
            using SqlConnection con = new(DataConstants.ConnectionString);

            try
            {
                string query = $"Delete from {_tableName} where id=@id";
                SqlCommand cmd = new(query, con);
                cmd.Parameters.AddWithValue("@id", employee.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

    }
}
