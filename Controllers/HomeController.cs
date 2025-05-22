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
        
        juegoAhorcado juego = new juegoAhorcado();
        HttpContext.Session.SetString("juegoDelAhorcado", objeto.ObjetoATexto(juego));
        ViewBag.palabra = juego.palabra;
        ViewBag.palabraParcial = juego.palabraParcial;
        ViewBag.intentos = juego.intentos;
        ViewBag.letrasUsadas = juego.letrasUsadas;
        return View("Juego");
    }
    public IActionResult compararLetra(char letra)
    {

        juegoAhorcado juego = new juegoAhorcado();
        HttpContext.Session.SetString("compararL", objeto.ObjetoATexto(juego));
        ViewBag.intentos = juego.intentos;
       bool termine = juego.matchLetra(letra);
     if (termine)
     {
        ViewBag.palabra = juego.palabra;
        return View ("Ganaste");
     } else 
     {
       return RedirectToAction("Jugar");
     }
    }
    public IActionResult matchPalabra(string palabra)
    {
        juegoAhorcado juego = new juegoAhorcado();
        ViewBag.intentos = juego.intentos;
        bool termine = juego.matchPalabra(palabra);
        if(termine)
        {
            ViewBag.palabra = juego.palabra;
            return View ("Ganaste");

        }else
        {
            ViewBag.palabra = juego.palabra;
            return View("Perdiste");
        }
    }
    public IActionResult completarPalabraParcial(char letra)
    {   
        juegoAhorcado juego = new juegoAhorcado();
        juego.completarPalabraParcial(letra);
        ViewBag.intentos = juego.intentos;

        return View("Juego");
    }

    public IActionResult Index()
    {
        return View();
    }
}
