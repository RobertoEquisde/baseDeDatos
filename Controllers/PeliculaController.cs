using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Configuration;
using WEB7.Models;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace WEB7.Controllers;

public class PeliculaController : Controller
{
    
    private readonly IConfiguration _conf;

    public PeliculaController(IConfiguration conf)
    {
        this._conf = conf;
    }

    public IActionResult Index() {
        DataTable tbl =  new DataTable();
        using(MySqlConnection cnx = new MySqlConnection(_conf.GetConnectionString("DevConnection"))){
            cnx.Open();
            string query = "SELECT * FROM donantes";
            MySqlDataAdapter adp = new MySqlDataAdapter (query,cnx);
            adp.Fill(tbl);
            

        }
        return View(tbl);
    }
    public IActionResult Anadir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Anadir(PeliculasViewModel model)
    {
        if (ModelState.IsValid)
        {
            using (MySqlConnection cnx = new MySqlConnection(_conf.GetConnectionString("DevConnection")))
            {
                cnx.Open();
                string query = "INSERT INTO donantes(nombre, apellido, edad, genero, tipoSangre, direccion, telefono, correoElectronico, ultimaDonacion, restricciones)" +
                            "VALUES (@nombre, @apellido, @edad, @genero, @tipoSangre, @direccion, @telefono , @correoElectronico, @ultimaDonacion, @restricciones)";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@nombre", model.nombre);
                cmd.Parameters.AddWithValue("@apellido", model.apellido);
                cmd.Parameters.AddWithValue("@edad", model.edad);
                cmd.Parameters.AddWithValue("@genero", model.genero);
                cmd.Parameters.AddWithValue("@tipoSangre", model.tipoSangre);
                cmd.Parameters.AddWithValue("@direccion", model.direccion);
                cmd.Parameters.AddWithValue("@telefono", model.telefono);
                cmd.Parameters.AddWithValue("@correoElectronico", model.correoElectronico);
                cmd.Parameters.AddWithValue("@ultimaDonacion", model.ultimaDonacion);
                cmd.Parameters.AddWithValue("@restricciones", model.restricciones);
                cmd.ExecuteNonQuery();
                cnx.Close();
            }

            return RedirectToAction("Index");
        }

        return View(model);
    }
}
