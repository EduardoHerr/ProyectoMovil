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
    [Activity(Label = "adminRegistrarProducto")]
    public class adminProducto : Activity
    {
        static int id = 0;
        connectDB db = new connectDB();
        WebService1 web = new WebService1();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminRegistroProducto);

            var btnRegistarpro = FindViewById<Button>(Resource.Id.btnRegistrarpro);
            var btnModificarpro = FindViewById<Button>(Resource.Id.btnModificarpro);
            var btnEliminarpro = FindViewById<Button>(Resource.Id.btnEliminarpro);
            var btnBuscarc = FindViewById<Button>(Resource.Id.btnbuscarpro);
            var txtbusqueda = FindViewById<EditText>(Resource.Id.txtBuscarpro);
            var txtcategoriapro = FindViewById<EditText>(Resource.Id.txtcategoriacatpro);
            var txtcodigopro = FindViewById<EditText>(Resource.Id.txtcodigopro);
            var txtnombrepro = FindViewById<EditText>(Resource.Id.txtnombrepro);
            var txtdescpro = FindViewById<EditText>(Resource.Id.txtdescripcionpro);
            var txtfechaeliapro = FindViewById<EditText>(Resource.Id.txtfechaelpro);
            var txtfechaexpro = FindViewById<EditText>(Resource.Id.txtfechaexpro);
            var txtcantidadpro = FindViewById<EditText>(Resource.Id.txtcantidadpro);

            // Create your application here


            btnModificarpro.Click += delegate
            {
                string estado = null;
                web.modificarProducto(txtcategoriapro.Text, txtcodigopro.Text, 
                    txtnombrepro.Text, txtdescpro.Text,txtfechaeliapro.Text, txtfechaexpro.Text,txtcantidadpro.Text,estado ,id);
                limpiar();
                Toast.MakeText(this, "Registro Actualizado", ToastLength.Short).Show();
            };

            btnEliminarpro.Click += delegate {
                if (id == 0)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();
                }
                else
                {
                    web.eliminarProducto(id);
                    limpiar();
                    Toast.MakeText(this, "Registro Eliminado", ToastLength.Short).Show();
                }

            };


            btnRegistarpro.Click += delegate
            {
                web.registrarProducto(txtcategoriapro.Text,
                    txtcodigopro.Text,txtnombrepro.Text, txtdescpro.Text,txtfechaeliapro.Text,txtfechaexpro.Text,txtcantidadpro.Text);
                limpiar();
                Toast.MakeText(this, "Registro Creado", ToastLength.Short).Show();
            };

            btnBuscarc.Click += delegate
            {
                try
                {
                    DataSet ds = web.cargarDatosProducto(txtbusqueda.Text);
                    txtcategoriapro.Text = ds.Tables[0].Rows[0]["CATTIPO"].ToString();
                    txtcodigopro.Text = ds.Tables[0].Rows[0]["PRODCODIGO"].ToString();
                    txtnombrepro.Text = ds.Tables[0].Rows[0]["PRODNOMBRE"].ToString();
                    txtdescpro.Text = ds.Tables[0].Rows[0]["PRODDESC"].ToString();
                    txtfechaeliapro.Text = ds.Tables[0].Rows[0]["PRODFRECHAELAB"].ToString();
                    txtfechaexpro.Text = ds.Tables[0].Rows[0]["PRODFECHAEXP"].ToString();
                    txtcantidadpro.Text = ds.Tables[0].Rows[0]["PRODCANTIDAD"].ToString();
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDCATEGORIAPRODUCTO"].ToString());
                }
                catch (Exception)
                {

                    throw;
                }

            };



            void limpiar()
            {
                txtcodigopro.Text= txtcategoriapro.Text= txtnombrepro.Text
                    = txtdescpro.Text = txtfechaexpro.Text = txtfechaeliapro.Text = txtcantidadpro.Text = "";
                id = 0;
            }
        }
    }
}