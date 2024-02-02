using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class AdminLogin
    {
        public bool Login(string Username, string password)
        {
            return Username == "Admin" && password == "123";
        }
    }
    [TestFixture]

    public class AdminLogintest
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            var adminloginTest = new AdminLogin();
            bool result = adminloginTest.Login("Admin", "123");
            Assert.IsTrue(result);
        }
        [Test]
        public void InvalidUsernameTest()
        {
            var adminloginTest = new AdminLogin();
            bool result = adminloginTest.Login("Admin@123", "123");
            Assert.IsFalse(result);
        }
        [Test]
        public void InvalidPasswordTest()
        {
            var adminloginTest = new AdminLogin();
            bool result = adminloginTest.Login("Admin", "12345");
            Assert.IsFalse(result);
        }
    }
}

