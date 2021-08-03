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

			btnUsuario.Click += delegate
			{
				Intent intent = new Intent(this, typeof(adminUser));
				StartActivity(intent);
			};
		}
	}
}