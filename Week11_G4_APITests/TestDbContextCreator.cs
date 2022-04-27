using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week11_G4_API.Data;

namespace Week11_G4_APITests
{
    internal class TestDbContextCreator
    {
        private const string ConnectionString = "Data Source=LAPTOP-05I8GA19;Initial Catalog=SchoolOfColleges;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SchoolofcollegesContext CreateContext() => new(
            new DbContextOptionsBuilder<SchoolofcollegesContext>()
            .UseSqlServer(ConnectionString)
            .Options);
    }
}
