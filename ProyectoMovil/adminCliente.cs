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
    [Activity(Label = "adminCliente")]
    public class adminCliente : Activity
    {
        static int id = 0;
        connectDB db = new connectDB();
        WebService1 web = new WebService1();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminCliente);

            var nombrec = FindViewById<EditText>(Resource.Id.txtNomCli);
            var apellidoc = FindViewById<EditText>(Resource.Id.txtApeCli);
            var cedulac = FindViewById<EditText>(Resource.Id.txtCedCli);
            var direc = FindViewById<EditText>(Resource.Id.txtDirCli);
            var telfc= FindViewById<EditText>(Resource.Id.txtTelfCli);
            var btnRegistroc = FindViewById<Button>(Resource.Id.btnRegistrarCli);
            var btnModificacionc = FindViewById<Button>(Resource.Id.button1);
            var btnEliminacionc = FindViewById<Button>(Resource.Id.button2);
            var btnBuscarc = FindViewById<Button>(Resource.Id.btnBuscarcli);
            var busqueda = FindViewById<EditText>(Resource.Id.edit1);

            // Create your application here

            btnModificacionc.Click += delegate
            {
                
                web.modificarCliente(nombrec.Text, apellidoc.Text, cedulac.Text, direc.Text, telfc.Text, id);
                limpiar();
                Toast.MakeText(this, "Registro Actualizado", ToastLength.Short).Show();
            };

            btnEliminacionc.Click += delegate {
                if (id==0)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();
                }
                else
                {
                    web.eliminarCliente(id);
                    limpiar();
                    Toast.MakeText(this, "Registro Eliminado", ToastLength.Short).Show();
                }
                
            };

            btnRegistroc.Click += delegate
            {
                web.RegistrarCliente(nombrec.Text, apellidoc.Text, cedulac.Text, direc.Text, telfc.Text);
                limpiar();
                Toast.MakeText(this, "Registro Creado", ToastLength.Short).Show();
            };

            btnBuscarc.Click += delegate
            {
                try
                {
                    DataSet ds = web.cargarDatosCliente(busqueda.Text);
                    nombrec.Text = ds.Tables[0].Rows[0]["CLINOMBRE"].ToString();
                    apellidoc.Text = ds.Tables[0].Rows[0]["CLIAPELLIDO"].ToString();
                    cedulac.Text = ds.Tables[0].Rows[0]["CLICEDULA"].ToString();
                    direc.Text = ds.Tables[0].Rows[0]["CLIDIRECCION"].ToString();
                    telfc.Text = ds.Tables[0].Rows[0]["CLITELEFONO"].ToString();
                    id = Convert.ToInt32(ds.Tables[0].Rows[0]["IDCLIENTE"].ToString());
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "No hay datos", ToastLength.Short).Show();

                }


            };
            
            void limpiar()
            {
                nombrec.Text = apellidoc.Text = cedulac.Text = direc.Text = telfc.Text = "";
                id = 0;
            }

        }
    }
}