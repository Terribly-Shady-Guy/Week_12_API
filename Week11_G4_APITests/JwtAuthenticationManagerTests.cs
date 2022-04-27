using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week11_G4_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_G4_API.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateBadLoginTest()
        {
            var manager = new JwtAuthenticationManager("G4APIJwtKey1212$$");

            string token = manager.Authenticate("BadUsername", "BadPassword");

            Assert.IsTrue(token == "");
        }

        [TestMethod()]
        public void AuthenticateGoodLoginTest()
        {
            var manager = new JwtAuthenticationManager("G4APIJwtKey1212$$");

            string token = manager.Authenticate("Tyler", "Password123");

            Assert.IsFalse(token == "");
        }
    }
}