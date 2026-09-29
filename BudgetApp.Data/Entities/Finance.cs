namespace BudgetApp.Data.Entities;

public class Account
{
    public int AccountNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int StandardCost { get; set; }
    public int RequiredReturn { get; set; }
    public bool? Locked { get; set; }

    public ICollection<DirectCostPerActivity> DirectCostsActivity { get; set; } = new List<DirectCostPerActivity>();
    public ICollection<DirectCostPerProduct> DirectCostsProduct { get; set; } = new List<DirectCostPerProduct>();
}

public class DirectCostPerActivity
{
    public int AccountNumber { get; set; }
    public string ActivityId { get; set; } = string.Empty;
    public int DirectCost { get; set; }
    public bool? Locked { get; set; }

    public Account Account { get; set; } = null!;
    public Activity Activity { get; set; } = null!;
}

public class CostBudgetPerActivity
{
    public int CostBudgetPerActivityId { get; set; }
    public string ActivityId { get; set; } = string.Empty;
    public int DirectCost { get; set; }

    public Activity Activity { get; set; } = null!;
}