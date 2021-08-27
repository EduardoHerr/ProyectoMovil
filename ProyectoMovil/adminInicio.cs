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

namespace ProyectoMovil
{
	[Activity(Label = "adminInicio")]
	public class adminInicio : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.adminInicio);
			// Create your application here
			var btnUsuario = FindViewById<Button>(Resource.Id.btnInicioUsuario);
			var btnCategoria = FindViewById<Button>(Resource.Id.btnCategoria);
			var btnProducto = FindViewById<Button>(Resource.Id.btnProductos);
			var btnCliente = FindViewById<Button>(Resource.Id.btnInicioCliente);
			var btnProveedor = FindViewById<Button>(Resource.Id.btnpro );
			btnCliente.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminCliente));
				StartActivity(intent);
			};

			btnUsuario.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminUser));
				StartActivity(intent);
			};
			btnCategoria.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminCategoria));
				StartActivity(intent);
			};
			btnProducto.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminProducto));
				StartActivity(intent);
			};

			btnProveedor.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminProveedor));
				StartActivity(intent);
			};
		}
	}
}