using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var payment = _paymentRepository.ListById(id);
            
            return Ok(payment);
        }

        [HttpPost]
        public IActionResult Register(PaymentModel? paymentModel)
        {
            if (paymentModel == null)
            {
                return BadRequest(new { Error = "Payment data can't be null" });
            }

            _paymentRepository.Register(paymentModel);

            return CreatedAtAction(nameof(Find), new {id = paymentModel}, paymentModel);
        }

        [HttpPost]
        public IActionResult Update(PaymentModel? paymentModel)
        {
            if (ModelState.IsValid)
            {
                var payment = new PaymentModel()
                {
                    Name = paymentModel?.Name,
                    Cellphone = paymentModel?.Cellphone,
                    Date = paymentModel.Date,
                    Mail = paymentModel.Mail,
                    SaledItems = paymentModel.SaledItems,
                    TaxRoll = paymentModel.TaxRoll
                };

                payment = _paymentRepository.Update(payment);
                return Ok(payment);
            }
            return Ok();
        }
    };
}