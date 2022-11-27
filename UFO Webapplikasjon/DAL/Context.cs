using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UFO_Webapplikasjon.Model
{
    public class Sightings
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Duration { get; set; }
        public string Dateposted { get; set; }
        public string Dateupdated { get; set; }
        public string Datetime { get; set; }
        public string Comments { get; set; }
        public virtual Users Users { get; set; }
        public virtual SightingLists SightingLists { get; set; }
    }
    public class SightingLists
    {
        public int Id { get; set; }
        public virtual Users Users { get; set; }
        public virtual Sightings Sightings { get; set; }
    }
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public virtual SightingLists SightingLists { get; set; }
    }

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
                    : base(options)
        {
            // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
            // dette er uavhenig av initiering av databasen (seeding)
            // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
            Database.EnsureCreated();
        }

        public DbSet<Sightings> Sightings { get; set; }
        public DbSet<SightingLists> SightingLists { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}