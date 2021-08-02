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


	}
}