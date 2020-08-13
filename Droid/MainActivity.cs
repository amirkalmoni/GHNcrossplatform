using Android.App;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Database;

namespace GHNcrossplatform.Droid
{
    [Activity(Label = "GHN", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Button buttontestconnection;
        FirebaseDatabase database;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            buttontestconnection = FindViewById<Button>(Resource.Id.myButton);
            buttontestconnection.Click += Buttontestconnection_Click;
            

            
        }

        private void Buttontestconnection_Click(object sender, System.EventArgs e)
        {
            InitializeDatabase();
        }

        //function to initialize the database
        void InitializeDatabase() 
        {
            var app = FirebaseApp.InitializeApp(this);

            //condition is to force initialization incase it returns null
            if (app == null) 
            {
                var options = new FirebaseOptions.Builder()
                .SetApplicationId("ghn - authentication")
                .SetApiKey("AIzaSyCibbH9NC4NZ6ieNSiM8-TTDhR34N76pTM")
                .SetDatabaseUrl("https://ghn-authentication.firebaseio.com")
                .SetStorageBucket("ghn-authentication.appspot.com")
                .Build();


                //Initialization of database in app
                app = FirebaseApp.InitializeApp(this, options);
                database = FirebaseDatabase.GetInstance(app);

            }
            //Code Continues if itialization doesnt fail
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            DatabaseReference dbref = database.GetReference("Test");
            dbref.SetValue("Ticket1");

            Toast.MakeText(this, "it Works bruv", ToastLength.Short).Show();

        }

    }

}

