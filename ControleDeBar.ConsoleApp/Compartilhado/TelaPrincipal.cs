namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;

        public TelaPrincipal()
        {
        }

        public void ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Controle de Bar            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Controle de Mesas");
            Console.WriteLine("2 - Controle de Garçons");
            Console.WriteLine("3 - Controle de Produtos");
            Console.WriteLine("4 - Controle de Contas");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            opcaoEscolhida = Console.ReadLine()![0];
        }

        public TelaBase ObterTela()
        {
            if (opcaoEscolhida == '1')
                return null;

            if (opcaoEscolhida == '2')
                return null;

            if (opcaoEscolhida == '3')
                return null;

            if (opcaoEscolhida == '4')
                return null;

            return null;
        }
    }
}
