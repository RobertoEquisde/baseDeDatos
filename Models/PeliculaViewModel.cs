using System.ComponentModel.DataAnnotations;
namespace WEB7.Controllers;

public class PeliculasViewModel{
    [Key] 
    public int Id{get; set;}
    [Required]
    public string? Nombre{get; set;}
    public string? Genero{get; set;}
    [Range(2024,int.MaxValue,ErrorMessage ="Fuera de rango")]
    public int Anio{get; set;}
    public char Clasificacion {get; set;}
    public string? Distribuidora {get; set;}
}