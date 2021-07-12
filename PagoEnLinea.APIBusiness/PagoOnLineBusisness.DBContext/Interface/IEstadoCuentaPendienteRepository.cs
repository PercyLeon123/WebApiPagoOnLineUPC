

using DBEntity;

namespace DBContext
{
    public interface IEstadoCuentaPendienteRepository
    {
        ResponseBase EstadoCuentaPendiente(string idcontribuyente , int retorno);
        
    }


}
