using BurgaM_Chatbot.Interfaces;

namespace BurgaM_Chatbot.Repositories
{
    public class geminiRepository : IchatbotServices
    {
        HttpClient _httpClient;
        private string apikey = "AIzaSyAqoiZByXXYeoomt3iHOLHgxZ1yCAHpZC0";
        public geminiRepository()
        {
            _httpClient = new HttpClient();

        }
        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=GEMINI_API_KEY" + apikey;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);

            GeminiRequest request = new GeminiRequest
            {
                Contents = new List<Content>
                {
                    new Content
                    {
                        Parts = new List<Part>
                        {
                            new Part
                            {
                            Text=prompt
                            }
                        }
                    }
                }
            };
            message.Content = JsonContent.Create<GeminiRequest>(request);
            var response = await _httpClient.SendAsync(message);
            string answer = response.Content.ToString();

            return answer;
        }
    }
}
