using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaTrenes.Config;
using System.Data.SqlClient;

namespace EmpresaTrenes.Models
{
    internal class RutasModel
    {
        public int ID_Ruta { get; set; }
        public int ID_Tren { get; set; }
        public int ID_Estacion_Origen { get; set; }
        public int ID_Estacion_Destino { get; set; }
        public DateTime Fecha { get; set; }
        public RutasModel() { }
        public static List<RutasModel> ObtenerTodas()
        {
            var rutas = new List<RutasModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Rutas";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                rutas.Add(new RutasModel
                                {
                                    ID_Ruta = Convert.ToInt32(lector["ID_Ruta"]),
                                    ID_Tren = Convert.ToInt32(lector["ID_Tren"]),
                                    ID_Estacion_Origen = Convert.ToInt32(lector["ID_Estacion_Origen"]),
                                    ID_Estacion_Destino = Convert.ToInt32(lector["ID_Estacion_Destino"]),
                                    Fecha = Convert.ToDateTime(lector["Fecha"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al cargar rutas: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al cargar rutas: {ex.Message}");
            }
            return rutas;
        }
        public static RutasModel ObtenerPorId(int idRuta)
        {
            RutasModel rutaEncontrada = null;
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Rutas WHERE ID_Ruta = @ID_Ruta";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Ruta", idRuta);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                rutaEncontrada = new RutasModel
                                {
                                    ID_Ruta = Convert.ToInt32(lector["ID_Ruta"]),
                                    ID_Tren = Convert.ToInt32(lector["ID_Tren"]),
                                    ID_Estacion_Origen = Convert.ToInt32(lector["ID_Estacion_Origen"]),
                                    ID_Estacion_Destino = Convert.ToInt32(lector["ID_Estacion_Destino"]),
                                    Fecha = Convert.ToDateTime(lector["Fecha"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al cargar la ruta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al cargar la ruta: {ex.Message}");
            }

            if (rutaEncontrada == null)
            {
                rutaEncontrada = new RutasModel { ID_Ruta = 0 };
            }
            return rutaEncontrada;
        }
        public static RutasModel Insertar(RutasModel ruta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO Rutas (ID_Tren, ID_Estacion_Origen, ID_Estacion_Destino, Fecha) " +
                                   "OUTPUT INSERTED.ID_Ruta, INSERTED.ID_Tren, INSERTED.ID_Estacion_Origen, INSERTED.ID_Estacion_Destino, INSERTED.Fecha " +
                                   "VALUES (@ID_Tren, @ID_Estacion_Origen, @ID_Estacion_Destino, @Fecha)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Tren", ruta.ID_Tren);
                        comando.Parameters.AddWithValue("@ID_Estacion_Origen", ruta.ID_Estacion_Origen);
                        comando.Parameters.AddWithValue("@ID_Estacion_Destino", ruta.ID_Estacion_Destino);
                        comando.Parameters.AddWithValue("@Fecha", ruta.Fecha);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new RutasModel
                                {
                                    ID_Ruta = Convert.ToInt32(lector["ID_Ruta"]),
                                    ID_Tren = Convert.ToInt32(lector["ID_Tren"]),
                                    ID_Estacion_Origen = Convert.ToInt32(lector["ID_Estacion_Origen"]),
                                    ID_Estacion_Destino = Convert.ToInt32(lector["ID_Estacion_Destino"]),
                                    Fecha = Convert.ToDateTime(lector["Fecha"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar la ruta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al insertar la ruta: {ex.Message}");
            }
            return null;
        }
        public static string Actualizar(RutasModel ruta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Rutas SET ID_Tren = @ID_Tren, ID_Estacion_Origen = @ID_Estacion_Origen, " +
                                   "ID_Estacion_Destino = @ID_Estacion_Destino, Fecha = @Fecha WHERE ID_Ruta = @ID_Ruta";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Ruta", ruta.ID_Ruta);
                        comando.Parameters.AddWithValue("@ID_Tren", ruta.ID_Tren);
                        comando.Parameters.AddWithValue("@ID_Estacion_Origen", ruta.ID_Estacion_Origen);
                        comando.Parameters.AddWithValue("@ID_Estacion_Destino", ruta.ID_Estacion_Destino);
                        comando.Parameters.AddWithValue("@Fecha", ruta.Fecha);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar la ruta: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al actualizar la ruta: {ex.Message}");
                return "Error";
            }
        }
        public static string Eliminar(int idRuta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Rutas WHERE ID_Ruta = @ID_Ruta";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar la ruta: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar la ruta: {ex.Message}");
                return "Error";
            }
        }
    }
}
