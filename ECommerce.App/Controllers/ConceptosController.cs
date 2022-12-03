using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class ConceptosController : Controller
    {
        private readonly IConceptoRepository _conceptoRepository;

        public ConceptosController(IConceptoRepository conceptoRepository)
        {
            _conceptoRepository = conceptoRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _conceptoRepository.GetAllConceptoAsync());
        }
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ConceptoDto());
            }
            else
            {
                var concepto = await _conceptoRepository.GetOnlyConceptoAsync(id);
                if (!concepto.IsSuccess)
                {
                    return NotFound();
                }

                return View(concepto.Result);
            }
        }
    }
}
