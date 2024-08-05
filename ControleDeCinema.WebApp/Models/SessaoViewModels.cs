using System.ComponentModel.DataAnnotations;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeCinema.WebApp.Models;
    public class InserirSessaoViewModel
    {
        [Required(ErrorMessage = "Por favor, insira um Filme")]
        public int FilmeId { get; set; }
        
        public IEnumerable<SelectListItem> Filmes { get; set; }
        
        [Required(ErrorMessage = "Por favor, insira uma Sala")]
        public int SalaId { get; set; }
        public IEnumerable<SelectListItem> Salas { get; set; }
        
        [Required(ErrorMessage = "Por favor, insira o Horario de inicio")]
        public DateTime HorarioDeInicio { get; set; }
    }


    public class ExcluirSessaoViewModel()
    {
        public int Id { get; set; }
    }
