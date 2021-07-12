

using DBEntity;

namespace DBContext
{
    public interface IContribuyenteRepository
    {
        ResponseBase actualiza(EntityContribuyente contribuyente);
        ResponseBase consulta(string codigo);
        ResponseBase datosCont();
        
    }


    

}
