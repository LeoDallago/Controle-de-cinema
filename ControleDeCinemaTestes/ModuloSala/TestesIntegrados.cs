using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSala;

namespace ControleDeCinemaTestes.ModuloSala;


[TestClass]
[TestCategory("Testes Integrados")]
public class TestesIntegrados
{
    private RepositorioSala repositorioSala;
    private ControleDeCinamaDbContext dbContext;

    [TestInitialize]
    public void Configura_Teste()
    {
        dbContext = new ControleDeCinamaDbContext();
        
        dbContext.Salas.RemoveRange(dbContext.Salas);

        repositorioSala = new RepositorioSala(dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Sala()
    {
        //Arrange
        var sala = new Sala("3",10);
        
        //Act
        repositorioSala.Inserir(sala);
        
        //Assert
        Assert.IsNotNull(repositorioSala);
    }

    [TestMethod]
    public void Deve_Excluir_Sala()
    {
        //Arrange
        var sala = new Sala("3",10);
        repositorioSala.Inserir(sala);
        
        //Act
        repositorioSala.Excluir(sala);
        
        //Assert
        var salaSelecionada = repositorioSala.SelecionarPorId(sala.Id);
        Assert.IsNull(salaSelecionada);
    }

    [TestMethod]
    public void Deve_Editar_Sala()
    {
        //Arrange
        var sala = new Sala("3",10);
        repositorioSala.Inserir(sala);
        var salaEditada = new Sala("3", 20);

        //Act
        repositorioSala.Editar(sala, salaEditada);
        
        //Assert
        Assert.AreEqual(20,sala.Capacidade);

    }
}
