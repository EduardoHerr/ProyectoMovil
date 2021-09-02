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
			var btnProveedor = FindViewById<Button>(Resource.Id.btnCategoria);
			var btnProducto = FindViewById<Button>(Resource.Id.btnProductos);
			var btnCliente = FindViewById<Button>(Resource.Id.btnInicioCliente);
			var btnVenta = FindViewById<Button>(Resource.Id.btnpro );
			var btnCompra = FindViewById<Button>(Resource.Id.btncompra);
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
			btnProveedor.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminProveedor));
				StartActivity(intent);
			};
			btnProducto.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminProducto));
				StartActivity(intent);
			};

			btnVenta.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminVenta));
				StartActivity(intent);
			};

			btnCompra.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminCompra));
				StartActivity(intent);
			};
		}
	}
}