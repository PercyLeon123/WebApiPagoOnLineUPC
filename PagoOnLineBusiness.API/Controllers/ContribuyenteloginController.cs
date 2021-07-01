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
    [Route("api/Contribuyentelogin")]
    [ApiController]
    public class ContribuyenteloginController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IContribuyenteloginRepository _ContribuyenteloginRepository;


        /// <summary>
        /// 
        /// </summary>
        
        public ContribuyenteloginController(IContribuyenteloginRepository ContribuyenteloginRepository)
        {
            _ContribuyenteloginRepository = ContribuyenteloginRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("LoginContribuyente")]
        public ActionResult logincontribuyente( )
        {
            var ret = _ContribuyenteloginRepository.logincontribuyente();

            return Json(ret);
        }



    }


}