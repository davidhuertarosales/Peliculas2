using Movies10.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Peliculain : DropCreateDatabaseAlways<Pelidb>
    {

        protected override void Seed(Pelidb context)
        {
            base.Seed(context);

            //Create some photos
            var photos = new List<Pelicula>
            {
                new Pelicula {
                    Title = "Volver al futuro",
                    Poster = getFileBytes("\\im\\regreso-al-futuro.jpg"),
                    ImageMimeType = "image/jpeg",
                    Sinopsis = "I was very impressed with myself",
                    Director = "Fred",
                    Fecha_estreno = DateTime.Today
                },
                new Pelicula {
                    Title = "My New Adventure Works Bike",
                    Sinopsis = "It's the bees knees!",
                    Director = "Fred",
                    Poster = getFileBytes("\\im\\tiburon.jpg"),
                    ImageMimeType = "image/jpeg",
                    Fecha_estreno = DateTime.Today
                },
                new Pelicula {
                    Title = "View from the start line",
                    Sinopsis = "I took this photo just before we started over my handle bars.",
                    Director = "Sue",
                    Poster = getFileBytes("\\im\\scarface.jpg"),
                    ImageMimeType = "image/jpeg",
                    Fecha_estreno = DateTime.Today
                }
            };
            photos.ForEach(s => context.Pelicula.Add(s));
            context.SaveChanges();

            //Create some comments
           
        }
        //This gets byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}