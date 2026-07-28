using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/quotes")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }



        [HttpPost("best")]
        public async Task<IActionResult> Best()
        {
            var response = await _quoteService.CreateBestQuoteAsync();
            return Ok(response);
        }
    }
}
