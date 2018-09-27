using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Movies10.Models;

namespace Movies.Models
{
    public class Pelidb : DbContext
    {
        public Pelidb() : base()
        {
            this.Database.CommandTimeout = 180;
        }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
    }
}