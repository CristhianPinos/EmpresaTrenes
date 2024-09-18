using EmpresaTrenes.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Models
{
    internal class EstacionesModel
    {
        public int ID_Estacion { get; set; }
        public string Ciudad { get; set; }
        public static List<EstacionesModel> ObtenerTodos()
        {
            var estaciones = new List<EstacionesModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Estaciones";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                estaciones.Add(new EstacionesModel
                                {
                                    ID_Estacion = Convert.ToInt32(lector["ID_Estacion"]),
                                    Ciudad = lector["Ciudad"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al cargar: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al cargar: {ex.Message}");
            }
            return estaciones;
        }
        public static EstacionesModel ObtenerPorId(int idEstacion)
        {
            EstacionesModel estacionEncontrada = null;
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Estaciones WHERE ID_Estacion = @ID_Estacion";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Estacion", idEstacion);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                estacionEncontrada = new EstacionesModel
                                {
                                    ID_Estacion = Convert.ToInt32(lector["ID_Estacion"]),
                                    Ciudad = lector["Ciudad"].ToString(),
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al cargar id: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al cargar id: {ex.Message}");
            }

            if (estacionEncontrada == null)
            {
                estacionEncontrada = new EstacionesModel { ID_Estacion = 0, Ciudad = "Desconocido" };
            }
            return estacionEncontrada;
        }
        public static EstacionesModel Insertar(EstacionesModel estacion)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO Estaciones (Ciudad) " +
                                   "OUTPUT INSERTED.ID_Estacion, INSERTED.Ciudad " +
                                   "VALUES (@Ciudad)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Ciudad", estacion.Ciudad);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new EstacionesModel
                                {
                                    ID_Estacion = Convert.ToInt32(lector["ID_Estacion"]),
                                    Ciudad = lector["Ciudad"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar la estacion: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al insertar la estacion: {ex.Message}");
            }
            return null;
        }
        public static string Actualizar(EstacionesModel estacion)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Estaciones SET Ciudad = @Ciudad WHERE ID_Estacion = @ID_Estacion";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Estacion", estacion.ID_Estacion);
                        comando.Parameters.AddWithValue("@Ciudad", estacion.Ciudad);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar la estacion: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al actualizar la estacion: {ex.Message}");
                return "Error";
            }
        }
        public static string Eliminar(int idEstacion)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Estaciones WHERE ID_Estacion = @ID_Estacion";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Estacion", idEstacion);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar la estacion: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar la estacion: {ex.Message}");
                return "Error";
            }
        }
    }
}
