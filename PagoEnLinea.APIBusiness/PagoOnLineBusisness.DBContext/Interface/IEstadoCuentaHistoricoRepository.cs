

using DBEntity;
using System;

namespace DBContext
{
    public interface IEstadoCuentaHistoricoRepository
    {
        
        ResponseBase EstadoCuentaHistorico(string idcontribuyente, DateTime fdesde , DateTime fhasta , int retorno);
       
    }


}
