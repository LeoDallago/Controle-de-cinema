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

    [HttpGet]
    public ViewResult Excluir(int id)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var sala = repositorioSala.SelecionarPorId(id);

        var excluirSalaViewModel = new SalaViewModels.ExcluirSalaViewModel()
        {
            Id = sala.Id,
            Numero = sala.Numero
        };
        
        return View(excluirSalaViewModel);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult Excluir(SalaViewModels.ExcluirSalaViewModel excluirSalaViewModel)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var salaSelecionada = repositorioSala.SelecionarPorId(excluirSalaViewModel.Id);

        repositorioSala.Excluir(salaSelecionada);
        
        ViewBag.Mensagem = $"A sala {salaSelecionada.Numero} foi excluida com sucesso";
        
        return View("mensagens");
    }

    [HttpGet]
    public ViewResult Editar(int id)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var sala = repositorioSala.SelecionarPorId(id);

        var editarSalaViewModel = new SalaViewModels.EditarSalaViewModel()
        {
            Id = sala.Id,
            Numero = sala.Numero,
            Capacidade = sala.Capacidade
        };

        return View(editarSalaViewModel);
    }

    [HttpPost]
    public ViewResult Editar(SalaViewModels.EditarSalaViewModel editarSalaViewModel)
    {
        if (!ModelState.IsValid)
            return View(editarSalaViewModel);
        
        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var salaOriginal = repositorioSala.SelecionarPorId(editarSalaViewModel.Id);

        var salaEditada = new Sala(editarSalaViewModel.Numero,editarSalaViewModel.Capacidade);

        repositorioSala.Editar(salaOriginal,salaEditada);
        
        ViewBag.Mensagem = $"A Sala {salaOriginal.Numero} foi editada com sucesso";
        
        return View("mensagens");
    }

    [HttpGet]
    public ViewResult Detalhes(SalaViewModels.DetalhesSalaViewModel detalhesSalaViewModel)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioSala = new RepositorioSala(db);

        var sala = repositorioSala.SelecionarPorId(detalhesSalaViewModel.Id);

        var salaViewModel = new SalaViewModels.DetalhesSalaViewModel()
        {
            Id = sala.Id,
            Numero = sala.Numero,
            Capacidade = sala.Capacidade
        };
        
        return View(salaViewModel);
    }
}