using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using UPC.APIBusiness.API.Security;

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
        public async Task<ActionResult> logincontribuyente(string login, string contracena)
        {
            var ret = _ContribuyenteloginRepository.logincontribuyente(login,contracena);

            if (ret != null)
            {
                var responseLogin = ret.data as EntityLoginResponse;
                var userId = responseLogin.codigocont;
                var userDoc = responseLogin.apenom;

                var token = JsonConvert
                                    .DeserializeObject<AccessToken>(
                                        await new Authentication()
                                        .GenerateToken(userDoc, userId)
                                        ).access_token;

                responseLogin.token = token;
                ret.data = responseLogin;
            }

            return Json(ret);
        }
    }
}