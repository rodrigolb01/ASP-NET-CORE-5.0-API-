using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Services;
using WebApplication3.Extensions;
using WebApplication3.Resources;

namespace WebApplication3.Controllers
{

    [Route("/api/[Controller]")]
    [Authorize()]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper) //set
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync() //get
        {
            var company = await _companyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(company);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);//
            var result = await _companyService.SaveAsync(company);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Company, CompanyResource>(result.Company);

            return Ok(categoryResource);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Company, CompanyResource>(result.Company);
            return Ok(categoryResource);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _companyService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Company);
            return Ok(companyResource);
        }
    }
}
