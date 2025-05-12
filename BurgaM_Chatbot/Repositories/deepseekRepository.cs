using BurgaM_Chatbot.Interfaces;

namespace BurgaM_Chatbot.Repositories
{
    public class deepseekRepository : IchatbotServices
    {
        public async Task<string> GetChatbotResponse(string prompt) 
        {

            return "Este es un String de DeepSeek";
        
        }
    }
}
