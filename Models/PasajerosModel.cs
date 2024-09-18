using EmpresaTrenes.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Models
{
    internal class PasajerosModel
    {
        public int ID_Pasajero { get; set; }
        public string Nombre { get; set; }
        public int ID_Ruta { get; set; }
        public PasajerosModel() { }
        public static List<PasajerosModel> ObtenerTodos()
        {
            var pasajeros = new List<PasajerosModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Pasajeros";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                pasajeros.Add(new PasajerosModel
                                {
                                    ID_Pasajero = Convert.ToInt32(lector["ID_Pasajero"]),
                                    Nombre = lector["Nombre"].ToString(),
                                    ID_Ruta = Convert.ToInt32(lector["ID_Ruta"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al cargar pasajeros: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al cargar pasajeros: {ex.Message}");
            }
            return pasajeros;
        }
        public static PasajerosModel ObtenerPorId(int idPasajero)
        {
            PasajerosModel pasajeroEncontrado = null;
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Pasajeros WHERE ID_Pasajero = @ID_Pasajero";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Pasajero", idPasajero);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                pasajeroEncontrado = new PasajerosModel
                                {
                                    ID_Pasajero = Convert.ToInt32(lector["ID_Pasajero"]),
                                    Nombre = lector["Nombre"].ToString(),
                                    ID_Ruta = Convert.ToInt32(lector["ID_Ruta"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al cargar pasajero: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al cargar pasajero: {ex.Message}");
            }

            if (pasajeroEncontrado == null)
            {
                pasajeroEncontrado = new PasajerosModel { ID_Pasajero = 0, Nombre = "Desconocido", ID_Ruta = 0 };
            }
            return pasajeroEncontrado;
        }
        public static PasajerosModel Insertar(PasajerosModel pasajero)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO Pasajeros (Nombre, ID_Ruta) " +
                                   "OUTPUT INSERTED.ID_Pasajero, INSERTED.Nombre, INSERTED.ID_Ruta " +
                                   "VALUES (@Nombre, @ID_Ruta)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                        comando.Parameters.AddWithValue("@ID_Ruta", pasajero.ID_Ruta);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new PasajerosModel
                                {
                                    ID_Pasajero = Convert.ToInt32(lector["ID_Pasajero"]),
                                    Nombre = lector["Nombre"].ToString(),
                                    ID_Ruta = Convert.ToInt32(lector["ID_Ruta"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar el pasajero: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al insertar el pasajero: {ex.Message}");
            }
            return null;
        }
        public static string Actualizar(PasajerosModel pasajero)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Pasajeros SET Nombre = @Nombre, ID_Ruta = @ID_Ruta WHERE ID_Pasajero = @ID_Pasajero";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Pasajero", pasajero.ID_Pasajero);
                        comando.Parameters.AddWithValue("@Nombre", pasajero.Nombre);
                        comando.Parameters.AddWithValue("@ID_Ruta", pasajero.ID_Ruta);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar el pasajero: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al actualizar el pasajero: {ex.Message}");
                return "Error";
            }
        }
        public static string Eliminar(int idPasajero)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Pasajeros WHERE ID_Pasajero = @ID_Pasajero";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Pasajero", idPasajero);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar el pasajero: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar el pasajero: {ex.Message}");
                return "Error";
            }
        }
    }
}
