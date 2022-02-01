using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AplicativoFit.Droid;
using AplicativoFit.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRender), typeof(SubEntryRender))]
namespace AplicativoFit.Droid
{
    [Obsolete]
    public class SubEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control.IsFocused == true)
                Control.SetOutlineAmbientShadowColor(global::Android.Graphics.Color.Red);
                //Control.SetBackgroundColor(global::Android.Graphics.Color.LightBlue);
        }
    }
}