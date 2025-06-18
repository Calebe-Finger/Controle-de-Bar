using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                telaPrincipal.ApresentarMenuPrincipal();

                TelaBase telaEscolhida = telaPrincipal.ObterTela();

                if (telaEscolhida == null)
                    break;

                char opcaoEscolhida = telaEscolhida.ApresentarMenu();

                if (char.ToUpper(opcaoEscolhida) == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1': telaEscolhida.CadastrarRegistro(); break;

                    case '2': telaEscolhida.EditarRegistro(); break;

                    case '3': telaEscolhida.ExcluirRegistro(); break;

                    case '4': telaEscolhida.VisualizarRegistros(true); break;
                }
            }
        }
    }
}
