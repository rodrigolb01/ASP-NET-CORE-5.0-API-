using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Communication;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Repositories;
using WebApplication3.Domain.Services;


namespace WebApplication3.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository, IUnitOfWork unitOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Purchase>> ListAsync()
        {
            return await _purchaseRepository.ListAsync();
        }
        public async Task<PurchaseResponse> SaveAsync(Purchase purchase)
        {
            try
            {
                await _purchaseRepository.AddAsync(purchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(purchase);
            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new PurchaseResponse($"An error occured when saving the purchase: {ex.Message}");
            }
        }
        public async Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase)
        {
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id); //retorna solicitacao incorreta, se nao existe

            if (existingPurchase == null)
                return new PurchaseResponse("Purchase not found.");

            existingPurchase.Id = purchase.Id;// Name

            try
            {
                _purchaseRepository.Update(existingPurchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(existingPurchase);
            }
            catch (Exception ex)
            {
                return new PurchaseResponse($"An error occurend when updating the purchase: {ex.Message}");
            }
        }

        public async Task<PurchaseResponse> DeleteAsync(int id)
        {
            var existingPurchase = await _purchaseRepository.FindByIdAsync(id);

            if (existingPurchase == null)
                return new PurchaseResponse("Purchase not found.");

            try
            {
                _purchaseRepository.Remove(existingPurchase);
                await _unitOfWork.CompleteAsync();
                return new PurchaseResponse(existingPurchase);

            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new PurchaseResponse($"An error occured when deleting the purchase: {ex.Message}");
            }
        }
    }
}

