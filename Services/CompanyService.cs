using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Communication;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Repositories;
using WebApplication3.Domain.Services;

namespace WebApplication3.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch (Exception ex)
            {
                //DO some logging stuff
                return new CompanyResponse($"An error occured when saving company: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found!");

            existingCompany.NomeFantasia = company.NomeFantasia;

            try
            {
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new CompanyResponse($"An error occured when updating the company: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
            {
                return new CompanyResponse("Company not found.");
            }

            try
            {
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new CompanyResponse($"An error occured when deleing the company: { ex.Message}");
            }
        }
    }

}
