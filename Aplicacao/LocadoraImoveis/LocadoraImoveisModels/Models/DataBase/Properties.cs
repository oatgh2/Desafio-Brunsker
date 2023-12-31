﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocadoraImoveisModels.Models.DataBase
{
    [Table("properties")]
    [Index("IdUser", Name = "FK_Properties_User_idx")]
    public partial class Properties
    {
        [Key]
        [Column("idproperties")]
        public int Idproperties { get; set; }
        [Required]
        [Column("name")]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        [Column("bairro")]
        [StringLength(256)]
        public string Bairro { get; set; }
        [Column("numero")]
        public int Numero { get; set; }
        [Required]
        [Column("cidade")]
        [StringLength(256)]
        public string Cidade { get; set; }
        [Required]
        [Column("cep")]
        [StringLength(9)]
        public string Cep { get; set; }
        [Required]
        [Column("estado")]
        [StringLength(45)]
        public string Estado { get; set; }
        [Column("idUser")]
        public int? IdUser { get; set; }
        [Column("isRented")]
        public sbyte IsRented { get; set; }

        [ForeignKey("IdUser")]
        [InverseProperty("Properties")]
        public virtual User IdUserNavigation { get; set; }
    }
}