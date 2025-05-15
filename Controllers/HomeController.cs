using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_AHORCADO.Models;

namespace TP_AHORCADO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult compararLetra(char letra)
    {
        ViewBag.intentos = juegoAhorcado.intentos;
       bool termine = juegoAhorcado.matchLetra(letra);
     if (termine)
     {
        return View ("Ganaste");
     } else 
     {
        return View ("Juego");
     }
    }
    public IActionResult matchPalabra(string palabra)
    {
        ViewBag.intentos = juegoAhorcado.intentos;
        bool termine = juegoAhorcado.matchPalabra(palabra);
        if(termine)
        {
            return View ("Ganaste");

        }else
        {
            return View("Perdiste");
        }
    }
    public IActionResult completarPalabraParcial(char letra)
    {   
        juegoAhorcado.completarPalabraParcial(letra);
        ViewBag.intentos = juegoAhorcado.intentos;

        return View("Juego");
    }

    public IActionResult Index()
    {
        return View();
    }
}
