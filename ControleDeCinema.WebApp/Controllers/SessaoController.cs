using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.Infra.Orm.ModuloSala;
using ControleDeCinema.Infra.Orm.ModuloSessao;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeCinema.WebApp.Controllers;

public class SessaoController : Controller
{
    [HttpGet]
    public ViewResult Inserir()
    {
        var dbContext = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(dbContext);
        var repositorioSala = new RepositorioSala(dbContext);

        var filmes = repositorioFilme.SelecionarTodos();
        var salas = repositorioSala.SelecionarTodos();

        var inserirSessaoVm = new InserirSessaoViewModel()
        {
            Filmes = filmes.Select(f => new SelectListItem(f.Titulo,f.Id.ToString())),
            Salas = salas.Select(s => new SelectListItem(s.Numero,s.Id.ToString()))
        };
        
        return View(inserirSessaoVm);
    }

    [HttpPost]
    public ViewResult Inserir(InserirSessaoViewModel inserirSessaoViewModel)
    {
        var dbContext = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(dbContext);
        var repositorioSala = new RepositorioSala(dbContext);
        var repositorioSessao = new RepositorioSessao(dbContext);

        var filmeSelecionado = repositorioFilme.SelecionarPorId(inserirSessaoViewModel.FilmeId);
        var salaSelecionada = repositorioSala.SelecionarPorId(inserirSessaoViewModel.SalaId);

        var novaSessao = new Sessao(filmeSelecionado, salaSelecionada, inserirSessaoViewModel.HorarioDeInicio);
        
        repositorioSessao.Inserir(novaSessao);

        ViewBag.Mensagem = $"Sessao inserida com sucesso!";
        
        return View("mensagens");
    }

    [HttpGet]
    public ViewResult Excluir(int id)
    {
        var dbContext = new ControleDeCinamaDbContext();
        var repositorioSessao = new RepositorioSessao(dbContext);

        var sessao = repositorioSessao.SelecionarPorId(id);

        var excluirSessaoViewModel = new ExcluirSessaoViewModel()
        {
            Id = sessao.Id
        };
        
        return View(excluirSessaoViewModel);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult Excluir(ExcluirSessaoViewModel excluirSessaoViewModel)
    {
        var dbContext = new ControleDeCinamaDbContext();
        var repositorioSessao = new RepositorioSessao(dbContext);

        var sessao = repositorioSessao.SelecionarPorId(excluirSessaoViewModel.Id);
        repositorioSessao.Excluir(sessao);
        
        ViewBag.Mensagem = $"Sessao excluida com sucesso";
        return View("mensagens");
    }
}