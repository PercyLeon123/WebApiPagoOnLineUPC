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
        [HttpGet]
        [Route("EstadoCuentaPendiente")]
        public ActionResult EstadoCuentaPendiente(string idcontribuyente, int retorno)
        {
            var ret = _EstadoCuentaPendienteRepository.EstadoCuentaPendiente(idcontribuyente,retorno);

            return Json(ret);
        }



    }
}