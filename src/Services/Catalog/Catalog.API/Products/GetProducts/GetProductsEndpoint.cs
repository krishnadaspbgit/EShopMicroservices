
namespace Catalog.API.Products.GetProducts
{

    public record GetProductsResponse(IEnumerable<Product>Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {

                var results = await sender.Send(new GetProductsQuery());
                var Response = results.Adapt<GetProductsResponse>();
                return Results.Ok(Response);

            })
          .WithName("GetProducts")
          .Produces<GetProductsResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithSummary("Get Products")
          .WithDescription("Get Products");
        }
    }
}
