﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace navettes.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class navetteEntities1 : DbContext
    {
        public navetteEntities1()
            : base("name=navetteEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abonnement> Abonnement { get; set; }
        public virtual DbSet<Administrateur> Administrateur { get; set; }
        public virtual DbSet<bus> bus { get; set; }
        public virtual DbSet<Demande> Demande { get; set; }
        public virtual DbSet<Navette> Navette { get; set; }
        public virtual DbSet<Offre> Offre { get; set; }
        public virtual DbSet<Ste> Ste { get; set; }
        public virtual DbSet<Voyageur> Voyageur { get; set; }
    }
}