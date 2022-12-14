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

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new DepartamentoDto());
            }
            else
            {
                var Depart = await _departamentoRepository.GetOnlyDepartamentoAsync(id);
                if (!Depart.IsSuccess)
                {
                    return NotFound();
                }

                return View(Depart.Result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, DepartamentoDto avatar)
        {
            if (ModelState.IsValid)
            {
                Departamento OnlyDept = new Departamento();
                try
                {
                    if (id == 0) //Insert
                    {


                        OnlyDept.Descripcion = avatar.Descripcion;
                        OnlyDept.RegistrationDate = DateTime.Now.ToUniversalTime();
                        OnlyDept.IsActive = 1;
                        var ResultOnly = await _departamentoRepository.AddDataAsync(OnlyDept);
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

                        var Only = await _departamentoRepository.OnlyDepartamentoGetAsync(avatar.DepartamentoId);

                        if (!Only.IsSuccess)
                        {
                            return NotFound();
                        }
                        OnlyDept = Only.Result;
                        OnlyDept.Descripcion = (avatar.Descripcion == Only.Result.Descripcion) ? Only.Result.Descripcion : avatar.Descripcion;
                        var result = await _departamentoRepository.UpdateDataAsync(OnlyDept);

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

                return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAll", await _departamentoRepository.GetAllDepartamentoAsync()) });

            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEdit", avatar) });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depto = await _departamentoRepository.GetOnlyDepartamentoAsync(id.Value);
            if (!depto.IsSuccess)
            {
                return NotFound();
            }

            var onlyDepto = await _departamentoRepository.DeactivateDepartamentoAsync(depto.Result);

            if (!onlyDepto.IsSuccess)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
