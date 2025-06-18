namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public class TelaBase
    {
        protected string nomeEntidade; Add commentMore actions
    protected RepositorioBase repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }

        public virtual char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
            Console.WriteLine($"2 - Editar {nomeEntidade}");
            Console.WriteLine($"3 - Excluir {nomeEntidade}");
            Console.WriteLine($"4 - Visualizar {nomeEntidade}s");
            Console.WriteLine($"S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public virtual void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            EntidadeBase novoRegistro = ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                ApresentarMensagem(
                    string.Concat(erros, "\nDigite ENTER para continuar..."),
                    ConsoleColor.Red
                );

                CadastrarRegistro();

                return;
            }

            repositorio.CadastrarRegistro(novoRegistro);

            ApresentarMensagem($"{nomeEntidade} cadastrado/a com sucesso!", ConsoleColor.Green);
        }

        public virtual void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Edição de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros(false);

            bool conseguiuConverterId = false;

            int idSelecionado = 0;

            while (!conseguiuConverterId)
            {
                Console.Write("Digite o ID do registro que deseja selecionar: ");
                conseguiuConverterId = int.TryParse(Console.ReadLine(), out idSelecionado);

                if (!conseguiuConverterId)
                    ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
            }

            Console.WriteLine();

            EntidadeBase registroAtualizado = ObterDados();

            string erros = registroAtualizado.Validar();

            if (erros.Length > 0)
            {
                ApresentarMensagem(
                    string.Concat(erros, "\nDigite ENTER para continuar..."),
                    ConsoleColor.Red
                );

                EditarRegistro();

                return;
            }

            repositorio.EditarRegistro(idSelecionado, registroAtualizado);

            ApresentarMensagem($"{nomeEntidade} editado/a com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Exclusão de {nomeEntidade}");

            Console.WriteLine();

            VisualizarRegistros(false);

            bool conseguiuConverterId = false;

            int idSelecionado = 0;

            while (!conseguiuConverterId)
            {
                Console.Write("Digite o ID do registro que deseja selecionar: ");
                conseguiuConverterId = int.TryParse(Console.ReadLine(), out idSelecionado);

                if (!conseguiuConverterId)
                    ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
            }

            Console.WriteLine();

            repositorio.ExcluirRegistro(idSelecionado);

            ApresentarMensagem($"{nomeEntidade} excluído/a com sucesso!", ConsoleColor.Green);
        }

        public abstract void VisualizarRegistros(bool exibirCabecalho);

        protected void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Controle de Bar            |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }

        protected void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();
            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        protected abstract EntidadeBase ObterDados();
    }
}
