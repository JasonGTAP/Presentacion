﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conexion.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProyectoInacapEntities : DbContext
    {
        public ProyectoInacapEntities()
            : base("name=ProyectoInacapEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Trabajador> Trabajador { get; set; }
        public virtual DbSet<Estacionamiento> Estacionamiento { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Bicicleta> Bicicleta { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
    }
}
