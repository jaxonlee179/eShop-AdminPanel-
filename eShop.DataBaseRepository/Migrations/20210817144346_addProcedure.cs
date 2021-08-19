using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.DatabaseRepository.Migrations
{
    public partial class addProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create proc GetProducts_SP
                                as
                                begin
	                                select P.PhotoPath, P.Name, C.Name, P.Price, P.[Description], P.Price, U.Name
	                                from products.Products P
	                                inner join products.ProductsInCategories PC on PC.ProductId = P.Id
	                                inner join products.Categories C on PC.CategoryId = C.Id
	                                inner join products.Units U on P.UnitId = U.id 
                                end";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop proc GetProducts_SP";
  
            migrationBuilder.Sql(procedure);
        }
    }
}
