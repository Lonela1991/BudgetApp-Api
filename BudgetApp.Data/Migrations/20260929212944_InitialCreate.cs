using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    StandardCost = table.Column<int>(type: "int", nullable: false),
                    RequiredReturn = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "ActualAmountsPerForecast",
                columns: table => new
                {
                    ActualAmountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    ActualAmount = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualAmountsPerForecast", x => x.ActualAmountId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCategoryTypes",
                columns: table => new
                {
                    CustomerCategoryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategoryTypes", x => x.CustomerCategoryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlySalary = table.Column<int>(type: "int", nullable: false),
                    EmploymentRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacancyDeduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkYears = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ForecastAmountsPerProduct",
                columns: table => new
                {
                    ForecastAmountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    ForecastAmount = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastAmountsPerProduct", x => x.ForecastAmountId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    ProductGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEmployees",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkYears = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEmployees", x => new { x.DepartmentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DepartmentEmployees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProductGroupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostBudgetsPerActivity",
                columns: table => new
                {
                    CostBudgetPerActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DirectCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostBudgetsPerActivity", x => x.CostBudgetPerActivityId);
                    table.ForeignKey(
                        name: "FK_CostBudgetsPerActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectCostsPerActivity",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DirectCost = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectCostsPerActivity", x => new { x.AccountNumber, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_DirectCostsPerActivity_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectCostsPerActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostBudgetsPerProduct",
                columns: table => new
                {
                    CostBudgetPerProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LaborCost = table.Column<int>(type: "int", nullable: false),
                    DirectCost = table.Column<int>(type: "int", nullable: false),
                    TotalManufacturingCost = table.Column<int>(type: "int", nullable: false),
                    Markup = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostBudgetsPerProduct", x => x.CostBudgetPerProductId);
                    table.ForeignKey(
                        name: "FK_CostBudgetsPerProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectCostsPerProduct",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DirectCost = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectCostsPerProduct", x => new { x.AccountNumber, x.ProductId });
                    table.ForeignKey(
                        name: "FK_DirectCostsPerProduct_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectCostsPerProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    ForecastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    ActualMonth = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.ForecastId);
                    table.ForeignKey(
                        name: "FK_Forecasts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAllocations",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkYears = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAllocations", x => new { x.EmployeeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductAllocations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAllocations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RevenueBudgets",
                columns: table => new
                {
                    RevenueBudgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractAmount = table.Column<int>(type: "int", nullable: false),
                    GradeA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Markup = table.Column<int>(type: "int", nullable: false),
                    GradeT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueBudgets", x => x.RevenueBudgetId);
                    table.ForeignKey(
                        name: "FK_RevenueBudgets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RevenueBudgets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DepartmentId",
                table: "Activities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CostBudgetsPerActivity_ActivityId",
                table: "CostBudgetsPerActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CostBudgetsPerProduct_ProductId",
                table: "CostBudgetsPerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployees_EmployeeId",
                table: "DepartmentEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectCostsPerActivity_ActivityId",
                table: "DirectCostsPerActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectCostsPerProduct_ProductId",
                table: "DirectCostsPerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Forecasts_ProductId",
                table: "Forecasts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAllocations_ProductId",
                table: "ProductAllocations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DepartmentId",
                table: "Products",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueBudgets_CustomerId",
                table: "RevenueBudgets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueBudgets_ProductId",
                table: "RevenueBudgets",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualAmountsPerForecast");

            migrationBuilder.DropTable(
                name: "CostBudgetsPerActivity");

            migrationBuilder.DropTable(
                name: "CostBudgetsPerProduct");

            migrationBuilder.DropTable(
                name: "CustomerCategoryTypes");

            migrationBuilder.DropTable(
                name: "DepartmentEmployees");

            migrationBuilder.DropTable(
                name: "DirectCostsPerActivity");

            migrationBuilder.DropTable(
                name: "DirectCostsPerProduct");

            migrationBuilder.DropTable(
                name: "ForecastAmountsPerProduct");

            migrationBuilder.DropTable(
                name: "Forecasts");

            migrationBuilder.DropTable(
                name: "ProductAllocations");

            migrationBuilder.DropTable(
                name: "RevenueBudgets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
