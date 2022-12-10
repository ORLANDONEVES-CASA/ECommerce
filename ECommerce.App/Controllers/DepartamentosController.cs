using ECommerce.Common.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Vereyon.Web;

namespace ECommerce.App.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IFlashMessage _flashMessagee;

        public DepartamentosController(IDepartamentoRepository departamentoRepository, IFlashMessage flashMessagee)
        {
            _departamentoRepository = departamentoRepository;
            _flashMessagee = flashMessagee;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _departamentoRepository.GetAllDepartamentoAsync());
        }
    }
}
