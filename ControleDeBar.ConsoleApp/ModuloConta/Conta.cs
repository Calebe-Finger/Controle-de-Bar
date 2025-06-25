using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcons;
using ControleDeBar.ConsoleApp.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloConta
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

        public Conta(string )
        {

        }

        public override void AtualizarRegistro(Conta registroAtualizado)
        {
            EstaAberta = registroAtualizado.EstaAberta;

        }

        public override string Validar()
        {
            
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
            }
        }

        public Pedido RegistrarPedido(Produto produto, int quantidadeEscolhida)
        {
            Pedido 
        }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeSolicitada { get; set; }

        private static int contadorIds = 0;

        public Pedido(Produto produto, int quantidadeEscolhida)
        {
            Id = contadorIds++;
            Produto = produto;
            QuantidadeSolicitada = quantidadeEscolhida;
        }

        public decimal CalcularTotalParcial()
        {
            return Produto.Valor * QuantidadeSolicitada;
        }
    }
}
