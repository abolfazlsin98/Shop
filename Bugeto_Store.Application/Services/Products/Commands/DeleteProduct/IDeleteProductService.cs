using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Products.Commands.DeleteProduct
{
    public interface IDeleteProductService
    {
        ResultDto Execute(long productId);
    }

    public class DeleteProductService : IDeleteProductService
    {
        private readonly IDataBaseContext _context;

        public DeleteProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long productId)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                _context.Products.Remove(product);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت حذف شد",
                };
            }
            return new ResultDto
            {
                IsSuccess = false,
                Message = "محصولی پیدا نشد",
            };

        }
    }
}