﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTrenes.Config
{
    internal class Conexion
    {
        private static readonly string connectionString;

        static Conexion()
        {
            connectionString = "Server=CRISTHIANPINOS;Database=SistemaTrenes;User Id=sa;Password=123;";
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                throw;
            }
        }
    }
}
