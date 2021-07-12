using DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class EstadoCuentaHistoricoController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IEstadoCuentaHistoricoRepository _EstadoCuentaRepository;


        /// <summary>
        /// 
        /// </summary>
        
        public EstadoCuentaHistoricoController(IEstadoCuentaHistoricoRepository EstadoCuentaRepository)
        {
            _EstadoCuentaRepository = EstadoCuentaRepository;

        }

        /// <summary>
        /// 


        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("EstadoCuentaHistorico")]
        public ActionResult EstadoCuentaHistorico(string idcontribuyente, System.DateTime fdesde,System.DateTime fhasta,int retorno)
        {
            var ret = _EstadoCuentaRepository.EstadoCuentaHistorico( idcontribuyente,fdesde,fhasta,retorno );


            return Json(ret);
        }

    }
}