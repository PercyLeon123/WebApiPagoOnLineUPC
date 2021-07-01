using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagoOnLineBusisness.DBContext.Interface;
using PagoOnLineBusisness.DBEntity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PagoOnLineBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Contribuyente")]
    [ApiController]
    public class EstadoCuentaPendienteController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IEstadoCuentaPendienteRepository _EstadoCuentaPendienteRepository;


        /// <summary>
        /// 
        /// </summary>
        
        public EstadoCuentaPendienteController(IEstadoCuentaPendienteRepository EstadoCuentaPendienteRepository)
        {
            _EstadoCuentaPendienteRepository = EstadoCuentaPendienteRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("EstadoCuentaPendiente")]
        public ActionResult EstadoCuentaPendiente(EntityEstadoCuenta estadoCuenta)
        {
            var ret = _EstadoCuentaPendienteRepository.EstadoCuentaPendiente(estadoCuenta);

            return Json(ret);
        }



    }
}