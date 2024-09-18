using EmpresaTrenes.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Models
{
    internal class TrenesModel
    {
        public int ID_Tren { get; set; }
        public string Modelo { get; set; }
        public TrenesModel() { }
        public static List<TrenesModel> ObtenerTodos()
        {
            var trenes = new List<TrenesModel>();
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Trenes";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                trenes.Add(new TrenesModel
                                {
                                    ID_Tren = Convert.ToInt32(lector["ID_Tren"]),
                                    Modelo = lector["Modelo"].ToString()
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
            return trenes;
        }
        public static TrenesModel ObtenerPorId(int idTren)
        {
            TrenesModel trenEncontrado = null;
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM Trenes WHERE ID_Tren = @ID_Tren";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Tren", idTren);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                trenEncontrado = new TrenesModel
                                {
                                    ID_Tren = Convert.ToInt32(lector["ID_Tren"]),
                                    Modelo = lector["Modelo"].ToString(),
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

            if (trenEncontrado == null)
            {
                trenEncontrado = new TrenesModel { ID_Tren = 0, Modelo = "Desconocido" };
            }
            return trenEncontrado;
        }
        public static TrenesModel Insertar(TrenesModel tren)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO Trenes (Modelo) " +
                                   "OUTPUT INSERTED.ID_Tren, INSERTED.Modelo " +
                                   "VALUES (@Modelo)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Modelo", tren.Modelo);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new TrenesModel
                                {
                                    ID_Tren = Convert.ToInt32(lector["ID_Tren"]),
                                    Modelo = lector["Modelo"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar el tren: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al insertar el tren: {ex.Message}");
            }
            return null;
        }
        public static string Actualizar(TrenesModel tren)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE Trenes SET Modelo = @Modelo WHERE ID_Tren = @ID_Tren";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Tren", tren.ID_Tren);
                        comando.Parameters.AddWithValue("@Modelo", tren.Modelo);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar el tren: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al actualizar el tren: {ex.Message}");
                return "Error";
            }
        }
        public static string Eliminar(int idTren)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM Trenes WHERE ID_Tren = @ID_Tren";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_Tren", idTren);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar el tren: {ex.Message}");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al eliminar el tren: {ex.Message}");
                return "Error";
            }
        }
    }
}

