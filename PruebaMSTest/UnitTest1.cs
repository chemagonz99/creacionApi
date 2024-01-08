
using conexionBD;
using NuGet.Frameworks;

namespace PruebaMSTest


{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        //Prueba unitaria para la conexion de la base de datos
        public void TestMethod1()
        {

            Class1 t = new Class1();
            t.connect(true);
            t.webAPI();
            Assert.AreEqual(7, t.webAPI().Tables[0].Rows.Count);

            System.Diagnostics.Trace.WriteLine(t.conexion.ConnectionString);
          



        }

        //Prueba de los 4 procedures creados en la BD
        [TestMethod]
        public void TestMethodUserGet()
        {
            Class1 t = new Class1();
            t.connect();

            t.GetUsers(new User() { idUser= 3 });

        }

        [TestMethod]
        public void TestMethodUserCreate()
        {

            Class1 t = new Class1();
            t.connect();
            t.createUsers(new User() { Users = "pedro", email = "pedro@gmail.com", pass = "1234", Administrator = 1, idNegocio = 1, Manager = 2, validated = 1 });
        }

        [TestMethod]
        public void TestMethodUserUpdate()
        {
            Class1 t = new Class1();
            t.connect();
            t.updateUsers(new User() { email = "pedrito@gmail.com", idUser = 11 });
        }

        [TestMethod]
        public void TestMethodUserDelete()
        {
            Class1 t = new Class1();
            t.connect();
            t.deleteUsers(new User() { idUser = 11 });
        }

    }
}