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
using ProyectoMovil.com.somee.proyectomovil22;

namespace ProyectoMovil
{
	[Activity(Label = "adminUser", MainLauncher = false)]
	public class adminUser : Activity
	{
		static int id = 0;
		connectDB db = new connectDB();
		WebService1 web = new WebService1();
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
			var btnBusqueda = FindViewById<ImageButton>(Resource.Id.imageButton1);
			var busqueda = FindViewById<EditText>(Resource.Id.txtBuscar);
			var btnActualizar = FindViewById<Button>(Resource.Id.btnModificar);
			var spnRol = FindViewById<Spinner>(Resource.Id.spinner1);
			var btnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);

			roles.Add("--SELECCIONE--");//0
			roles.Add("Administrador");//1
			roles.Add("Usuario");//2
			
			var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, roles);
			spnRol.Adapter = adapter;

			btnActualizar.Click += delegate
			{
				if (spnRol.SelectedItem.ToString() == "Administrador")
				{
					
					web.actualizarCliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtClave.Text, 'A',id);
					limpiar();
					Toast.MakeText(this, "Registro Actualizado", ToastLength.Short).Show();

				}
				else if (spnRol.SelectedItem.ToString() == "Usuario")
				{
					web.actualizarCliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtClave.Text, 'U', id);
					limpiar();
					Toast.MakeText(this, "Registro Actualizado", ToastLength.Short).Show();
				}
				else
				{
					Toast.MakeText(this, "Seleccione un rol", ToastLength.Short).Show();
				}
			};

			btnRegistarUsuario.Click += delegate
			{
				if (spnRol.SelectedItem.ToString() == "Administrador")
				{

					web.RegistrarUsuario(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtClave.Text, 'A');
					limpiar();
					Toast.MakeText(this, "Registro Guardado", ToastLength.Short).Show();

				}
				else if (spnRol.SelectedItem.ToString() == "Usuario")
				{
					web.RegistrarUsuario(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtClave.Text, 'U');
					limpiar();
					Toast.MakeText(this, "Registro Guardado", ToastLength.Short).Show();
				}
				else
				{
					Toast.MakeText(this, "Seleccione un rol", ToastLength.Short).Show();
				}
			};

			btnEliminar.Click += delegate
			{
				if (id==0)
				{
					Toast.MakeText(this, "Ningun dato seleccionado", ToastLength.Short).Show();
				}
				else
				{
					web.eliminarUsuario(id);
					Toast.MakeText(this, "Usuario Eliminado", ToastLength.Short).Show();
					limpiar();
				}
			};

			btnBusqueda.Click += delegate
			{
				DataSet ds = web.cargarDatosUsuario(busqueda.Text);

				
				txtNombre.Text = ds.Tables[0].Rows[0]["USUNOMBRE"].ToString();
				txtApellido.Text = ds.Tables[0].Rows[0]["USUAPELLIDO"].ToString();
				txtCedula.Text = ds.Tables[0].Rows[0]["USUCEDULA"].ToString();
				txtCorreo.Text = ds.Tables[0].Rows[0]["USUUSUARIO"].ToString();
				txtClave.Text = ds.Tables[0].Rows[0]["USUCLAVE"].ToString();
				id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDUSUARIO"].ToString());
				
				//Aqui traigo los datos xd
				if (ds.Tables[0].Rows[0]["USUROL"].ToString()=="A")
				{
					spnRol.SetSelection(1);
				}
				else
				{
					spnRol.SetSelection(2);
				}

				busqueda.Text = "";


			};

			void limpiar()
			{
				txtNombre.Text = txtApellido.Text = txtCedula.Text = txtClave.Text = txtCorreo.Text = "";
				spnRol.SetSelection(0);
			}


		}
	}
}