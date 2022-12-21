using ECommerce.App.Helpers;
using ECommerce.Common.Application.Implementacion;
using ECommerce.Common.Application.Interfaces;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;
using static ECommerce.App.Helpers.ModalHelper;

namespace ECommerce.App.Controllers
{
    public class ProductsControllercs : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IFlashMessage _flashMessagee;

        public ProductsControllercs(IProductoRepository productoRepository, IFlashMessage flashMessagee)
        {
            _productoRepository = productoRepository;
            _flashMessagee = flashMessagee;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productoRepository.GetAllProductoAsync());
        }


        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProductoDto());
            }
            else
            {
                var Depart = await _productoRepository.GetOnlyProducoAsync(id);
                if (!Depart.IsSuccess)
                {
                   return NotFound();
                }
                return View(Depart.Result);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, ProductoDto avatar)
        {
            if (ModelState.IsValid)
            {
                Producto OnlyProd = new Producto();
                try
                {
                    if (id == 0) //Insert
                    {
                        OnlyProd.Descripcion = avatar.Descripcion;
                        OnlyProd.IsActive = 1;
                        var ResultOnly = await _productoRepository.AddDataAsync(OnlyProd);
                        if (ResultOnly.IsSuccess)
                        {
                            _flashMessagee.Info("Registro creado.");
                        }
                        else { _flashMessagee.Danger(ResultOnly.Message); }
                    }
                    else //Update
                    {
                        if (id != avatar.DepartamentoId)
                        {
                            _flashMessagee.Danger("Los datos son incorrectos!");
                            return View(avatar);
                        }
                        var Only = await _productoRepository.OnlyProducoGetAsync(avatar.DepartamentoId);
                        if (!Only.IsSuccess)
                        {
                            return NotFound();
                        }
                        OnlyProd = Only.Result;
                        OnlyProd.Descripcion = (avatar.Descripcion == Only.Result.Descripcion) ? Only.Result.Descripcion : avatar.Descripcion;
                        var result = await _productoRepository.UpdateDataAsync(OnlyProd);
                        if (result.IsSuccess)
                            _flashMessagee.Info("Registro actualizado.");
                        else _flashMessagee.Danger(result.Message);
                    }
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessagee.Danger("Ya existe una categoría con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessagee.Danger(dbUpdateException.InnerException.Message);
                    }
                    return View(avatar);
                }
                catch (Exception exception)
                {
                    _flashMessagee.Danger(exception.Message);
                    return View(avatar);
                }
                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAll", await _productoRepository.GetAllProductoAsync()) });
            }
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEdit", avatar) });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prod = await _productoRepository.GetOnlyProducoAsync(id.Value);
            if (!prod.IsSuccess)
            {
                return NotFound();
            }
            var OnlyProd = await _productoRepository.DeactivateProducoAsync(prod.Result);
            if (!OnlyProd.IsSuccess)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
