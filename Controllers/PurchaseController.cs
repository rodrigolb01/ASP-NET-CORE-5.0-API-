using AutoMapper;
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
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService purchaseService, IMapper mapper)
        {
            this._purchaseService = purchaseService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PurchaseResource>> GetAllAsync()
        {
            var purchases = await _purchaseService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)                                         //if body is balid
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);//create instance of purchase
            var result = await _purchaseService.SaveAsync(purchase);            //save instance

            if (!result.Success)
                return BadRequest(result.Message);

            var PurchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);

            return Ok(PurchaseResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);//create instance of user
            var result = await _purchaseService.UpdateAsync(id, purchase);            //Update instance

            if (!result.Success)
                return BadRequest(result.Message);

            var PurchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);

            return Ok(PurchaseResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _purchaseService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var purchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(purchaseResource);
        }
    }
}
