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
    public IActionResult Editar(int id)
    {
        using (MySqlConnection cnx = new MySqlConnection(_conf.GetConnectionString("DevConnection")))
        {
            cnx.Open();
            string query = "SELECT * FROM donantes WHERE id = @ID";
            MySqlCommand cmd = new MySqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@ID", id);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    PeliculasViewModel model = new PeliculasViewModel
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        nombre = Convert.ToString(reader["nombre"]),
                        apellido = Convert.ToString(reader["apellido"]),
                        edad = Convert.ToInt32(reader["edad"]),
                        genero = Convert.ToString(reader["genero"]),
                        tipoSangre = Convert.ToString(reader["tipoSangre"]),
                        direccion = Convert.ToString(reader["direccion"]),
                        telefono = Convert.ToString(reader["telefono"]),
                        correoElectronico = Convert.ToString(reader["correoElectronico"]),
                        ultimaDonacion = Convert.ToDateTime(reader["ultimaDonacion"]),
                        restricciones = Convert.ToString(reader["restricciones"])
                    };

                    return View(model);
                }
            }
        }
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult Editar(PeliculasViewModel model)  
    {
        
        if(ModelState.IsValid)
        {
            using (MySqlConnection cnx = new MySqlConnection(_conf.GetConnectionString("DevConnection")))
            {
                    cnx.Open();
                    string query = "UPDATE donantes SET nombre = @Nombre , apellido = @Apellido , edad = @Edad , genero = @Genero ,tipoSangre = @TipoSangre , direccion = @direccion , telefono = @Telefono, correoElectronico = @CorreoElectronico, ultimaDonacion = @UltimaDonacion,restricciones = @Restricciones WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, cnx);

                        cmd.Parameters.AddWithValue("@Nombre", model.nombre);
                        cmd.Parameters.AddWithValue("@Apellido", model.apellido);
                        cmd.Parameters.AddWithValue("@Edad", model.edad);
                        cmd.Parameters.AddWithValue("@Genero", model.genero);
                        cmd.Parameters.AddWithValue("@TipoSangre", model.tipoSangre);
                        cmd.Parameters.AddWithValue("@Direccion", model.direccion);
                        cmd.Parameters.AddWithValue("@Telefono", model.telefono);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", model.correoElectronico);
                        cmd.Parameters.AddWithValue("@UltimaDonacion", model.ultimaDonacion);
                        cmd.Parameters.AddWithValue("@Restricciones", model.restricciones);
                        cmd.Parameters.AddWithValue("@ID", model.ID);
                        cmd.ExecuteNonQuery();
                    
            }
                      
            return RedirectToAction("Index");
          
        }
        
         return View(model);
    }

        public IActionResult Eliminar(int id)
    {
        using (MySqlConnection cnx = new MySqlConnection(_conf.GetConnectionString("DevConnection")))
        {
            cnx.Open();
            string query = "DELETE FROM donantes WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, cnx);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        return RedirectToAction("Index");
    }
    
}
