using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSala;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers;

public class SalaController : Controller
{
    [HttpGet]
    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(SalaViewModels.InserirSalaViewModel inserirSalaViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inserirSalaViewModel);
        }

        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var novaSala = new Sala(inserirSalaViewModel.Numero, inserirSalaViewModel.Capacidade);
        
        repositorioSala.Inserir(novaSala);

        ViewBag.Mensagem = $"A sala {novaSala.Numero} foi inserida com Sucesso!";
        return View("mensagens");
    }

    [HttpGet]
    public ViewResult Listar()
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var salas = repositorioSala.SelecionarTodos();

        var salaViewModel = salas.Select(s => new SalaViewModels.ListarSalaViewModel
        {
                Id = s.Id,
                Numero = s.Numero,
                Capacidade = s.Capacidade
        });
        
        return View(salaViewModel);
    }
}