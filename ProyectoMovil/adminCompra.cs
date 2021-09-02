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
    [Activity(Label = "Compra")]
    public class adminCompra : Activity
    {
        static int id = 0;
        static int cantidad = 0;
        connectDB db = new connectDB();
        WebService1 web = new WebService1();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminRegistroCompra);
            var btnRegistarcompra = FindViewById<Button>(Resource.Id.btnRegistrarCompra);
            var btnCalcularcompra = FindViewById<Button>(Resource.Id.btnCalcularCompra);
            var btnEliminarcompra = FindViewById<Button>(Resource.Id.btnEliminarCompra);
            var btnBuscarcopra = FindViewById<Button>(Resource.Id.btnbuscarCompra);
            var txtbusqueda = FindViewById<EditText>(Resource.Id.txtBuscarCompra);
            //
            var txtidproductocompra = FindViewById<EditText>(Resource.Id.txtprocompra);
            var txtidprovcompra = FindViewById<EditText>(Resource.Id.txtprovcompra);
            var txtcodigocompra = FindViewById<EditText>(Resource.Id.txtcodigocompra);
            var txtcantidadcompra = FindViewById<EditText>(Resource.Id.txtcantidadcompra);
            var txtcostocompra = FindViewById<EditText>(Resource.Id.txttotalcompra);
            var txtfechacompra = FindViewById<EditText>(Resource.Id.txtfechacompra);

            // Create your application here
            btnBuscarcopra.Click += delegate
            {
                try
                {
                    DataSet ds = web.verCompra(Convert.ToInt32(txtbusqueda.Text));

                    txtidproductocompra.Text = ds.Tables[0].Rows[0]["PRODNOMBRE"].ToString();
                    txtidprovcompra.Text = ds.Tables[0].Rows[0]["PROVNOMBRE"].ToString();
                    txtcodigocompra.Text = ds.Tables[0].Rows[0]["COMCODIGO"].ToString();
                    txtcantidadcompra.Text = ds.Tables[0].Rows[0]["COMCANTIDAD"].ToString();
                    txtcostocompra.Text = ds.Tables[0].Rows[0]["COMCOSTOCOMPRA"].ToString();
                    txtfechacompra.Text = ds.Tables[0].Rows[0]["COMFECHA"].ToString();
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDCOMPRA"].ToString());
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();

                }

            };

            btnEliminarcompra.Click += delegate
            {
                if (id == 0)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();
                }
                else
                {
                    web.eliminarCompra(id);
                    limpiar();
                    Toast.MakeText(this, "Registro Eliminado", ToastLength.Short).Show();
                }

            };

            btnCalcularcompra.Click += delegate
            {
            };

            btnRegistarcompra.Click += delegate
            {
                web.registrarCompra(
                txtidprovcompra.Text, txtidproductocompra.Text, txtcodigocompra.Text, Convert.ToInt32(txtcantidadcompra.Text), Convert.ToDouble(txtcostocompra.Text), txtfechacompra.Text);


                web.AumentarProducto(Convert.ToInt32(txtcantidadcompra.Text), Convert.ToInt32(txtidproductocompra.Text));

                Toast.MakeText(this, "Registro Creado", ToastLength.Short).Show();
                limpiar();
            };

            void limpiar()
            {
                txtidprovcompra.Text = txtidproductocompra.Text = txtbusqueda.Text = txtcantidadcompra.Text = txtcodigocompra.Text = txtcostocompra.Text = txtfechacompra.Text = "";
                id = 0;
            }
        }
    }
}