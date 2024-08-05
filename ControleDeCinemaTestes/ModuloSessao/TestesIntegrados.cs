using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloSessao;

namespace ControleDeCinemaTestes.ModuloSessao;

[TestClass]
[TestCategory("Testes Integrados")]
public class TestesIntegrados
{
    private RepositorioSessao repositorioSessao;
    private ControleDeCinamaDbContext dbContext;

    [TestInitialize]
    public void Configura_Teste()
    {
        dbContext = new ControleDeCinamaDbContext();
        
        dbContext.Salas.RemoveRange(dbContext.Salas);

        repositorioSessao = new RepositorioSessao(dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Sessao()
    {
        //Arrange
        var sessao = new Sessao("test", "3", "1:20");
        
        //Act
        repositorioSessao.Inserir(sessao);
        
        //Assert
        Assert.IsNotNull(repositorioSessao);
    }

    [TestMethod]
    public void Deve_Excluir_Sessao()
    {
        //Arrange
        var sessao = new Sessao("test", "3", "1:20");
        repositorioSessao.Inserir(sessao);
        
        //Act
        repositorioSessao.Excluir(sessao);
        
        //Assert
        var sessaoExcluida = repositorioSessao.SelecionarPorId(sessao.Id);
        Assert.IsNull(sessaoExcluida);
    }

    [TestMethod]
    public void Deve_Editar_Sessao()
    {
        //Arrange
        var sessao = new Sessao("test", "3", "1:20");
        repositorioSessao.Inserir(sessao);
        var sessaoEditada = new Sessao("testEditado", "3", "1:11");
        
        //Act
        repositorioSessao.Editar(sessao, sessaoEditada);
        
        //Assert
        Assert.AreEqual("testEditado",sessao.Filme);
    }
}