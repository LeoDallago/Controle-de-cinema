using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class SalaViewModels
{
    public class InserirSalaViewModel
    {
        [Required(ErrorMessage = "Por favor, insira um Numero")]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Por favor, insira a CAPACIDADE")]
        public int Capacidade { get; set; }
    }
}