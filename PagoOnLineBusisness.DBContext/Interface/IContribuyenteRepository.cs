
using PagoOnLineBusisness.DBEntity.Base;
using PagoOnLineBusisness.DBEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;

namespace PagoOnLineBusisness.DBContext.Interface
{
    public interface IContribuyenteRepository
    {
        ResponseBase actualiza(EntityContribuyente contribuyente);
        ResponseBase consulta();
        
    }


    

}
