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


    public ActionResult Jugar ()
    {
        ViewBag.palabra = juegoAhorcado.palabra;
        ViewBag.palabraParcial = juegoAhorcado.palabraParcial;
        ViewBag.intentos = juegoAhorcado.intentos;
        ViewBag.letrasUsadas = juegoAhorcado.letrasUsadas;
        return View("Juego");
    }
    public IActionResult compararLetra(char letra)
    {
        ViewBag.intentos = juegoAhorcado.intentos;
       bool termine = juegoAhorcado.matchLetra(letra);
     if (termine)
     {
        ViewBag.palabra = juegoAhorcado.palabra;
        return View ("Ganaste");
     } else 
     {
       return RedirectToAction("Jugar");
     }
    }
    public IActionResult matchPalabra(string palabra)
    {
        ViewBag.intentos = juegoAhorcado.intentos;
        bool termine = juegoAhorcado.matchPalabra(palabra);
        if(termine)
        {
            ViewBag.palabra = juegoAhorcado.palabra;
            return View ("Ganaste");

        }else
        {
            ViewBag.palabra = juegoAhorcado.palabra;
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
