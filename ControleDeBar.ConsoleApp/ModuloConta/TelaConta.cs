using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcons;
using ControleDeBar.ConsoleApp.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : ITela
    {
        private RepositorioConta repositorioConta;
        private RepositorioProduto repositorioProduto;
        private RepositorioMesa repositorioMesa;
        private RepositorioGarcom repositorioGarcom;



        public char ApresentarMenu()
        {
            throw new NotImplementedException();
        }

        public void CadastrarRegistro()
        {
            
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void VisualizarRegistros(bool exibirCabecalho)
        {
            throw new NotImplementedException();
        }
    }
}
