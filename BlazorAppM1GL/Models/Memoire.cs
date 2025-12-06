using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppM1GL.Models
{
    public class Memoire
    {
        [Key]
        public int IdM { get; set; }

        [Required]
        public required string Libelle { get; set; }

        public string? Description { get; set; }

        public DateTime DateM { get; set; }

        public required string Note { get; set; }

        public required string Verdict { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}