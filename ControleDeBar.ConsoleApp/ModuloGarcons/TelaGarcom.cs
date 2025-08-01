﻿using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Memoria.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloGarcons
{
    public class TelaGarcom : TelaBase<Garcom>, ITela
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
                Console.WriteLine("Digite o nome do garçom:");
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
                Console.WriteLine("Digite o CPF do garçom:");
                cpf = Console.ReadLine();

                if (cpf == null)
                {
                    Console.WriteLine("O \"CPF\" deve se adequar ao formato validado: XXX.XXX.XXX-XX");
                }
                else
                    valorCorreto = true;
            }

            Garcom garcom = new Garcom(nome, cpf);

            return garcom;
        }
    }
}
