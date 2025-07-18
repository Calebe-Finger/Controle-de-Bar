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

            registros[contadorRegistros++] = novaConta;
        }

        public Conta[] SelecionarContas()
        {
            return registros;
        }

        public Conta[] SelecionarContasPorData(DateTime dataFaturamento)
        {
            int qntContasDoDia = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].Fechamento.Date == dataFaturamento.Date)
                    qntContasDoDia++;
            }

            Conta[] contasDoDia = new Conta[qntContasDoDia];

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].Fechamento.Date == dataFaturamento.Date)
                    contasDoDia[i] = registros[i];
            }

            return contasDoDia;
        }

        public Conta[] SelecionarContasEmAberto()
        {
            // Contar as contas em aberto
            int qntContasEmAberto = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].EstaAberta)
                    qntContasEmAberto++;
            }

            Conta[] contasEmAberto = new Conta[qntContasEmAberto];

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].EstaAberta)
                    contasEmAberto[i] = registros[i];
            }
            // Retornar apenas as contas em aberto

            return contasEmAberto;
        }

        public Conta[] SelecionarContasFechadas()
        {
            // Contar as contas fechadas
            int qntContasFechadas = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (!registros[i].EstaAberta)
                    qntContasFechadas++;
            }

            Conta[] contasFechadas = new Conta[qntContasFechadas];

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                if (registros[i].EstaAberta)
                    contasFechadas[i] = registros[i];
            }
            // Retornar apenas as contas fechadas

            return contasFechadas;
        }

        public Conta SelecionarRegistroPorId(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                Conta registro = registros[i];

                if (registro == null)
                    continue;

                if (registro.Id == idSelecionado)
                    return registro;
            }

            return null;
        }
    }
}

    
//A34 - V03