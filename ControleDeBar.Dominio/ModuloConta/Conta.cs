using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Conta : EntidadeBase<Conta>
    {
        public string Titular { get; set; }
        public Mesa Mesa { get; set; }
        public Garcom Garcom { get; set; } 
        public DateTime Abertura { get; set; }
        public DateTime Fechamento { get; set; }
        public bool EstaAberta {  get; set; }

        public Pedido[] Pedidos { get; set; }

        public Conta(string titular, Mesa mesa, Garcom garcom)
        {
            Titular = titular;
            Mesa = mesa;
            Garcom = garcom;
            Pedidos = new Pedido[100];

            Abrir();
        }

        public override void AtualizarRegistro(Conta registroAtualizado)
        {
            EstaAberta = registroAtualizado.EstaAberta;
            Fechamento = registroAtualizado.Fechamento;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Titular.Length < 3 || Titular.Length > 100)
                erros += "O campo \"Titular\" deve conter entre 3 e 100 caracteres.";

            if (Mesa == null)
                erros += "O campo \"Mesa\" é obrigatório.";

            if (Garcom == null)
                erros += "O campo \"Garçom\" é obrigatório.";

            return erros;
        }

        public void Abrir()
        {
            EstaAberta = true;
            Abertura = DateTime.Now;

            Mesa.Ocupar();
        }

        public void Fechar()
        {
            EstaAberta = false;
            Abertura = DateTime.Now;

            Mesa.Desocupar();
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;

            for (int i = 0; i < Pedidos.Length; i++)
            {
                if (Pedidos[i] == null)
                    continue;

                valorTotal += Pedidos[i].CalcularTotalParcial();
            }

            return valorTotal;
        }

        public Pedido RegistrarPedido(Produto produto, int quantidadeEscolhida)
        {
            Pedido novoPedido = new Pedido(produto, quantidadeEscolhida);

            Pedidos[EncontrarIndicePedidosVazio()] = novoPedido;

            return novoPedido;
        }

        public void RemoverPedido(int idPedido)
        {
            int indiceParaRemover = -1;

            for(int i = 0;i < Pedidos.Length;i++)
            {
                if (Pedidos[i] == null)
                    continue;

                if (Pedidos[i].Id == idPedido)
                {
                    indiceParaRemover = i;
                    break;
                }
            }

            Pedidos[indiceParaRemover] = null;
        }

        public int EncontrarIndicePedidosVazio()
        {
            for (int i = 0;i < Pedidos.Length;i++)
            {
                if (Pedidos[i] == null)
                    return i;
            }

            return -1;
        }
    }
}
