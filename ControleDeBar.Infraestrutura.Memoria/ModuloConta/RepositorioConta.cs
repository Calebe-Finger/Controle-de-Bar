using ControleDeBar.Dominio.ModuloConta;

namespace ControleDeBar.Infraestrutura.Memoria.ModuloConta
{
    public class RepositorioConta
    {
        protected List<Conta> registros = new List<Conta>();
        protected int contadorIds = 0;

        public void Cadastrar(Conta novaConta)
        {
            novaConta.Id = ++contadorIds;

            registros.Add(novaConta);
        }

        public List<Conta> SelecionarContas()
        {
            return registros;
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

        public Conta SelecionarRegistroPorId(int idSelecionado)
        {
            foreach (Conta conta in registros)
            {
                if (conta.Id == idSelecionado)
                    return conta;
            }

            return null;
        }
    }
}

    
