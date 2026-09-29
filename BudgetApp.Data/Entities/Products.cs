namespace BudgetApp.Data.Entities;

public class Product
{
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public string ProductGroupId { get; set; } = string.Empty;
    public string ProductCategoryId { get; set; } = string.Empty;

    public Department Department { get; set; } = null!;
    public ProductGroup ProductGroup { get; set; } = null!;
    public ProductCategory ProductCategory { get; set; } = null!;

    public ICollection<ProductAllocation> Allocations { get; set; } = new List<ProductAllocation>();
    public ICollection<DirectCostPerProduct> DirectCosts { get; set; } = new List<DirectCostPerProduct>();
    public ICollection<CostBudgetPerProduct> CostBudgets { get; set; } = new List<CostBudgetPerProduct>();
    public ICollection<RevenueBudget> RevenueBudgets { get; set; } = new List<RevenueBudget>();
    public ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();
}

public class ProductGroup
{
    public string ProductGroupId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class ProductCategory
{
    public string ProductCategoryId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class DirectCostPerProduct
{
    public int AccountNumber { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int DirectCost { get; set; }
    public bool? Locked { get; set; }

    public Account Account { get; set; } = null!;
    public Product Product { get; set; } = null!;
}

public class CostBudgetPerProduct
{
    public int CostBudgetPerProductId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int LaborCost { get; set; }
    public int DirectCost { get; set; }
    public int TotalManufacturingCost { get; set; }
    public int Markup { get; set; }
    public int TotalCost { get; set; }

    public Product Product { get; set; } = null!;
}

public class ProductAllocation
{
    public string EmployeeId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public decimal? WorkYears { get; set; }
    public bool? Locked { get; set; }

    public Employee Employee { get; set; } = null!;
    public Product Product { get; set; } = null!;
}