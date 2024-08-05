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
    
    public class ExcluirSalaViewModel
    {
        public int Id { get; set; }
        
        public string Numero { get; set; }
    }
    
    public class EditarSalaViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Por favor, insira um Numero")]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Por favor, insira a CAPACIDADE")]
        public int Capacidade { get; set; }
    }
    
    public class ListarSalaViewModel
    {
        public int Id { get; set; }
        
        public string Numero { get; set; }
        
        public int Capacidade { get; set; }
    }
    
    public class DetalhesSalaViewModel
    {
        public int Id { get; set; }
        
        public string Numero { get; set; }
        
        public int Capacidade { get; set; }
    }
}