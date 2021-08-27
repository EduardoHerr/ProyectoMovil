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
    [Activity(Label = "adminProveedor")]
    public class adminProveedor : Activity
    {
        static int id = 0;
        connectDB db = new connectDB();
        WebService1 web = new WebService1();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminRegistroProveedor);

            var btnRegistarprov = FindViewById<Button>(Resource.Id.btnRegistrarprov);
            var btnModificarprov = FindViewById<Button>(Resource.Id.btnModificarprov);
            var btnEliminarprov = FindViewById<Button>(Resource.Id.btnEliminarprov);
            var btnBuscarprov = FindViewById<Button>(Resource.Id.btnbuscarprov);
            var txtbusqueda = FindViewById<EditText>(Resource.Id.txtBuscarprov);
            var txtnombre = FindViewById<EditText>(Resource.Id.txtnombreprov);
            var txtruc = FindViewById<EditText>(Resource.Id.txtrucprov);
            var txtdireccion = FindViewById<EditText>(Resource.Id.txtdireccionprov);
            var txttelefono= FindViewById<EditText>(Resource.Id.txttelefonoprov);
            var txtcorreo = FindViewById<EditText>(Resource.Id.txtcorreoprov);


            // Create your application here
            btnModificarprov.Click += delegate
            {

                web.actualizarProveedor(txtnombre.Text, txtruc.Text,
                    txtdireccion.Text, txttelefono.Text, txtcorreo.Text,  id);
                limpiar();
                Toast.MakeText(this, "Registro Actualizado", ToastLength.Short).Show();
            };

            btnEliminarprov.Click += delegate {
                if (id == 0)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();
                }
                else
                {
                    web.eliminarProveedor(id);
                    limpiar();
                    Toast.MakeText(this, "Registro Eliminado", ToastLength.Short).Show();
                }

            };

            btnRegistarprov.Click += delegate
            {
                web.registrarProveedor(txtnombre.Text,
                    txtruc.Text, txtdireccion.Text, txttelefono.Text, txtcorreo.Text);
                limpiar();
                Toast.MakeText(this, "Registro Creado", ToastLength.Short).Show();
            };

            btnBuscarprov.Click += delegate
            {
                try
                {
                    DataSet ds = web.cargarDatosProveedor(txtbusqueda.Text);
                    txtnombre.Text = ds.Tables[0].Rows[0]["PROVNOMBRE"].ToString();
                    txtruc.Text = ds.Tables[0].Rows[0]["PROVRUC"].ToString();
                    txtdireccion.Text = ds.Tables[0].Rows[0]["PROVDIRECCION"].ToString();
                    txttelefono.Text = ds.Tables[0].Rows[0]["PROVTELEFONO"].ToString();
                    txtcorreo.Text = ds.Tables[0].Rows[0]["PROVCORREO"].ToString();
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDPROVEEDOR"].ToString());
                }
                catch (Exception)
                {

                    throw;
                }

            };


            void limpiar()
            {
                txtnombre.Text = txtruc.Text = txtdireccion.Text
                    = txttelefono.Text = txtcorreo.Text =  "";
                id = 0;
            }

        }
    }
}