using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace conexionBD
{
    public class Class1
    {

        public SqlConnection conexion { get; set; }


        //Primera funcion para conectar BD, sin usuario ni contraseña, para entrar a la BD con Windows.
        public void connect() 
        {

            conexion = new SqlConnection();

            conexion.ConnectionString = " Integrated Security= SSPI;Persist Security Info=False;Initial Catalog=webAPI;Data Source=DESKTOP-2DFIPUA";
            conexion.Open();

        
        }

        //Funcion para entrar con SQL auth, con usuario a contraseña, con booleano.

        public void connect(bool auth)
        {

            conexion = new ();

            conexion.ConnectionString = "Persist Security Info=False;Initial Catalog=webAPI; User=chema;Password=blackOps2;Data Source=DESKTOP-2DFIPUA";
            conexion.Open();


        }

        public DataSet webAPI()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dsAdapter = new SqlDataAdapter();
            dsAdapter.SelectCommand = new SqlCommand("select * from Users", conexion);

            dsAdapter.Fill(ds);
            return ds;
        }

       // A PARTIR DE AQUI SON FUNCIONES PARA REALIZAR PROCEDURES

        //Funciones para realizar los procedures.
        public DataSet queryGenericStored(string query, List<KeyValuePair<string, dynamic>> parameters= null)
        {
            DataSet dt= new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Clear();

            foreach (KeyValuePair<string, dynamic> param in parameters)
            {
                AddParameter(ref adapter, param);
            }

            adapter.Fill(dt);
            return dt;

        }

        public void AddParameter(ref SqlDataAdapter set, KeyValuePair<string, dynamic> val)
        {
            if(val.Value != null)
            {
                set.SelectCommand.Parameters.AddWithValue(val.Key, val.Value);
            }
        }
        

        //Funcion para obtener el user, en este hacemos una funcion que nos devuelve un return, ya que al principio lo que se hace es buscar el usuario y luego nos lo devuelve.

        public IList<User> GetUsers(User user_to_search)
        {
            List<KeyValuePair<string,dynamic>> userparam= new List<KeyValuePair<string,dynamic>>();
            //userparam.Add(new KeyValuePair<string, dynamic>("@idUser", user_to_search.idUser));
            //userparam.Add(new KeyValuePair<string, dynamic>("@Users", user_to_search.Users));
            //userparam.Add(new KeyValuePair<string, dynamic>("@pass", user_to_search.pass));
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_search.email));
            //userparam.Add(new KeyValuePair<string, dynamic>("@Administrator", user_to_search.Administrator));
            //userparam.Add(new KeyValuePair<string, dynamic>("@Manager", user_to_search.Manager));
            //userparam.Add(new KeyValuePair<string, dynamic>("@idNegocio", user_to_search.idNegocio));
            //userparam.Add(new KeyValuePair<string, dynamic>("@validated", user_to_search.validated));

            DataSet ds = queryGenericStored("svg_Users_get", userparam);
            IList<User> items = ds.Tables[0].AsEnumerable().Select(row =>
            
            new User
            {
                idUser= row.Field<int?>("idUser"),
                Users= row.Field<string>("Users"),
                email= row.Field<string>("email"),
                Administrator= row.Field<int?>("Administrator"),
                Manager= row.Field<int?>("Manager"),
                pass= row.Field<string>("pass"),
                idNegocio= row.Field<int?>("idNegocio")

            }).ToList();
            return items;
        }
 
        //CRUD PARA CREAR USER
        public void  createUsers( User user_to_create)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@Users", user_to_create.Users));
            userparam.Add(new KeyValuePair<string, dynamic>("@pass", user_to_create.pass));
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_create.email));
            userparam.Add(new KeyValuePair<string, dynamic>("@Administrator", user_to_create.Administrator));
            userparam.Add(new KeyValuePair<string, dynamic>("@Manager", user_to_create.Manager));
            userparam.Add(new KeyValuePair<string, dynamic>("@idNegocio", user_to_create.idNegocio));
            userparam.Add(new KeyValuePair<string, dynamic>("@validated", user_to_create.validated));

            DataSet ds = queryGenericStored("svg_Users_create", userparam);
        }

        //CRUD PARA ACTUALIZAR USER


        public void updateUsers(User user_to_update)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@idUser", user_to_update.idUser));
            //userparam.Add(new KeyValuePair<string, dynamic>("@Email", user_to_update.email));
            userparam.Add(new KeyValuePair<string, dynamic>("@NewEmail", user_to_update.email));


            DataSet ds = queryGenericStored("svg_Users_update", userparam);
        }

        //Eliminar usuario
        
        public void deleteUsers(User user_to_delete)
        {
            List<KeyValuePair<string, dynamic>> userparam = new List<KeyValuePair<string, dynamic>>();
            userparam.Add(new KeyValuePair<string, dynamic>("@email", user_to_delete.email));


            DataSet ds = queryGenericStored("svg_Users_delete", userparam);
        }

    }
}