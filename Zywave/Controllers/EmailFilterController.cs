using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zywave.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailFilterController : ControllerBase
    {
        private readonly EmailFilterService _emailFilterService;

        public EmailFilterController(EmailFilterService emailFilterService)
        {
            _emailFilterService = emailFilterService;
        }

        [HttpPost]
        public ActionResult<(bool isClassified, string censoredText)> FilterEmail (EmailFilterRequest request)
        {
            var result = _emailFilterService.FilterEmail(request.ClassifiedWords, request.EmailText);
            return Ok(new { isClassified = result.isClassified, censoredText = result.censoredText});
        }

        public class EmailFilterRequest
        {
            public required List<string> ClassifiedWords { get; set;}
            public required string EmailText { get; set;}
        }
    }
}
