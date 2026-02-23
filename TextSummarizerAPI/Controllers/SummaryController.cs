using Microsoft.AspNetCore.Mvc;
using TextSummarizerAPI.Services;

namespace TextSummarizerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryController : ControllerBase
    {
        private readonly ClaudeService _claudeService;

        public SummaryController(ClaudeService claudeService)
        {
            _claudeService = claudeService;
        }

        [HttpPost]
        public async Task<IActionResult> Summarize([FromBody] SummarizeRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                return BadRequest("Text is required.");

            var summary = await _claudeService.SummarizeTextAsync(request.Text);
            return Ok(new { summary });
        }
    }

    public class SummarizeRequest
    {
        public string Text { get; set; } = "";
    }
}