using DBContext;
using DBEntity;
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
    public class ContribuyenteController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IContribuyenteRepository _ContribuyenteRepository;


        /// <summary>
        /// 
        /// </summary>

        public ContribuyenteController(IContribuyenteRepository ContribuyenteRepository)
        {
            _ContribuyenteRepository = ContribuyenteRepository;

        }

        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("datosCont")]
        public ActionResult datosCont()
        {
            var ret = _ContribuyenteRepository.datosCont();

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("actualiza")]
        [HttpPost]
        [Authorize]
        public ActionResult actualiza(EntityContribuyente contribuyente)
        {
            var ret = _ContribuyenteRepository.actualiza(contribuyente);

            return Json(ret);
        }

    }
}