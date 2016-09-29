using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.BLE;

namespace Native.Droid
{
    [Activity(Label = "Native.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            using (var btn = FindViewById<Button>(Resource.Id.button1))
            {
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;
            adapter.DeviceDiscovered += Adapter_DeviceDiscovered;
            RunOnUiThread(async () => await adapter.StartScanningForDevicesAsync());
        }

        private void Adapter_DeviceDiscovered(object sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {
            Toast.MakeText(this, "DISCOVERED", ToastLength.Long).Show();
            System.Diagnostics.Debug.WriteLine("discovered");
        }
    }
}

