using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.ModuloConta
{
    public class RepositorioContaEmArquivo : RepositorioBaseEmArquivo<Conta>
    {
        public RepositorioContaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        protected override List<Conta> ObterRegistros()
        {
            return contextoDados.Contas;
        }

        public List<Conta> SelecionarContasPorData(DateTime dataFaturamento)
        {
            List<Conta> contasDoDia = new List<Conta>();

            foreach (Conta conta in registros)
            {
                if (conta.Fechamento.Date == dataFaturamento.Date)
                    contasDoDia.Add(conta);
            }

            return contasDoDia;
        }

        public List<Conta> SelecionarContasEmAberto()
        {
            List<Conta> contasEmAberto = new List<Conta>();

            foreach (Conta conta in registros)
            {
                if (conta.EstaAberta)
                    contasEmAberto.Add(conta);
            }

            return contasEmAberto;
        }

        public List<Conta> SelecionarContasFechadas()
        {
            List<Conta> contasFechadas = new List<Conta>();

            foreach (Conta conta in registros)
            {
                if (!conta.EstaAberta)
                    contasFechadas.Add(conta);
            }

            return contasFechadas;
        }
    }
}

