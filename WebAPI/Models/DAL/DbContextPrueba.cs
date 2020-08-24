using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Entities;

namespace WebAPI.Models.DAL
{
    public class DbContextPrueba : DbContext
    {
        public DbContextPrueba(DbContextOptions<DbContextPrueba> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<CargoEmpleado> CargoEmpleados { get; set; }

    }
}
