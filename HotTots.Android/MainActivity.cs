
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using System.IO;

namespace HotTots.Droid
{
    [Activity(Label = "HotTots", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            AssetManager asset = this.Assets;
            convert();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            
        }
        public void convert()
        {
            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("DBCOPY.txt")))
            {
                content = sr.ReadToEnd();
            }
            var sqliteFilename = "hottots.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            // This is where we copy in our pre-created database
            if (!File.Exists(path) || content.Equals("FORCE"))
            {
                AssetManager asset = this.Assets;
                using (var binaryReader = new BinaryReader(asset.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            return;
        }


    }
}