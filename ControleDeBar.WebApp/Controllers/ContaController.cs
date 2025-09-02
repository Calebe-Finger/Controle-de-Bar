using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloCarcom;
using ControleDeBar.Infraestrutura.Arquivos.ModuloConta;
using ControleDeBar.Infraestrutura.Arquivos.ModuloMesa;
using ControleDeBar.Infraestrutura.Arquivos.ModuloProduto;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class ContaController : Controller
    {
        private readonly ContextoDados contextoDados;
        private readonly RepositorioContaEmArquivo repositorioConta;
        private readonly RepositorioMesaEmArquivo repositorioMesa;
        private readonly RepositorioGarcomEmArquivo repositorioGarcom;
        private readonly RepositorioProdutoEmArquivo repositorioProduto;

        public ContaController()
        {
            contextoDados = new ContextoDados(true);

            repositorioConta = new RepositorioContaEmArquivo(contextoDados);
            repositorioMesa = new RepositorioMesaEmArquivo(contextoDados);
            repositorioGarcom = new RepositorioGarcomEmArquivo(contextoDados);
            repositorioProduto = new RepositorioProdutoEmArquivo(contextoDados);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Conta> contas = repositorioConta.SelecionarRegistros();

            VisualizarContasViewModel visualizarContasVm = new VisualizarContasViewModel(contas);

            return View(visualizarContasVm);
        }

        [HttpGet]
        public IActionResult Abrir()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarRegistros();
            List<Garcom> garcons = repositorioGarcom.SelecionarRegistros();

            AbrirContaViewModel abrirContaVm = new AbrirContaViewModel(mesas, garcons);

            return View(abrirContaVm);
        }

        [HttpPost]
        public IActionResult Abrir(AbrirContaViewModel abrirVm)
        {
            if (!ModelState.IsValid)
                return View(abrirVm);

            Mesa mesaSelecionada = repositorioMesa.SelecionarRegistroPorId(abrirVm.MesaId);
            Garcom garcomSelecionado = repositorioGarcom.SelecionarRegistroPorId(abrirVm.GarcomId);

            Conta conta = new Conta(abrirVm.Titular, mesaSelecionada, garcomSelecionado);

            repositorioConta.CadastrarRegistro(conta);

            return RedirectToAction(nameof(Index));
        }
    }
}
