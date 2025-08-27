using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloProduto;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        public readonly RepositorioProdutoEmArquivo repositorioProduto;
        public ProdutoController ()
        {
            ContextoDados contextoDados = new ContextoDados(carregarDados: true);

            repositorioProduto = new RepositorioProdutoEmArquivo(contextoDados);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Produto> produtos = repositorioProduto.SelecionarRegistros();

            VisualizarProdutosViewModel visualizarVm = new VisualizarProdutosViewModel(produtos);

            return View(visualizarVm);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CadastrarProdutoViewModel cadastrarVm = new CadastrarProdutoViewModel();

            return View(cadastrarVm);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVm)
        {
            if(!ModelState.IsValid)
                return View(cadastrarVm);

            var entidade = new Produto(cadastrarVm.Nome, cadastrarVm.Preco);

            repositorioProduto.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar (int id)
        {
            var registro = repositorioProduto.SelecionarRegistroPorId(id);

            EditarProdutoViewModel editarVm = new EditarProdutoViewModel(id, registro.Nome, registro.Preco);

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(EditarProdutoViewModel editarVm)
        {
            if(!ModelState.IsValid)
                return View(editarVm);

            var produtoEditado = new Produto(editarVm.Nome, editarVm.Preco);

            repositorioProduto.EditarRegistro(editarVm.Id, produtoEditado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var registro = repositorioProduto.SelecionarRegistroPorId(id);

            ExcluirProdutoViewModel excluirVm = new ExcluirProdutoViewModel(id, registro.Nome);

            return View(excluirVm);
        }

        [HttpPost]
        public IActionResult Excluir(ExcluirProdutoViewModel excluirVm)
        {
            repositorioProduto.ExcluirRegistro(excluirVm.Id);

            return RedirectToAction(nameof (Index));
        }
    }
}
