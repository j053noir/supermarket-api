using supermarket.Models;
using supermarket.Models.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace supermarket.Controllers
{
    // [Authorize]
    public class AuthController : BaseApiController
    {
        [HttpPost, Route("login")]
        public ResponseBinding Login(LoginBinding model)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseBinding
                {
                    HttpStatusCode = 422,
                    Message = "Todos los campos son necesarios",
                    Status = false
                };
            }

            var user = this.Context.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
            {
                return new ResponseBinding
                {
                    HttpStatusCode = 422,
                    Message = "Usuario y/o Contraseña incorrectos",
                    Status = false
                };
            }

            user.Token = Guid.NewGuid();
            this.Context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            this.Context.SaveChanges();

            return new ResponseBinding
            {
                Content = user.Token,
                HttpStatusCode = 422,
                Message = "Inicio de sesión exitoso",
                Status = false
            };
        }

        // GET api/values
        public ResponseBinding Get()
        {
            return new ResponseBinding
            {
                Content = this.Context.Users.ToList(),
                HttpStatusCode = (int)HttpStatusCode.OK,
                Status = true
            };
        }

        // GET api/values/5
        public ResponseBinding Get(string id)
        {
            var guid = Guid.Parse(id);
            var user = this.Context.Users.Find(guid);

            if (user == null)
            {
                return new ResponseBinding
                {
                    HttpStatusCode = (int)HttpStatusCode.OK,
                    Message = $"Usuario con id ({id}) no encontrado",
                    Status = false
                };
            }

            return new ResponseBinding
            {
                Content = user,
                HttpStatusCode = (int)HttpStatusCode.OK,
                Status = true
            };
        }

        // POST api/values
        public ResponseBinding Post([FromBody] UserBinding model)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseBinding
                {
                    HttpStatusCode = 422,
                    Message = "Todos los campos son necesarios",
                    Status = false
                };
            }

            var user = new User
            {
                Name = model.Name,
                Password = model.Password,
                Username = model.Username,
            };

            this.Context.Users.Add(user);
            this.Context.SaveChanges();

            return new ResponseBinding
            {
                Content = user,
                Message = "Usuario creado con exito",
                HttpStatusCode = (int)HttpStatusCode.OK,
                Status = true
            };
        }

        // PUT api/values/5
        public ResponseBinding Put(string id, [FromBody]UserBinding model)
        {
            var guid = Guid.Parse(id);
            var user = this.Context.Users.Find(guid);

            if (user == null)
            {
                return new ResponseBinding
                {
                    HttpStatusCode = (int)HttpStatusCode.OK,
                    Message = $"Usuario con id ({id}) no encontrado",
                    Status = false
                };
            }


            //user.Username = model.Username;
            user.Name = model.Name;
            user.Password = model.Password;

            this.Context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            this.Context.SaveChanges();

            return new ResponseBinding
            {
                Content = user,
                HttpStatusCode = (int)HttpStatusCode.OK,
                Message = "Usuario Actualizado con exito",
                Status = true
            };
        }
    }
}
