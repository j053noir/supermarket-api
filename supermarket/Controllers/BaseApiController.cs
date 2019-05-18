using supermarket.Models;
using System.Web.Http;

namespace supermarket.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly SupermarketContext _context = null;

        protected SupermarketContext Context => _context ?? new SupermarketContext();
    }
}
