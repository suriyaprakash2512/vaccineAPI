using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace TestProject1
{
    public class UserLogin
    {
        public bool Login(string Username, string password)
        {
            return Username == "User" && password == "User@123";
        }
    }
    [TestFixture]

    public class UserLoginTest
    {
        [Test]
        public void SuccessfulLoginTest()
        {
            var userSignTest = new UserLogin();
            bool result = userSignTest.Login("User", "User@123");
            Assert.IsTrue(result);
        }
        [Test]
        public void InvalidusernameTest()
        {
            var userSignTest = new UserLogin();
            bool result = userSignTest.Login("Admin", "User@123");
            Assert.IsFalse(result);
        }
        [Test]
        public void InvalidPasswordTest()
        {
            var userSignTest = new UserLogin();
            bool result = userSignTest.Login("User", "Admin@123");
            Assert.IsFalse(result);
        }
    }
}
