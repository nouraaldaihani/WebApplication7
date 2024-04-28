namespace WebApplication7.Models
{
    public class BankBranch
    {

        public List<Employee> Employees { get; set; } = new();
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string LocationURL { get; set; }

        public string BranchManager { get; set; }

        public string EmployeeCount { get; set; }



    }
}
