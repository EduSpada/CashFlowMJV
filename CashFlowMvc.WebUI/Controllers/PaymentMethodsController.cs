using CashFlowMvc.Application.DTOs;
using CashFlowMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowMvc.WebUI.Controllers
{
    [Authorize]
    public class PaymentMethodsController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodsController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var paymentMethods = await _paymentMethodService.GetPaymentMethodsAsync();
            return View(paymentMethods);
        }
        [Authorize(Roles = "Employer")]
        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Employer")]
        [HttpPost]
        public async Task<IActionResult> Create(PaymentMethodDTO paymentMethod)
        {
            if (ModelState.IsValid)
            {
                await _paymentMethodService.CreateAsync(paymentMethod);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }
        [Authorize(Roles = "Manager")]
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest(nameof(id));

            var paymentMethodDto = await _paymentMethodService.GetByIdAsync(id);

            if (paymentMethodDto == null) return NotFound();

            return View(paymentMethodDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost()]
        public async Task<IActionResult> Edit(PaymentMethodDTO paymentMethodDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _paymentMethodService.UpdateAsync(paymentMethodDto);
                }
                catch (Exception) 
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethodDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var paymentMethodDto = await _paymentMethodService.GetByIdAsync(id);

            if (paymentMethodDto == null) return NotFound();

            return View(paymentMethodDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paymentMethodService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "User")]
        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var paymentMethodDto = await _paymentMethodService.GetByIdAsync(id);

            if (paymentMethodDto == null) return NotFound();

            return View(paymentMethodDto);
        }
    }
}
