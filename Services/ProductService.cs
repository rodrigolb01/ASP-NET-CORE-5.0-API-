using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Communication;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Repositories;
using WebApplication3.Domain.Services;


namespace WebApplication3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new ProductResponse($"An error occured when saving the prouct: {ex.Message}");
            }
        }
        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id); //retorna solicitacao incorreta, se nao existe

            if (existingProduct == null)
                return new ProductResponse("Product not found.");

            existingProduct.Name = product.Name;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error occurend when updating the product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found.");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(existingProduct);

            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new ProductResponse($"An error occured when deleting the product: {ex.Message}");
            }
        }
    }
}
