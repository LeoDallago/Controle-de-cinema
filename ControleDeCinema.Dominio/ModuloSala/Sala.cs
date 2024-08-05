using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSala;

public class Sala : EntidadeBase
{
    public Sala(string numero, int capacidade)
    {
        Numero = numero;
        Capacidade = capacidade;
    }

    public String Numero { get; set; }
    
    public int Capacidade { get; set; }
    
    public void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
    {
        Sala salaAtualizada = (Sala)entidadeAtualizada;

        Numero = salaAtualizada.Numero;
        Capacidade = salaAtualizada.Capacidade;
    }

    public void OcuparAssentos()
    {
        throw new NotImplementedException();
    }
    
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}