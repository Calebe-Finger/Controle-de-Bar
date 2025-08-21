using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloCarcom;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class GarcomController : Controller
    {
        public readonly RepositorioGarcomEmArquivo repositorioGarcom;

        public GarcomController()
        {
            ContextoDados contextoDados = new ContextoDados(carregarDados: true);

            repositorioGarcom = new RepositorioGarcomEmArquivo(contextoDados);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Garcom> garcons = repositorioGarcom.SelecionarRegistros();

            VisualizarGarconsViewModel visualizarVm = new VisualizarGarconsViewModel(garcons);

            return View(visualizarVm);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CadastrarGarcomViewModel cadastrarVM = new CadastrarGarcomViewModel();

            return View(cadastrarVM);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarGarcomViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);
             
            var entidade = new Garcom(cadastrarVM.Nome, cadastrarVM.Cpf);

            repositorioGarcom.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var registro = repositorioGarcom.SelecionarRegistroPorId(id);

            EditarGarcomViewModel editarVM = new EditarGarcomViewModel(id, registro.Nome, registro.Cpf);

            return View(editarVM);
        }

        [HttpPost]
        public IActionResult Editar(EditarGarcomViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            var garcomEditado = new Garcom(editarVM.Nome, editarVM.Cpf);

            repositorioGarcom.EditarRegistro(editarVM.Id, garcomEditado);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var registro = repositorioGarcom.SelecionarRegistroPorId(id);

            ExcluirGarcomViewModel excluirVM = new ExcluirGarcomViewModel(id, registro.Nome);

            return View(excluirVM);
        }

        [HttpPost]
        public IActionResult Excluir(ExcluirGarcomViewModel excluirVM)
        {
            repositorioGarcom.ExcluirRegistro(excluirVM.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
