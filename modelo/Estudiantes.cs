using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace modelo
{
    public class Estudiantes{
        conexionDB conectar;

      

        private DataTable Grid_estudiante()
        {
            DataTable tabla = new DataTable();
            conectar = new conexionDB();
            conectar.AbrirConexion();
            string consulta = string.Format("SELECT e.id_estudiante as id,e.carnet,e.nombres,e.apellidos,e.direccion,e.telefono,e.correo_electronico,t.id_tipo_sangre,e.id_tipo_sangre,e.fecha_nacimiento \r\nfrom estudiante as e inner join tipo_sangre as t on e.id_tipo_sangre = t.sangre;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);

            conectar.CerarConexion();

            return tabla;
        }
       
        public void Grid_estudiante(GridView grid)
        {
            grid.DataSource = Grid_estudiante();
            grid.DataBind();
        }

    

        public int crear(string carnet, string nombres, string apellidos, string direccion, string telefono, string correo_electronico, int id_tipo_sangre, string fecha_nacimiento)
        {
            int no_ingreso = 0;
            conectar = new conexionDB();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into estudiante(carnet,nombres,apellidos,direccion,telefono,correo_electronico,id_tipo_sangre,fecha_nacimiento) values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7});", carnet, nombres, apellidos, direccion, telefono, correo_electronico,id_tipo_sangre,fecha_nacimiento);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id, string carnet, string nombres, string apellidos, string direccion, string telefono, string correo_electronico, int id_tipo_sangre, string fecha_nacimiento)
        {
            int no_ingreso = 0;
            conectar = new conexionDB();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update estudiante set carnet = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono='{4}',correo_electronico='{5},id_tipo_sangre='{6}',fecha_nacimiento = {7} where id_estudiante = {8};", carnet, nombres, apellidos, direccion, telefono, correo_electronico, id_tipo_sangre, fecha_nacimiento, id);
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            no_ingreso = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }
        public int eliminar(int id)
        {
            int no_ingreso = 0;
            conectar = new conexionDB();
            conectar.AbrirConexion();
            string strConsulta = string.Format("delete from estudiante  where id_estudiante = {0};", id);
            MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Connection = conectar.conectar;
            no_ingreso = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }

    }



}
}
