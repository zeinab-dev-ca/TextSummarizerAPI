using System.Text;
using System.Text.Json;

namespace TextSummarizerAPI.Services
{
    public class ClaudeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ClaudeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ClaudeApiKey"] ?? "";
        }

        public async Task<string> SummarizeTextAsync(string text)
        {
            var requestBody = new
            {
                model = "claude-haiku-4-5-20251001",
                max_tokens = 300,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $"Please summarize the following text in 2-3 concise sentences:\n\n{text}"
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");

            var response = await _httpClient.PostAsync("https://api.anthropic.com/v1/messages", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(responseString);
            if (doc.RootElement.TryGetProperty("content", out var contentArray))
            {
                return contentArray[0].GetProperty("text").GetString()?.Trim() ?? "Could not summarize.";
            }
            return "Could not summarize.";
        }
    }
}