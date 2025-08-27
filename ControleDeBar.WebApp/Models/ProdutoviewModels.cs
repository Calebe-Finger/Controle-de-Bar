using ControleDeBar.Dominio.ModuloProduto;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models
{
    public class CadastrarProdutoViewModel
    {
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo \"Nome\" deve conter ao menos três caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo \"Nome\" deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Preço\" é obrigatório.")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "O campo \"Preço\" precisa conter um valor positivo.")]
        public decimal Preco { get; set; }

        public CadastrarProdutoViewModel() { }
    }

    public class EditarProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo \"Nome\" deve conter ao menos três caracteres.")]
        [MaxLength(100, ErrorMessage = "O campo \"Nome\" deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Preço\" é obrigatório.")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "O campo \"Valor\" precisa conter um valor positivo.")]
        public decimal Preco { get; set; }

        public EditarProdutoViewModel() { }

        public EditarProdutoViewModel(int id, string nome, decimal preco) : this()  
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }

    public class ExcluirProdutoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ExcluirProdutoViewModel() { }

        public ExcluirProdutoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class VisualizarProdutosViewModel
    {
        public List<DetalhesProdutoViewModel> Registros { get; set; }

        public VisualizarProdutosViewModel(List<Produto> produtos)
        {

            Registros = new List<DetalhesProdutoViewModel>();

            foreach (Produto p in produtos)
            {
                DetalhesProdutoViewModel produtoVM = new DetalhesProdutoViewModel(p.Id, p.Nome, p.Preco);
                
                Registros.Add(produtoVM);
            }
        }
    }

    public class DetalhesProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public DetalhesProdutoViewModel(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
