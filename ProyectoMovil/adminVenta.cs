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
    [Activity(Label = "adminVenta")]
    public class adminVenta : Activity
    {
        static int id = 0;
        static int cantidad = 0;
        connectDB db = new connectDB();
        WebService1 web = new WebService1();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminRegistroVenta);
            var btnRegistarventa = FindViewById<Button>(Resource.Id.btnRegistrarVenta);
            //var btnCalcularventa = FindViewById<Button>(Resource.Id.btnCalcularVenta);
            var btnEliminarventa = FindViewById<Button>(Resource.Id.btnEliminarVenta);
            var btnBuscarventa = FindViewById<Button>(Resource.Id.btnbuscarVenta);
            var txtbusqueda = FindViewById<EditText>(Resource.Id.txtBuscarVenta);
            //
            var txtidproductoventa = FindViewById<EditText>(Resource.Id.txtproVenta);
            var txtidclienteventa = FindViewById<EditText>(Resource.Id.txtcliVenta);
            var txtcodigoventa = FindViewById<EditText>(Resource.Id.txtcodigoVenta);
            var txtcantidadventa = FindViewById<EditText>(Resource.Id.txtcantidadVenta);
            var txtcostoventa = FindViewById<EditText>(Resource.Id.txttotalVenta);
           // var txtcostventa = FindViewById<EditText>(Resource.Id.txtcostoventa);
            var txtfechaventa = FindViewById<EditText>(Resource.Id.txtfechaVenta);

            // Create your application here

            btnBuscarventa.Click += delegate 
            {
                try
                {
                    DataSet ds = web.verVenta(Convert.ToInt32( txtbusqueda.Text));

                    txtidproductoventa.Text = ds.Tables[0].Rows[0]["PRODNOMBRE"].ToString();
                    txtidclienteventa.Text = ds.Tables[0].Rows[0]["CLINOMBRE"].ToString();
                    txtcodigoventa.Text = ds.Tables[0].Rows[0]["VNTCODIGO"].ToString();
                    txtcantidadventa.Text = ds.Tables[0].Rows[0]["VNTCANTIDAD"].ToString();
                    txtcostoventa.Text = ds.Tables[0].Rows[0]["VNTCOSTOVENTA"].ToString();
                    txtfechaventa.Text = ds.Tables[0].Rows[0]["VNTFECHA"].ToString();
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDVENTA"].ToString());
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();

                }

            };

            btnEliminarventa.Click += delegate 
            {
                if (id == 0)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();
                }
                else
                {
                    web.eliminarventa(id);
                    limpiar();
                    Toast.MakeText(this, "Registro Eliminado", ToastLength.Short).Show();
                }

            };
            
           

            btnRegistarventa.Click += delegate
            {
                web.registrarVenta(
                txtidproductoventa.Text, txtidclienteventa.Text, txtcodigoventa.Text,Convert.ToInt32(txtcantidadventa.Text), Convert.ToDouble(txtcostoventa.Text), txtfechaventa.Text);
                
                Toast.MakeText(this, "Registro Creado", ToastLength.Short).Show();

               web.RestarProducto(Convert.ToDouble(txtcantidadventa.Text), Convert.ToInt32(txtidproductoventa.Text));
                limpiar();
            };

             void limpiar()
            {
                txtidclienteventa.Text = txtidproductoventa.Text = txtbusqueda.Text = txtcantidadventa.Text = txtcodigoventa.Text = txtcostoventa.Text = txtfechaventa.Text = "";
                id = 0;
            }
        }
       
    }
}