using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;


public class AbrirContaViewModel
{
    [Required(ErrorMessage = "O campo \"Titular\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo \"Titular\" precisa conter ao menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Titular\" precisa conter no máximo 100 caracteres.")]
    public string Titular { get; set; }

    [Required(ErrorMessage = "O campo \"Mesa\" é obrigatório.")]
    public int MesaId { get; set; }
    public List<SelectListItem> MesasDisponiveis { get; set; }

    [Required(ErrorMessage = "O campo \"Garçom\" é obrigatório.")]
    public int GarcomId { get; set; }
    public List<SelectListItem> GarconsDisponiveis { get; set; }

    public AbrirContaViewModel()
    {
        MesasDisponiveis = new List<SelectListItem>();
        GarconsDisponiveis = new List<SelectListItem>();
    }

    public AbrirContaViewModel(List<Mesa> mesas, List<Garcom> garcons) : this()
    {
        foreach (var m in mesas)
        {
            SelectListItem mesaDisponivel = new SelectListItem(m.Numero.ToString(), m.Id.ToString());

            MesasDisponiveis.Add(mesaDisponivel);
        }

        foreach (var g in garcons)
        {
            SelectListItem garcomDisponivel = new SelectListItem(g.Nome.ToString(), g.Id.ToString());

            GarconsDisponiveis.Add(garcomDisponivel);
        }
    }
}

public class VisualizarContasViewModel
{
    public List<DetalhesContaViewModel> Registros { get; set; }

    public VisualizarContasViewModel(List<Conta> contas)
    {
        Registros = new List<DetalhesContaViewModel>();

        foreach (var c in contas)
        {
            DetalhesContaViewModel detalhesVm = new DetalhesContaViewModel(
                c.Id, c.Titular, c.Mesa.Numero, c.Garcom.Nome, 
                c.EstaAberta, c.CalcularValorTotal(), c.Pedidos.ToList()
            );

            Registros.Add(detalhesVm);
        }
    }
}

public class DetalhesContaViewModel
{
    public int Id { get; set; }
    public string Titular { get; set; }
    public int Mesa { get; set; }
    public string Garcom { get; set; }
    public bool EstaAberta { get; set; }
    public decimal ValorTotal { get; set; }
    public List<PedidoContaViewModel> Pedidos { get; set; }

    public DetalhesContaViewModel(
        int id, string titular, int mesa, string garcom, bool estaAberta, decimal valorTotal, List<Pedido> pedidos
    )
    {
        Id = id;
        Titular = titular;
        Mesa = mesa;
        Garcom = garcom;
        EstaAberta = estaAberta;
        ValorTotal = valorTotal;

        Pedidos = new List<PedidoContaViewModel>();

        foreach (var item in pedidos)
        {
            var pedidoVM = new PedidoContaViewModel(
                item.Id,
                item.Produto.Nome,
                item.QuantidadeSolicitada,
                item.CalcularTotalParcial()
            );

            Pedidos.Add(pedidoVM);
        }
    }
}

public class PedidoContaViewModel
{
    public int Id { get; set; }
    public string Produto { get; set; }
    public int QuantidadeSolicitada { get; set; }
    public decimal TotalParcial { get; set; }

    public PedidoContaViewModel(int id, string produto, int quantidadeSolicitada, decimal totalParcial)
    {
        Id = id;
        Produto = produto;
        QuantidadeSolicitada = quantidadeSolicitada;
        TotalParcial = totalParcial;
    }
}

public class GerenciarPedidosViewModel
{
    public DetalhesContaViewModel Conta { get; set; }
    public List<SelectListItem> ProdutosDisponiveis { get; set; }

    public GerenciarPedidosViewModel() { }

    public GerenciarPedidosViewModel(Conta conta, List<Produto> produtos) : this()
    {
        Conta = new DetalhesContaViewModel(
            conta.Id,
            conta.Titular,
            conta.Mesa.Numero,
            conta.Garcom.Nome,
            conta.EstaAberta,
            conta.CalcularValorTotal(),
            conta.Pedidos
            );

        ProdutosDisponiveis = new List<SelectListItem>();

        foreach (var p  in produtos)
        {
            var selectItem = new SelectListItem(p.Nome, p.Id.ToString());

            ProdutosDisponiveis.Add(selectItem);
        }
    }
}
    
public class AdicionarPedidoViewModel
{
    public int IdProduto { get; set; }
    public int QuantidadeSolicitada { get; set; }
}