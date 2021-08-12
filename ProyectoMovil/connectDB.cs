using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoMovil
{
	class connectDB
	{
		static string url = "workstation id=PrototipoMovil.mssql.somee.com;packet size=4096;user id=DLPN_SQLLogin_1;pwd=zw4fssu4d4;data source=PrototipoMovil.mssql.somee.com;persist security info=False;initial catalog=PrototipoMovil";

		SqlConnection con = new SqlConnection(url);
		int rol = 0;

		public int Ingresar(string user, string pwd)
		{
			string query = "SELECT * FROM TBLUSUARIO WHERE USUUSUARIO = '" + user + "' AND USUCLAVE='" + pwd + "';";
			con.Open();

			SqlCommand cmd = new SqlCommand(query, con);
			SqlDataReader rs = cmd.ExecuteReader();

			while (rs.Read())
			{
				if (rs["USUUSUARIO"].ToString().Equals(user) && rs["USUCLAVE"].ToString().Equals(pwd) )
				{
					if (rs["USUESTADO"].ToString().Equals("A"))
					{
						if (rs["USUROL"].ToString().Equals("A"))
						{
							rol = 1;
						}
						else
						{
							rol = 2;
						}
					}
					else
					{
						rol = 0;
					}

				}
				else
				{
					rol = 0;
				}
			}

			rs.Close();
			con.Close();

			return rol;
		}

		#region Usuario

		public void RegistrarUsuario(string nombre,string apellido,string cedula,string correo,string clave,char rol)
		{
			try
			{
				string query = "INSERT INTO TBLUSUARIO VALUES(@nombre,@apellido,@cedula,@correo,@clave,@rol,'A')";
				con.Open();
				SqlCommand cmd = new SqlCommand(query, con);

				cmd.Parameters.AddWithValue("@nombre", nombre);
				cmd.Parameters.AddWithValue("@apellido", apellido);
				cmd.Parameters.AddWithValue("@cedula", cedula);
				cmd.Parameters.AddWithValue("@correo", correo);
				cmd.Parameters.AddWithValue("@clave", clave);
				cmd.Parameters.AddWithValue("@rol", rol);

				cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{

				throw;
			}

			con.Close();
		}

		public void actualizarCliente(string nombre, string apellido, string cedula, string correo, string clave, char rol,int id)
		{
			try
			{
				string query = "UPDATE TBLUSUARIO SET USUNOMBRE=@nombre,USUAPELLIDO=@apellido,USUCEDULA=@cedula,USUUSUARIO=@correo,USUCLAVE=@clave,USUROL=@rol WHERE IDUSUARIO=@id";
				con.Open();
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@nombre", nombre);
				cmd.Parameters.AddWithValue("@apellido", apellido);
				cmd.Parameters.AddWithValue("@cedula", cedula);
				cmd.Parameters.AddWithValue("@correo", correo);
				cmd.Parameters.AddWithValue("@clave", clave);
				cmd.Parameters.AddWithValue("@rol", rol);
				cmd.Parameters.AddWithValue("@id", id);

				cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{

				throw;
			}

			con.Close();

		}

		public void eliminarUsuario(int id)
		{
			try
			{
				string query = "UPDATE TBLUSUARIO SET USUESTADO='I' WHERE IDUSUARIO=@id";
				con.Open();
				SqlCommand cmd = new SqlCommand(query,con);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{

				throw;
			}
			con.Close();
		}


		public DataSet cargarDatosUsuario(string ci)
		{
			
			con.Open();
			string query = "SELECT * FROM TBLUSUARIO WHERE USUCEDULA='"+ci+"'";
			

			
			SqlDataAdapter sda = new SqlDataAdapter(query,con);
			DataSet ds = new DataSet();

			sda.Fill(ds);

			con.Close();

			return ds;
		}

		#endregion

	}
}