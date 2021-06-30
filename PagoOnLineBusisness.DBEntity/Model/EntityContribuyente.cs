using PagoOnLineBusisness.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagoOnLineBusisness.DBEntity.Model
{
    public class EntityContribuyente : EntityBase
    {
        public string codigocont { get; set; }
        public string apenom { get; set; }
        public string tipodoc { get; set; }
        public string nrodoc { get; set; }
        public string dirdomicilio { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }

        public string telefono4 { get; set; }

        public string correo { get; set; }
    }
}