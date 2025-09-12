using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrutura.Memoria.ModuloProduto;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase<Produto>, ITela
    {
        public TelaProduto(RepositorioProduto repositorio) : base("Produto", repositorio)
        {
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Produtos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30}",
                "Id", "Nome", "Preço"
            );

            Produto[] produtos = repositorio.SelecionarRegistros();

            for (int i = 0; i < produtos.Length; i++)
            {
                Produto p = produtos[i];

                if (p == null)
                    continue;

                Console.WriteLine(
                  "{0, -10} | {1, -30} | {2, -30}",
                    p.Id, p.Nome, p.Preco.ToString("C2")
                );
            }

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        protected override Produto ObterDados()
        {
            bool valorCorreto = false;
            string nome = string.Empty;

            while (!valorCorreto)
            {
                Console.WriteLine("Digite o nome do produto:");
                nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    ApresentarMensagem("Digite um nome válido!", ConsoleColor.DarkYellow);
                    Console.Clear();
                }
                else
                    valorCorreto = true;    
            }

            valorCorreto = false;
            bool conseguiuConverterValor = false;
            decimal preco = 0.0m;

            while (!conseguiuConverterValor)
            {
                Console.WriteLine("Digite o preço do produto:");
                conseguiuConverterValor = decimal.TryParse(Console.ReadLine(), out preco);

                if (conseguiuConverterValor)
                {
                    ApresentarMensagem("Digite um valor numérico válido!", ConsoleColor.DarkYellow);
                    Console.Clear();
                }
                else
                    valorCorreto = true;
            }

            return new Produto(nome, preco);
        }
    }
}
