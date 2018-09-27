using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies10.Models
{
    public class Pelicula
    {
        //PhotoID. This is the primary key
        [Key]
        public int PeliID { get; set; }
        //Title. The title of the photo
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        //Title. The title of the photo
        [DisplayName("Poster")]
        [MaxLength]
        public byte[] Poster { get; set; }
        //ImageMimeType, stores the MIME type for the PhotoFile
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        //Description.
        [DataType(DataType.MultilineText)]
        public string Sinopsis { get; set; }
        //CreatedDate
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_estreno { get; set; }
        //UserName. This is the name of the user who created the photo
        [Required]
        public string Director { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}