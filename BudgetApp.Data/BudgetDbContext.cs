using BudgetApp.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data;

public class BudgetDbContext : DbContext
{
    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<DepartmentEmployee> DepartmentEmployees => Set<DepartmentEmployee>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Activity> Activities => Set<Activity>();

    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<DirectCostPerActivity> DirectCostsPerActivity => Set<DirectCostPerActivity>();
    public DbSet<CostBudgetPerActivity> CostBudgetsPerActivity => Set<CostBudgetPerActivity>();

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductGroup> ProductGroups => Set<ProductGroup>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<DirectCostPerProduct> DirectCostsPerProduct => Set<DirectCostPerProduct>();
    public DbSet<CostBudgetPerProduct> CostBudgetsPerProduct => Set<CostBudgetPerProduct>();
    public DbSet<ProductAllocation> ProductAllocations => Set<ProductAllocation>();

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerCategoryType> CustomerCategoryTypes => Set<CustomerCategoryType>();
    public DbSet<RevenueBudget> RevenueBudgets => Set<RevenueBudget>();

    public DbSet<Forecast> Forecasts => Set<Forecast>();
    public DbSet<ForecastAmountPerProduct> ForecastAmountsPerProduct => Set<ForecastAmountPerProduct>();
    public DbSet<ActualAmountPerForecast> ActualAmountsPerForecast => Set<ActualAmountPerForecast>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasKey(e => e.DepartmentId);

        modelBuilder.Entity<Employee>(e =>
        {
            e.HasKey(x => x.EmployeeId);
            e.Property(x => x.WorkYears).HasPrecision(9, 2);
        });

        modelBuilder.Entity<DepartmentEmployee>(e =>
        {
            e.HasKey(x => new { x.DepartmentId, x.EmployeeId });
            e.HasOne(x => x.Department).WithMany(a => a.DepartmentEmployees).HasForeignKey(x => x.DepartmentId);
            e.HasOne(x => x.Employee).WithMany(p => p.DepartmentEmployees).HasForeignKey(x => x.EmployeeId);
            e.Property(x => x.WorkYears).HasPrecision(9, 2);
        });

        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.EmployeeId);
            e.HasOne(x => x.Employee).WithOne(p => p.User).HasForeignKey<User>(x => x.EmployeeId);
        });

        modelBuilder.Entity<Activity>(e =>
        {
            e.HasKey(x => x.ActivityId);
            e.HasOne(x => x.Department).WithMany(a => a.Activities).HasForeignKey(x => x.DepartmentId);
        });

        modelBuilder.Entity<Account>().HasKey(e => e.AccountNumber);

        modelBuilder.Entity<DirectCostPerActivity>(e =>
        {
            e.HasKey(x => new { x.AccountNumber, x.ActivityId });
            e.HasOne(x => x.Account).WithMany(k => k.DirectCostsActivity).HasForeignKey(x => x.AccountNumber);
            e.HasOne(x => x.Activity).WithMany(a => a.DirectCosts).HasForeignKey(x => x.ActivityId);
        });

        modelBuilder.Entity<CostBudgetPerActivity>(e =>
        {
            e.HasKey(x => x.CostBudgetPerActivityId);
            e.HasOne(x => x.Activity).WithMany(a => a.CostBudgets).HasForeignKey(x => x.ActivityId);
        });

        modelBuilder.Entity<ProductGroup>().HasKey(e => e.ProductGroupId);
        modelBuilder.Entity<ProductCategory>().HasKey(e => e.ProductCategoryId);

        modelBuilder.Entity<Product>(e =>
        {
            e.HasKey(x => x.ProductId);
            e.HasOne(x => x.Department).WithMany(a => a.Products).HasForeignKey(x => x.DepartmentId);
            e.HasOne(x => x.ProductGroup).WithMany(g => g.Products).HasForeignKey(x => x.ProductGroupId);
            e.HasOne(x => x.ProductCategory).WithMany(k => k.Products).HasForeignKey(x => x.ProductCategoryId);
        });

        modelBuilder.Entity<DirectCostPerProduct>(e =>
        {
            e.HasKey(x => new { x.AccountNumber, x.ProductId });
            e.HasOne(x => x.Account).WithMany(k => k.DirectCostsProduct).HasForeignKey(x => x.AccountNumber);
            e.HasOne(x => x.Product).WithMany(p => p.DirectCosts).HasForeignKey(x => x.ProductId);
        });

        modelBuilder.Entity<CostBudgetPerProduct>(e =>
        {
            e.HasKey(x => x.CostBudgetPerProductId);
            e.HasOne(x => x.Product).WithMany(p => p.CostBudgets).HasForeignKey(x => x.ProductId);
        });

        modelBuilder.Entity<ProductAllocation>(e =>
        {
            e.HasKey(x => new { x.EmployeeId, x.ProductId });
            e.HasOne(x => x.Employee).WithMany(p => p.ProductAllocations).HasForeignKey(x => x.EmployeeId);
            e.HasOne(x => x.Product).WithMany(p => p.Allocations).HasForeignKey(x => x.ProductId);
            e.Property(x => x.WorkYears).HasPrecision(9, 2);
        });

        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<CustomerCategoryType>().HasKey(e => e.CustomerCategoryTypeId);

        modelBuilder.Entity<RevenueBudget>(e =>
        {
            e.HasKey(x => x.RevenueBudgetId);
            e.HasOne(x => x.Customer).WithMany(k => k.RevenueBudgets).HasForeignKey(x => x.CustomerId);
            e.HasOne(x => x.Product).WithMany(p => p.RevenueBudgets).HasForeignKey(x => x.ProductId);
        });

        modelBuilder.Entity<Forecast>(e =>
        {
            e.HasKey(x => x.ForecastId);
            e.HasOne(x => x.Product).WithMany(p => p.Forecasts).HasForeignKey(x => x.ProductId);
        });

        modelBuilder.Entity<ForecastAmountPerProduct>().HasKey(e => e.ForecastAmountId);
        modelBuilder.Entity<ActualAmountPerForecast>().HasKey(e => e.ActualAmountId);
    }
}