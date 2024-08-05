using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.Dominio.ModuloSessao;

public class Sessao : EntidadeBase
{
    public Sessao(string filme, string sala, string horarioDeInicio)
    {
        Filme = filme;
        Sala = sala;
        HorarioDeInicio = horarioDeInicio;
    }

    public string Filme { get; set; }
    
    public string Sala { get; set; }
    
    public string HorarioDeInicio { get; set; }
    
    
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