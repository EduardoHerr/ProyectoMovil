using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProyectoMovil.com.somee.proyectomovil22;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProyectoMovil
{
    [Activity(Label = "adminRegistrarCategoria")]
    public class adminCategoria : Activity
    {
        static int id = 0;
        connectDB db = new connectDB();
        WebService1 web = new WebService1();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminRegistroCategoria);


            // Create your application here
            var btnRegistarCat = FindViewById<Button>(Resource.Id.btnRegistrarcat);
            var btnModificarCat = FindViewById<Button>(Resource.Id.btnModificarcat);
            var btnEliminarCat = FindViewById<Button>(Resource.Id.btnEliminarcat);
            var btnBuscarc = FindViewById<Button>(Resource.Id.btnbuscarcat);
            var txtbusqueda = FindViewById<EditText>(Resource.Id.txtBuscarcat);
            var txttipocat = FindViewById<EditText>(Resource.Id.txttipocat);
            var txtdesccat = FindViewById<EditText>(Resource.Id.txtdesccat);


            btnModificarCat.Click += delegate
            {

                web.actualizarCategoria(txttipocat.Text, txtdesccat.Text, id);
                limpiar();
                Toast.MakeText(this, "Registro Actualizado", ToastLength.Short).Show();
            };

            btnEliminarCat.Click += delegate {
                if (id == 0)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();
                }
                else
                {
                    web.eliminarCategoria(id);
                    limpiar();
                    Toast.MakeText(this, "Registro Eliminado", ToastLength.Short).Show();
                }

            };


            btnRegistarCat.Click += delegate
            {
                web.registrarCategoria(txttipocat.Text, txtdesccat.Text);
                limpiar();
                Toast.MakeText(this, "Registro Creado", ToastLength.Short).Show();
            };

            btnBuscarc.Click += delegate
            {
                try
                {
                    DataSet ds = web.cargarDatosCategoria(txtbusqueda.Text);
                    txttipocat.Text = ds.Tables[0].Rows[0]["CATTIPO"].ToString();
                    txtdesccat.Text = ds.Tables[0].Rows[0]["CATDESCRIPCION"].ToString();
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDCATEGORIAPRODUCTO"].ToString());
                }
                catch (Exception)
                {

                    throw;
                }

            };



            void limpiar()
            {
                txttipocat.Text = txtdesccat.Text = "";
                id = 0;
            }
        
        }
    }
}