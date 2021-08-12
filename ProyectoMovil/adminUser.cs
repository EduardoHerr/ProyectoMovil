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
using System.Data;
namespace ProyectoMovil
{
	[Activity(Label = "adminUser", MainLauncher = true)]
	public class adminUser : Activity
	{
		connectDB db = new connectDB();
		List<string> roles = new List<string>();
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.adminRegistroUsuarios);
			// Create your application here
			var btnRegistarUsuario = FindViewById<Button>(Resource.Id.btnRegistrar);
			var txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
			var txtApellido = FindViewById<EditText>(Resource.Id.txtApellido);
			var txtCedula = FindViewById<EditText>(Resource.Id.txtCedula);
			var txtCorreo = FindViewById<EditText>(Resource.Id.txtCorreo);
			var txtClave = FindViewById<EditText>(Resource.Id.txtPass);
			var btnBusqueda = FindViewById<Button>(Resource.Id.button1);
			var busqueda = FindViewById<EditText>(Resource.Id.txtBuscar);

			var spnRol = FindViewById<Spinner>(Resource.Id.spinner1);

			roles.Add("Administrador");
			roles.Add("Usuario");
			
			var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, roles);
			spnRol.Adapter = adapter;

			btnRegistarUsuario.Click += delegate
			{
				if (spnRol.SelectedItem.ToString() == "Administrador")
				{

					db.RegistrarUsuario(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtClave.Text, 'A');
					limpiar();

				}
				else
				{
					db.RegistrarUsuario(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtClave.Text, 'U');
					limpiar();
				}
			};

			btnBusqueda.Click += delegate
			{
				DataSet ds = db.cargarDatosUsuario(busqueda.Text);

				
				txtNombre.Text = ds.Tables[0].Rows[0]["USUNOMBRE"].ToString();
				txtApellido.Text = ds.Tables[0].Rows[0]["USUAPELLIDO"].ToString();
				txtCedula.Text = ds.Tables[0].Rows[0]["USUCEDULA"].ToString();
				txtCorreo.Text = ds.Tables[0].Rows[0]["USUUSUARIO"].ToString();
				txtClave.Text = ds.Tables[0].Rows[0]["USUCLAVE"].ToString();
				if (ds.Tables[0].Rows[0]["USUROL"].ToString()=="A")
				{
					spnRol.SetSelection(0);
				}
				else
				{
					spnRol.SetSelection(1);
				}

				busqueda.Text = "";


			};

			void limpiar()
			{
				txtNombre.Text = txtApellido.Text = txtCedula.Text = txtClave.Text = txtCorreo.Text = "";
			}
		}
	}
}