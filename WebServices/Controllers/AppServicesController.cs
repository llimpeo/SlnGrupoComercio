using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Business.Entities.Search;
using Business.Services;
using Business.Components;

namespace WebServices.Controllers
{
    [Produces("application/json")]
    [Route("api/AppServices")]
    public class AppServicesController : Controller
    {
        [HttpPost]
        public ActionResult SearchAllOrdenesPagoBySucursal(SCOrdenPago ordenPago)
        {
            try
            {
                IBCOrdenPago ServiceProvider = new BCOrdenPago();

                var searchResult = ServiceProvider.FindOrdenesPagoBySucursal(ordenPago);
                return Json(new { Success = true, OrdenesPago = searchResult.OrdenesPago, Total = searchResult.OrdenesPago.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Exception = true, Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult SearchAllSucursalByBanco(int idBanco)
        {
            try
            {
                IBCSucursal ServiceProvider = new BCSucursal();
                var searchResult = ServiceProvider.FindAllSucursalByIdBanco(idBanco);
                return Json(new { Success = true, Sucursales = searchResult.Sucursales, Total = searchResult.Sucursales.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Exception = true, Message = ex.Message });
            }
        }










    }
}