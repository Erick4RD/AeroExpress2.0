using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AerolineaExpress.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<avion> avions { get; set; }
        public DbSet<Empleados> empleados { get; set; }

        public DbSet<planificados> planificados { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

    }


    public class avion
    {
        [Key]
        public int AvionId { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Capacidad { get; set; }
        public Boolean Estado { get; set; }
        public virtual ICollection<planificados>  Planificados { get; set; }

    }

    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Departamento { get; set; }
        public string puesto { get; set; }


    }

    public class planificados
    {
        [Key]
        public int VuelosId { get; set; }
        public string Destino { get; set; }
        public string Hora_de_salida { get; set; }
        public string Hora_de_llegada { get; set; }
        public int Cantida_de_pasajeros { get; set; }
        public virtual avion Avion { get; set; }
        public virtual ICollection<Clientes> Clientes{ get; set; }

    }

    public class Clientes
    {
        [Key]
        public int ClientesId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Destino  { get; set; }
        public string MetodoDePago { get; set; }

        public string NumeroDeCuenta { get; set; }
        public virtual planificados Planificados { get; set; }
        public Boolean confimarVuelo { get; set; }
    }


}
