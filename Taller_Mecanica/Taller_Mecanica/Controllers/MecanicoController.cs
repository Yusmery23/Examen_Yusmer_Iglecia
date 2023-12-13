using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Taller_Mecanica.Models;

using System.Data;
using System.Data.SqlClient;
namespace Taller_Mecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase

    //creo mi variable de lectura
    {
        private readonly string cadenaSQL;

        // Creo el metodo constructor

        public MecanicoController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");

        }

        // Procedo a listar los Mecánicos con que cuenta el taller

        [HttpGet]
        [Route("Lisa")]

        // Creo el Metodo 

        public IActionResult Lista()
        {
            List<Mecanico> Lista = new List<Mecanico>();

            //Utilizo el Try para capturar los errores que existan

            try
            {
                //Realizo la conexion a SQL

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();

                    //Creo comando de ejecución

                    var cmd = new SqlCommand("mecanico", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizo la lectura de la ejecución

                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            Lista.Add(new Mecanico()
                            {

                                idMecanico = Convert.ToInt32(rd["idMecanico"]),
                                Nombre = rd["Nombre"].ToString(),
                                Edad = Convert.ToInt32(rd["Edad"]),
                                Domicilio = rd["Domicilio"].ToString(),
                                Titulo = rd["Titulo"].ToString(),
                                Especialidad = rd["Especialidad"].ToString(),
                                SueldoBase = Convert.ToInt32(rd["SueldoBase"]),
                                GratTitulo = Convert.ToInt32(rd["GratTitulo"]),
                                SueldoTotal = Convert.ToInt32(rd["SueldoTotal"]),


                            });
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });

            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = Lista });

            }
        }


        //Creo el metodo para obtener un nombre específico

        [HttpGet]
        [Route("Obtener/{idMecanico:int}")]

        public IActionResult Obtener(int idMecanico)
        {

            List<Mecanico> Lista = new List<Mecanico>();
            Mecanico mecanico = new Mecanico();

            //Utilizo el Try para capturar los errores que existan

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();

                    //Creo comando de ejecución

                    var cmd = new SqlCommand("mecanico", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Realizo la lectura de la ejecución

                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            Lista.Add(new Mecanico()
                            {

                                idMecanico = Convert.ToInt32(rd["idMecanico"]),
                                Nombre = rd["Nombre"].ToString(),
                                Edad = Convert.ToInt32(rd["Edad"]),
                                Domicilio = rd["Domicilio"].ToString(),
                                Titulo = rd["Titulo"].ToString(),
                                Especialidad = rd["Especialidad"].ToString(),
                                SueldoBase = Convert.ToInt32(rd["SueldoBase"]),
                                GratTitulo = Convert.ToInt32(rd["GratTitulo"]),
                                SueldoTotal = Convert.ToInt32(rd["SueldoTotal"]),


                            });
                        }
                    }


                }

                mecanico = Lista.Where(item => item.idMecanico == idMecanico).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = mecanico });

            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = mecanico });

            }
        }

        //creo el metodo para crear y guardar el nuevo mecánico

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Mecanico objeto)
        {


            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();

                    //Creo comando de ejecución

                    var cmd = new SqlCommand("mecanico", conexion);

                    //Defino los parametros de entrada

                    cmd.Parameters.AddWithValue("IdMecanico", objeto.idMecanico);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Edad", objeto.Edad);
                    cmd.Parameters.AddWithValue("Domicilio", objeto.Domicilio);
                    cmd.Parameters.AddWithValue("Titulo", objeto.Titulo);
                    cmd.Parameters.AddWithValue("Especialidad", objeto.Especialidad);
                    cmd.Parameters.AddWithValue("SuelsoBase", objeto.SueldoBase);
                    cmd.Parameters.AddWithValue("GratTitulo", objeto.GratTitulo);
                    cmd.Parameters.AddWithValue("SueldoTotal", objeto.SueldoTotal);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }


        //creo el metodo para editar y guardar los cambios realizados al mecanico seleccionado

        [HttpPut]
        [Route("Editar")]

        public IActionResult Editar([FromBody] Mecanico objeto)
        {


            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();

                    //Creo comando de ejecución

                    var cmd = new SqlCommand("mecanico", conexion);

                    //Defino los parametros de entrada

                    cmd.Parameters.AddWithValue("IdMecanico", objeto.idMecanico);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Edad", objeto.Edad);
                    cmd.Parameters.AddWithValue("Domicilio", objeto.Domicilio);
                    cmd.Parameters.AddWithValue("Titulo", objeto.Titulo);
                    cmd.Parameters.AddWithValue("Especialidad", objeto.Especialidad);
                    cmd.Parameters.AddWithValue("SuelsoBase", objeto.SueldoBase);
                    cmd.Parameters.AddWithValue("GratTitulo", objeto.GratTitulo);
                    cmd.Parameters.AddWithValue("SueldoTotal", objeto.SueldoTotal);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Editado" });

            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }


        //creo el metodo para eliminar el mecanico seleccionado

        [HttpDelete]
        [Route("Eliminar/{idMedico:int}")]

        public IActionResult Eliminar(int idMecanico)
        {


            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();

                    var cmd = new SqlCommand("mecanico", conexion);
                    cmd.Parameters.AddWithValue("IdMedico", idMecanico);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });

            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }
    }
}