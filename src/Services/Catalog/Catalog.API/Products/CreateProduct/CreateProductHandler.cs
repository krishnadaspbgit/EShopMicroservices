
namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price)
        : ICommand<CreateProductresult>;


    public record CreateProductresult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }



    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductresult>
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

            session.Store(Product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductresult(Product.Id);
        }
    }
}
