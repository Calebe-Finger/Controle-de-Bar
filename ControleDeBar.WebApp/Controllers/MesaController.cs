using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloMesa;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class MesaController : Controller
    {
        private readonly RepositorioMesaEmArquivo repositorioMesa;

        public MesaController()
        {
            ContextoDados contexto = new ContextoDados(carregarDados: true);

            repositorioMesa = new RepositorioMesaEmArquivo(contexto);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarRegistros(); //1 registro
            
            VisualizarMesasViewModel visualizarVM = new VisualizarMesasViewModel(mesas);

            return View(visualizarVM);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CadastrarMesaViewModel cadastrarVM = new CadastrarMesaViewModel();

            return View(cadastrarVM);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarMesaViewModel cadastrarVM)
        {
            if (!ModelState.IsValid)
                return View(cadastrarVM);

            var entidade = new Mesa(cadastrarVM.Numero, cadastrarVM.Capacidade);

            repositorioMesa.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var registro = repositorioMesa.SelecionarRegistroPorId(id);

            EditarMesaViewModel editarVM = new EditarMesaViewModel(id, registro.Numero, registro.Capacidade);

            return View(editarVM);
        }

        [HttpPost]
        public IActionResult Editar(EditarMesaViewModel editarVM)
        {
            if (!ModelState.IsValid)
                return View(editarVM);

            var mesaEditada = new Mesa(editarVM.Numero, editarVM.Capacidade);
                    
            repositorioMesa.EditarRegistro(editarVM.Id, mesaEditada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var registro = repositorioMesa.SelecionarRegistroPorId(id);

            ExcluirMesaViewModel excluirVM = new ExcluirMesaViewModel(id, registro.Numero);

            return View(excluirVM);
        }

        [HttpPost]
        public IActionResult Excluir(ExcluirMesaViewModel excluirVM)
        {
            repositorioMesa.ExcluirRegistro(excluirVM.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}

