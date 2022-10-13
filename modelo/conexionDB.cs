using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    internal class conexionDB
    {
        private string cadena = "servel= localhost; database=db_medina; user=root; password=4912";
        public MySqlConnection conectar = new MySqlConnection();


        public void AbrirConexion()
        {
            try
            {
                conectar.ConnectionString = cadena;
                conectar.Open();
                // System.Diagnostics.Debug.WriteLine("Conexion Exitosa");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                // Console.WriteLine(ex.StackTrace);

            }

        }
        public void CerarConexion()
        {

            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }

        }
    }
}

