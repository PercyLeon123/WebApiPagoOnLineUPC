
using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEstadoCuenta : EntityBase
    {
        public string codigocont { get; set; }
        public string ncuota { get; set; }
        public string nperiodo { get; set; }
        public DateTime fecha_vcmto { get; set; }
        public string fact { get; set; }
        public string afrp1 { get; set; }
        public string code { get; set; }
        public string fracciona { get; set; }

        public string desfracciona { get; set; }
        public decimal imp_deuda { get; set; }

        public DateTime fecha_pago { get; set; }

        public string nro_ope { get; set; }
        public string nro_rec { get; set; }

        public string nro_tran { get; set; }

        public string serie { get; set; }

    }
}