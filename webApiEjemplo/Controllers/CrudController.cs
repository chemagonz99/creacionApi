using conexionBD;
using Microsoft.AspNetCore.Mvc;

namespace webApiEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrudController : ControllerBase
    {

        private readonly ILogger<CrudController> _logger;
        public CrudController(ILogger<CrudController> logger)
        {
            _logger = logger;
        }



        [HttpGet(Name = "GetUsers")]
        

        public IList<User> Get(string correo)
        {


            

            Class1 t= new Class1();
            t.connect();
            User u = new User() { email = correo};

            IList<User> users = t.GetUsers(u);
            
            return users;

        }

        [HttpPut(Name = "UpdateUsers")]

        public void UpdateUser(int id, string newEmail)
        {
            Class1 t = new Class1();
            t.connect();

            User u = new User() { idUser = id , email= newEmail};

            t.updateUsers(u);

        }

        [HttpPost("createUser")]

        public void createUser(userIgnore u)
        {
            Class1 t = new Class1();
            t.connect();
            
            User user = new User() 
            {  
                Users= u.Users, 
                pass= u.pass,
                email= u.email, 
                Administrator=u.Administrator,
                idNegocio= u.idNegocio, 
                Manager= u.Manager, 
                validated=u.validated 
            };

            t.createUsers(user);

        }


        [HttpDelete("deleteUser")]
        public void deleteUser(string correo)
        {
            Class1 t = new Class1();
            t.connect();

            User user = new User() { email =correo };

            t.deleteUsers(user);
        }
    }
}
