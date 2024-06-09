using ApiApp.Model.DTO;
using Internship.Model;
using Microsoft.AspNetCore.Mvc;
using Internship.ObjectModel;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly APIDbContext _context;

        public AuthController(APIDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var user = _context.Admins.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
                return Unauthorized();

            // Generare token simplu (într-o aplicație reală ar trebui folosit JWT)
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            // Salvarea token-ului în sesiune sau în altă parte pentru validare
            user.Token = token;
            _context.SaveChanges();

            return Ok(token);
        }

        
    }
}
