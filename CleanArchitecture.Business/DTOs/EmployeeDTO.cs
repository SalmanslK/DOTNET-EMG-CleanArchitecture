namespace CleanArchitecture.Business.DTOs
{
    public class EmployeeDTO : AddEmployeeDTO
    {
        public int Id { get; set; }
    }

    public class AddEmployeeDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
