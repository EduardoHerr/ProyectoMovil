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
    [Activity(Label = "adminRegistrarCategoria")]
    public class adminCategoria : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminRegistroCategoria);
            var btnRegistarCat = FindViewById<Button>(Resource.Id.btnRegistrarcat);
            var btnModificarCat = FindViewById<Button>(Resource.Id.btnModificarcat);
            var btnEliminarCat = FindViewById<Button>(Resource.Id.btnEliminarcat);
            var btnBuscarCat = FindViewById<Button>(Resource.Id.btnBuscarcat);
            var txtbusqueda = FindViewById<EditText>(Resource.Id.txtBuscarcat);
            var txttipocat = FindViewById<EditText>(Resource.Id.txttipocat);
            var txtdesccat = FindViewById<EditText>(Resource.Id.txtdesccat);

            // Create your application here
        }
    }
}