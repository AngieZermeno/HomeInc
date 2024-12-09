using HomeInc.Aplication.Interfaces;
using System.Security.Claims;

namespace HomeInc.Infraestructure.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsuario()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        }

        public string GetUsuarioId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
