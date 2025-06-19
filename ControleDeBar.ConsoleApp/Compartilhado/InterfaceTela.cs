namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public interface ITela  // Representa o final do dominó, é a classe que determina qual vai ser a base de
    {                       // tudo
        char ApresentarMenu();
        void CadastrarRegistro();
        void EditarRegistro();
        void ExcluirRegistro();
        void VisualizarRegistros(bool exibirCabecalho);
    }
}
