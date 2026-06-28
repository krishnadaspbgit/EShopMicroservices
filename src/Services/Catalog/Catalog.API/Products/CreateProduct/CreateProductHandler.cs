using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name,List<string> Category,string Description,string ImageFile,decimal Price)
        :ICommand<CreateProductresult>;
    public record CreateProductresult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductresult>
    {
        public async Task<CreateProductresult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Create Product Entity from command object
            //Save to Database
            //return Create Product Result

            var Product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };


            return  new CreateProductresult(Guid.NewGuid());
        }
    }
}
