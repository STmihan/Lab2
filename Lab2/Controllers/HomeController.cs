using Lab2.DTO;
using Lab2.Services;
using Lab2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserService _userService;

    private readonly HomeViewModel _homeViewModel = new();

    public HomeController(ILogger<HomeController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        _homeViewModel.Users = await _userService.GetUsers();
        return View(_homeViewModel);
    }

    [HttpPost]
    public IActionResult Index([Bind("Name,SecondName,Email")]UserDTO user)
    {
        _userService.AddUser(user);
        return RedirectToAction("Index");
    }
    
    [HttpPost("delete")]
    public IActionResult Delete([Bind("Id")] int id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction("Index");
    }
}