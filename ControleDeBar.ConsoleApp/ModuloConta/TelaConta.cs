using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcons;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Globalization;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : ITela
    {
        private RepositorioConta repositorioConta;
        private RepositorioProduto repositorioProduto;
        private RepositorioMesa repositorioMesa;
        private RepositorioGarcom repositorioGarcom;

        public TelaConta(RepositorioConta repositorioConta, RepositorioProduto repositorioProduto, 
            RepositorioMesa repositorioMesa, RepositorioGarcom repositorioGarcom)
        {
            this.repositorioConta = repositorioConta;
            this.repositorioProduto = repositorioProduto;
            this.repositorioMesa = repositorioMesa;
            this.repositorioGarcom = repositorioGarcom;
        }

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Controle de Bar            |");
            Console.WriteLine("----------------------------------------\n");

            Console.WriteLine("1 - Cadastro de Conta");
            Console.WriteLine("2 - Fechamento de Conta");
            Console.WriteLine("3 - Gerenciar Pedidos da Conta");
            Console.WriteLine("4 - Visualizar Contas");
            Console.WriteLine("5 - Visualizar Contas em Aberto");
            Console.WriteLine("6 - Visualizar Contas Fechadas");
            Console.WriteLine("7 - Visualizar Faturamento Diário");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public void ApresentarMenuGestaoPedidos()
        {
            ExibirCabecalho();

            Console.WriteLine("Gestão de Pedidos de Contas");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine("Digite o ID da conta que deseja gerenciar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Conta contaSelecionada = repositorioConta.SelecionarRegistroPorId(id);

            Console.WriteLine();

            while (true)
            {
                VisualizarPedidosConta(contaSelecionada);

                Console.WriteLine();

                Console.WriteLine($"1 - Adicionar novo pedido");
                Console.WriteLine($"2 - Remover Pedido");
                Console.WriteLine($"S - Sair");

                Console.WriteLine();

                Console.WriteLine("Digite uma opção válida: ");
                char opcaoEscolhida = Console.ReadLine()[0];

                if (char.ToUpper(opcaoEscolhida) == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1': AdicionarPedido(contaSelecionada); break;

                    case '2': RemoverPedido(contaSelecionada); break;
                }
            }
        }

        public void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("Abertura de Conta");

            Console.WriteLine();

            Conta novaConta = ObterDados();

            string erros = novaConta.Validar();

            if (erros.Length > 0)
            {
                ApresentarMensagem(
                    string.Concat(erros, "\nDigite ENTER para continuar..."),
                    ConsoleColor.Red
                );

                CadastrarRegistro();

                return;
            }

            repositorioConta.Cadastrar(novaConta);

            ApresentarMensagem($"Conta aberta com sucesso!", ConsoleColor.Green);
        }

        public void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("Fechamento de contas");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine("Digite o ID da conta que deseja fechar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Conta contaSelecionada = repositorioConta.SelecionarRegistroPorId(id);

            Console.WriteLine();

            Console.WriteLine($"Deseja realmente fechar a conta do títular \"{contaSelecionada.Titular}\"? (s/N)");
            char opcaoEscolhida = Console.ReadLine()[0];

            if (char.ToUpper(opcaoEscolhida) == 'N')
                return;

            contaSelecionada.Fechar();

            ApresentarMensagem($"Conta do titular \"{contaSelecionada.Titular}\" fechada com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirRegistro()
        {

        }

        public void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Contas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                "Id", "Titular", "Mesa", "Garcom", "Abertura", "Status"
            );

            List<Conta> contas = repositorioConta.SelecionarContas();

            foreach (Conta c in contas)
            {
                string statusConta = c.EstaAberta ? "Aberta" : "Fechada";

                Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                c.Id, c.Titular, c.Mesa.Numero, c.Garcom.Nome, c.Abertura.ToShortDateString(), statusConta
                );
            }

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        public void VisualizarContasEmAberto()
        {
            ExibirCabecalho();

            Console.WriteLine("Visualização de Contas em Aberto");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                "Id", "Titular", "Mesa", "Garcom", "Abertura", "Status"
            );

            List<Conta> contasAbertas = repositorioConta.SelecionarContasEmAberto();

            foreach (Conta c in contasAbertas)
            {
                string statusConta = c.EstaAberta ? "Aberta" : "Fechada";

                Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                c.Id, c.Titular, c.Mesa.Numero, c.Garcom.Nome, c.Abertura.ToShortDateString(), statusConta
                );
            }

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        public void VisualizarContasFechadas()
        {
            ExibirCabecalho();

            Console.WriteLine("Visualização de Contas Fechadas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                "Id", "Titular", "Mesa", "Garcom", "Abertura", "Status"
            );

            List<Conta> contasFechadas = repositorioConta.SelecionarContasFechadas();

            foreach (Conta c in contasFechadas)
            {
                string statusConta = c.EstaAberta ? "Aberta" : "Fechada";

                Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                c.Id, c.Titular, c.Mesa.Numero, c.Garcom.Nome, c.Abertura.ToShortDateString(), statusConta
                );
            }

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        public void VisualizarFaturamentoDiario()
        {
            ExibirCabecalho();

            Console.WriteLine("Visualização de Faturamento Diário");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine("Digite uma data válida do passado: ");
            DateTime dataFaturamento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine(
               "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
               "Id", "Titular", "Mesa", "Garcom", "Abertura", "Status"
            );

            decimal totalFaturamento = 0.0m;

            List<Conta> contasFaturamento = repositorioConta.SelecionarContasPorData(dataFaturamento);

            for (int i = 0; i < contasFaturamento.Count; i++)
            {
                Conta c = contasFaturamento[i];

                if (c == null)
                    continue;

                totalFaturamento += c.CalcularValorTotal();

                string statusConta = c.EstaAberta ? "Aberta" : "Fechada";

                Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                c.Id, c.Titular, c.Mesa.Numero, c.Garcom.Nome, c.Abertura.ToShortDateString(), statusConta
                );
            }

            Console.WriteLine($"O Total faturado do dia foi: {totalFaturamento.ToString("C2")}");

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        private void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Controle de Bar            |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }

        private void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();
            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        private Conta ObterDados()
        {
            string titular = string.Empty;

            while (string.IsNullOrWhiteSpace(titular))
            {
                Console.WriteLine("Digite o nome do titular da conta: ");
                titular = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(titular))
                {
                    ApresentarMensagem("O titular é obrigatório!", ConsoleColor.DarkYellow);
                    Console.Clear();
                }
            }

            VisualizarMesas();

            Console.WriteLine();

            Console.WriteLine("Digite o ID da mesa que deseja ocupar: ");
            int idMesa = Convert.ToInt32(Console.ReadLine());

            Mesa mesaSelecionada = repositorioMesa.SelecionarRegistroPorId(idMesa);

            VisualizarGarcons();

            Console.WriteLine();

            Console.WriteLine("Digite o ID do garçom que atenderá a mesa: ");
            int idGarcom = Convert.ToInt32(Console.ReadLine());

            Garcom garcomSelecionado = repositorioGarcom.SelecionarRegistroPorId(idGarcom);



            return new Conta(titular, mesaSelecionada, garcomSelecionado);
        }

        private void VisualizarMesas()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Mesas");

            Console.WriteLine();

            Console.WriteLine
            (
                "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
                "Id", "Número", "Capacidade", "Status"
            );

            Mesa[] mesas = repositorioMesa.SelecionarRegistros();

            for (int i = 0; i < mesas.Length; i++)
            {
                Mesa m = mesas[i];

                if (m == null)
                    continue;

                string statusMesa = m.EstaOcupada ? "Ocupada" : "Disponível";

                Console.WriteLine
                (
                    "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
                    m.Id, m.Numero, m.Capacidade, statusMesa
                );
            }
        }

        private void VisualizarGarcons()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Garçons");

            Console.WriteLine();

            Console.WriteLine
            (
                "{0, -10} | {1, -20} | {2, -20}",
                "Id", "Nome", "CPF"
            );

            Garcom[] garcons = repositorioGarcom.SelecionarRegistros();

            for (int i = 0; i < garcons.Length; i++)
            {
                Garcom g = garcons[i];

                if (g == null)
                    continue;

                Console.WriteLine
                (
                    "{0, -10} | {1, -20} | {2, -20}",
                    g.Id, g.Nome, g.Cpf
                );
            }
        }

        private void VisualizarPedidosConta(Conta conta)
        {
            Console.WriteLine("Visualizar Pedidos da Conta");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -14} | {3, -20}",
                "Id", "Produto", "Quantidade", "Valor Parcial"
            );

            Pedido[] pedidos = conta.Pedidos;

            for (int i = 0; i < pedidos.Length; i++)
            {
                Pedido p = pedidos[i];

                if (p == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -14} | {3, -20}",
                    p.Id, p.Produto.Nome, p.QuantidadeSolicitada, p.CalcularTotalParcial().ToString("C2")
                );
            }
        }

        private void VisualizarProdutos()
        {
            Console.WriteLine("Visualizar Produtos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "Valor");

            Produto[] produtos = repositorioProduto.SelecionarRegistros();

            for (int i = 0; i < produtos.Length; i++)
            {
                Produto p = produtos[i];

                if (p == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", p.Id, p.Nome, p.Valor.ToString("C2"));
            }
        }

        private void AdicionarPedido(Conta contaSelecionada)
        {
            while (true)
            {
                ExibirCabecalho();

                Console.WriteLine("Cadastro  de Pedidos da Conta");

                Console.WriteLine();

                VisualizarProdutos();

                Console.WriteLine();

                Console.WriteLine("Digite o ID do produto que deseja pedir: ");
                int idProduto = Convert.ToInt32(Console.ReadLine());

                Produto produtoSelecionado = repositorioProduto.SelecionarRegistroPorId(idProduto);

                Console.WriteLine("Digite a quantidade do produto que deseja pedir: ");
                int quantidadeSolicitada = Convert.ToInt32(Console.ReadLine());

                Pedido pedido = contaSelecionada.RegistrarPedido(produtoSelecionado, quantidadeSolicitada);

                ApresentarMensagem($"Pedido \"{pedido.ToString()}\" adicionado com sucesso!", ConsoleColor.Green);

                Console.WriteLine("Deseja adicionar mais produtos (s/N)?");
                char opcaoEscolhida = Console.ReadLine()[0];

                if (char.ToUpper(opcaoEscolhida) == 'N')
                    break;
            }
        }

        private void RemoverPedido(Conta contaSelecionada)
        {
            while (true)
            {
                ExibirCabecalho();

                Console.WriteLine("Remoção  de Pedidos da Conta");

                Console.WriteLine();

                VisualizarPedidosConta(contaSelecionada);

                Console.WriteLine();

                Console.WriteLine("Digite o ID do pedido que deseja remover: ");
                int idPedido = Convert.ToInt32(Console.ReadLine());

                contaSelecionada.RemoverPedido(idPedido);

                ApresentarMensagem($"Pedido removido com sucesso!", ConsoleColor.Green);

                Console.WriteLine("Deseja remover mais pedidos (s/N)?");
                char opcaoEscolhida = Console.ReadLine()[0];

                if (char.ToUpper(opcaoEscolhida) == 'N')
                    break;
            }
        }
    }
}