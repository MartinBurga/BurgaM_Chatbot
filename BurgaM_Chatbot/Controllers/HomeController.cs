using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BurgaM_Chatbot.Models;
using BurgaM_Chatbot.Repositories;
using System.Threading.Tasks;

namespace BurgaM_Chatbot.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        geminiRepository repo = new geminiRepository();
        string answer = await repo.GetChatbotResponse("Cual es el valor de pi");


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
