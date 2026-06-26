namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price);
    public record CreateProductresult(Guid Id);
    public class CreateProductHandler
    {
    }
}
