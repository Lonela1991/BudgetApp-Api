namespace BudgetApp.Data.Entities;

public class Forecast
{
    public int ForecastId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int Budget { get; set; }
    public int ActualMonth { get; set; }
    public DateTime Date { get; set; }
    public string ProductName { get; set; } = string.Empty;

    public Product Product { get; set; } = null!;
}

/// <summary>ProductId har ingen FK i originalschemat — lägg till senare för referentiell integritet.</summary>
public class ForecastAmountPerProduct
{
    public int ForecastAmountId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int Month { get; set; }
    public int ForecastAmount { get; set; }
    public bool Locked { get; set; }
}

public class ActualAmountPerForecast
{
    public int ActualAmountId { get; set; }
    public string ProductId { get; set; } = string.Empty;
    public int Month { get; set; }
    public int ActualAmount { get; set; }
    public bool Locked { get; set; }
}