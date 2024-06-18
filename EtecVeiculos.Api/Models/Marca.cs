using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EtecVeiculos.Api.Models;

public class Marca 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    [Display(Name = "Nome")]
    public string Nome { get; set; }
}