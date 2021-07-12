

using DBEntity;

namespace DBContext
{
    public interface IUserRepository
    {
        ResponseBase Insert(EntityUser user);
        ResponseBase Login(EntityLogin login);
    }
}
