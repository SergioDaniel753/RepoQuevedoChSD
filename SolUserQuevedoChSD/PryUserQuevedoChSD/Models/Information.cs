using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PryUserQuevedoChSD.Models
{
    public enum Datos
    {
        id,
        Name,
        Email,
        Address,
        Geo
    }

    public enum Extras
    {
        Phone,
        website,
        Company,
        name,
        CathPhrase
    }

    public class Information
    {

        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nombre debe contener de 5 a 100 caracteres", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Email debe contener de 10 a 30 caracteres incluyendo @ y .", MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:stt/st/ct}", ApplyFormatInEditMode = true)]
        public Address Infor { get; set; }

        [Required]
        public Geo gf { get; set; }
        public Company fd {get;set;}

        public Datos Info{get;set;}
        public Extras Einfo { get; set; }

}



    }
