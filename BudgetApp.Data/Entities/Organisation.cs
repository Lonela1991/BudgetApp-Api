namespace BudgetApp.Data.Entities;

public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; } = new List<DepartmentEmployee>();
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class Employee
{
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int MonthlySalary { get; set; }
    public string EmploymentRate { get; set; } = string.Empty;
    public string VacancyDeduction { get; set; } = string.Empty;
    public decimal? WorkYears { get; set; }
    public bool? Locked { get; set; }

    public User? User { get; set; }
    public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; } = new List<DepartmentEmployee>();
    public ICollection<ProductAllocation> ProductAllocations { get; set; } = new List<ProductAllocation>();
}

public class DepartmentEmployee
{
    public int DepartmentId { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public decimal? WorkYears { get; set; }
    public bool? Locked { get; set; }

    public Department Department { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}

/// <summary>Notera: PasswordHash ska innehålla en riktig hash (t.ex. via ASP.NET Core Identity)</summary>
public class User
{
    public string EmployeeId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int Role { get; set; }

    public Employee Employee { get; set; } = null!;
}

public class Activity
{
    public string ActivityId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;
    public ICollection<CostBudgetPerActivity> CostBudgets { get; set; } = new List<CostBudgetPerActivity>();
    public ICollection<DirectCostPerActivity> DirectCosts { get; set; } = new List<DirectCostPerActivity>();
}