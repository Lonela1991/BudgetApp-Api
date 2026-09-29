namespace BudgetApp.Api.Dtos;

public record ProductDto(
    string ProductId,
    string Name,
    int DepartmentId,
    string ProductGroupId,
    string ProductCategoryId);