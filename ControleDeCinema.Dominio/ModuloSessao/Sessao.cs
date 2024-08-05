using System.Drawing;
using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.Dominio.ModuloSessao;

public class Sessao : EntidadeBase
{
    public Sessao(Filme filme, Sala sala, DateTime horarioDeInicio)
    {
        Filme = filme;
        Sala = sala;
        HorarioDeInicio = horarioDeInicio;
    }

    public Sessao()
    {
        
    }

    public Filme Filme { get; set; }
    
    public Sala Sala { get; set; }
    
    public DateTime HorarioDeInicio { get; set; }
    
    
    public void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
    {
        Sessao sessaoAtualizada = (Sessao)entidadeAtualizada;

        Filme = sessaoAtualizada.Filme;
        Sala = sessaoAtualizada.Sala;
        HorarioDeInicio = sessaoAtualizada.HorarioDeInicio;
    }
    
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}