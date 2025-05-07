namespace BurgaM_Chatbot.Interfaces
{
    public interface IchatbotServices
    {
        public Task<String> GetChatbotResponse(string prompt);
    }
}
