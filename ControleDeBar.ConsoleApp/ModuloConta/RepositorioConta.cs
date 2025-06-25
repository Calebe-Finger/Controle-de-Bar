namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta
    {
        protected Conta[] registros = new Conta[100];
        protected int contadorRegistros = 0;
        protected int contadorIds = 0;

        public void Cadastrar(Conta novaConta)
        {
            novaConta.Id = ++contadorIds;
        }
    }
}
