﻿using Microsoft.AspNetCore.Authorization;
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
    public class EstadoCuentaController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IEstadoCuentaRepository _EstadoCuentaRepository;


        /// <summary>
        /// 
        /// </summary>
        
        public EstadoCuentaController(IEstadoCuentaRepository EstadoCuentaRepository)
        {
            _EstadoCuentaRepository = EstadoCuentaRepository;

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
            var ret = _EstadoCuentaRepository.EstadoCuentaPendiente(estadoCuenta);

            return Json(ret);
        }


        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("EstadoCuentaHistorico")]
        public ActionResult EstadoCuentaHistorico(EntityEstadoCuenta estadoCuenta)
        {
            var ret = _EstadoCuentaRepository.EstadoCuentaHistorico(estadoCuenta);

            return Json(ret);
        }

    }
}