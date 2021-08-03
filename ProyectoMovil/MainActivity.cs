using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace ProyectoMovil
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        connectDB db = new connectDB();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var user = FindViewById<EditText>(Resource.Id.txtUser);
            var pwd = FindViewById<EditText>(Resource.Id.txtClave);
            var btnIngresar = FindViewById<Button>(Resource.Id.button1);

            btnIngresar.Click += delegate
            {
                if (user.Text == "" && pwd.Text=="")
                {
                    Toast.MakeText(this, "Llene los campos", ToastLength.Short).Show();
                }
                else
                {


                    if (db.Ingresar(user.Text, pwd.Text) == 0)
                    {
                        Toast.MakeText(this, "Usuario Incorrecto", ToastLength.Short).Show();
                        limpiarCampos();
                    }
                    else if (db.Ingresar(user.Text, pwd.Text) == 1)
                    {
                        Toast.MakeText(this, "Bienvenido Administrador", ToastLength.Short).Show();
                        limpiarCampos();
                    }
                    else
                    {
                        Toast.MakeText(this, "Bienvenido Usuario", ToastLength.Short).Show();
                        limpiarCampos();
                    }
                }
            };


            void limpiarCampos()
			{
                user.Text = pwd.Text = "";
			}



        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}