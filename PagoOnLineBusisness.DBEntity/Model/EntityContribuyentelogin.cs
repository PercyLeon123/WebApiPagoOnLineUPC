using PagoOnLineBusisness.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagoOnLineBusisness.DBEntity.Model
{
    public class EntityContribuyentelogin : EntityBase
    {
        public string codigocont { get; set; }
        public string login_cont { get; set; }
        public string contracena { get; set; }
     
    }
}