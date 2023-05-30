using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Configuration;
using WEB7.Models;
using MySql.Data.MySqlClient;

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
            string query = "SELECT * FROM peliculas";
            MySqlDataAdapter adp = new MySqlDataAdapter (query,cnx);
            adp.Fill(tbl);
            

        }
        return View(tbl);
    }
}