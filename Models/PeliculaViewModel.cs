using System.ComponentModel.DataAnnotations;
namespace WEB7.Controllers;

public class PeliculasViewModel{
        [Key]
        public int ID{get;set;}
        [Required]
        public String? nombre{get;set;}
        public String? apellido{get;set;}
        public int edad{get;set;}
        public String? genero{get;set;}
        public String? tipoSangre{get;set;}
        public String? direccion{get;set;}
        public String? telefono{get;set;}
        public String? correoElectronico {get;set;}
        
        public DateTime ultimaDonacion{get;set;}
        public String? restricciones {get;set;}
}