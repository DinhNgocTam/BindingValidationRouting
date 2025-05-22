using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public static class ModelSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var company1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var company2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = company1Id,
                    Name = "Contoso Ltd.",
                    Address = "123 Main St",
                    Country = "USA"
                },
                new Company
                {
                    Id = company2Id,
                    Name = "Fabrikam Inc.",
                    Address = "456 Second Ave",
                    Country = "UK"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Name = "Alice Smith",
                    Age = 30,
                    Position = "Developer",
                    CompanyId = company1Id
                },
                new Employee
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Name = "Bob Johnson",
                    Age = 40,
                    Position = "Manager",
                    CompanyId = company2Id
                }
            );
        }
    }
}
