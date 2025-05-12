using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BurgaM_Chatbot.Models;
using BurgaM_Chatbot.Repositories;
using System.Threading.Tasks;
using BurgaM_Chatbot.Interfaces;

namespace BurgaM_Chatbot.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IchatbotServices _chatbotService;

    public HomeController(ILogger<HomeController> logger, IchatbotServices chatbotServices)
    {
        _logger = logger;
        _chatbotService = chatbotServices;

    }

    public async Task<IActionResult> Index()
    {
        string answer = await _chatbotService.GetChatbotResponse("Cual es el valor de pi");
        return View(answer);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
