namespace BudgetApp.Data.Entities;

public class Customer
{
    public string CustomerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>Textfält, inte en riktig FK mot CustomerCategoryType — så var det redan i originalschemat.</summary>
    public string CustomerCategory { get; set; } = string.Empty;

    public ICollection<RevenueBudget> RevenueBudgets { get; set; } = new List<RevenueBudget>();
}

public class CustomerCategoryType
{
    public int CustomerCategoryTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class RevenueBudget
{
    public int RevenueBudgetId { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public int ContractAmount { get; set; }
    public string GradeA { get; set; } = string.Empty;
    public int Markup { get; set; }
    public string GradeT { get; set; } = string.Empty;
    public int Budget { get; set; }
    public int? Hours { get; set; }
    public string? Comment { get; set; }
    public bool? Locked { get; set; }

    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;
}