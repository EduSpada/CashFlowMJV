using CashFlowMvc.Application.DTOs;
using CashFlowMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CashFlowMvc.WebUI.Controllers
{
    public class OperationsController : Controller
    {
        private readonly IOperationService _operationService;
        private readonly IPaymentMethodService _paymentMethodService;
        public OperationsController(IOperationService operationService,
                                    IPaymentMethodService paymentMethodService)
        {
            _operationService = operationService;
            _paymentMethodService = paymentMethodService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var operations = await _operationService.GetOperationsAsync();
            return View(operations);
        }
        [Authorize(Roles = "User")]
        [HttpGet()]
        public async Task<IActionResult> ByDate(string? dateOp)
        {   
            var dateOper = Convert.ToDateTime(dateOp);
            var operations = await _operationService.GetByCreatedAtAsync(dateOper);
            return View(operations);
        }
        [Authorize(Roles = "Employer")]
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.PaymentMethodId = new SelectList(await _paymentMethodService.GetPaymentMethodsAsync(), "Id", "Description");
            return View();
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public async Task<IActionResult> Create(OperationDTO operationDto)
        {
            if (ModelState.IsValid)
            {
                await _operationService.CreateAsync(operationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(operationDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest(nameof(id));


            var operationDto = await _operationService.GetByIdAsync(id);

            if (operationDto == null) return NotFound();

            var paymentMethods =await _paymentMethodService.GetPaymentMethodsAsync();

            ViewBag.PaymentMethodId = new SelectList(paymentMethods, "Id", "Description", operationDto.PaymentMethodId);
            return View(operationDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost()]
        public async Task<IActionResult> Edit(OperationDTO operationDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _operationService.UpdateAsync(operationDto);
                }
                catch (Exception) 
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(operationDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var operationDto = await _operationService.GetByIdAsync(id);

            if (operationDto == null) return NotFound();
            
            ViewBag.DirectionId = await _paymentMethodService.GetByIdAsync(operationDto.PaymentMethodId); 

            return View(operationDto);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _operationService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "User")]
        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var operationDto = await _operationService.GetByIdAsync(id);

            if (operationDto == null) return NotFound();

            ViewBag.Direction = await _paymentMethodService.GetByIdAsync(operationDto.PaymentMethodId);

            return View(operationDto);
        }
    }
}
