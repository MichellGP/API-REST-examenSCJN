using correspondencia.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace correspondencia.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }

        public DbSet<CorreoLocal> CorreoLocal { get; set; }

        public DbSet<TipoPaquete> TipoPaquete { get; set; }


        public DbSet<SP_CONSULTA> Sp_Consulta { get; set; }
    }
}

