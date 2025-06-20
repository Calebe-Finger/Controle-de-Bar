using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;
using System.Text.RegularExpressions;

namespace ControleDeBar.ConsoleApp.ModuloGarcons
{
    public class TelaGarcom : TelaBase<Garcom>
    {
        public TelaGarcom(RepositorioBase<Garcom> repositorio) : base("Garçom", repositorio)
        {
        }

        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Garçons");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30}",
                "Id", "Nome", "CPF", "Status"
            );

            Garcom[] garcons = repositorio.SelecionarRegistros();

            for (int i = 0; i < garcons.Length; i++)
            {
                Garcom g = garcons[i];

                if (g == null)
                    continue;

                string statusGarcom = g.EstaOcupado ? "Ocupado" : "Disponível";

                Console.WriteLine(
                  "{0, -10} | {1, -30} | {2, -30}",
                    g.Id, g.Nome, g.Cpf, statusGarcom
                );
            }

            ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
        }

        protected override Garcom ObterDados()
        {
            bool valorCorreto = false;
            string nome = string.Empty;

            while (!valorCorreto)
            {
                Console.WriteLine("Digite o nome do garçom!");
                nome = Console.ReadLine();

                if (nome.Length < 3 || nome.Length > 100)
                {
                    Console.WriteLine("O \"Nome\" deve conter entre 3 e 100 caracteres");
                }
                else 
                    valorCorreto = true;
            }

            valorCorreto = false;
            string cpf = string.Empty;

            while (!valorCorreto)
            {
                Console.WriteLine("Digite o cpf do garçom!");
                cpf = Console.ReadLine();

                if (!Regex.IsMatch(cpf, null))
                {
                    Console.WriteLine("O \"Nome\" deve se adequar ao formato validado: XXX.XXX.XXX-XX");
                }
                else
                    valorCorreto = true;
            }
            return new Garcom(nome, cpf);
        }
    }
}
