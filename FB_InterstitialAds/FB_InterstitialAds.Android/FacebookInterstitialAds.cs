using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FB_InterstitialAds.Droid;
using Xamarin.Facebook.Ads;

[assembly:Dependency(typeof(FacebookInterstitialAds))]
namespace FB_InterstitialAds.Droid
{
    public class FacebookInterstitialAds : IFacebookInterstitialAds
    {
        private InterstitialAd interstitialAd;
        public void ShowAds()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context, "YOUR_ADS_UNIT_DS"); //Ads Unit ID
            interstitialAd.LoadAd();
            interstitialAd.SetAdListener(new InterstitialAdListener(interstitialAd));
        }
    }

    internal class InterstitialAdListener : Java.Lang.Object, IInterstitialAdListener
    {
        private InterstitialAd interstitialAd;

        public InterstitialAdListener(InterstitialAd interstitialAd)
        {
            this.interstitialAd = interstitialAd;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public void OnAdClicked(IAd p0)
        {
            Console.WriteLine("OnAdClicked");
        }

        public void OnAdLoaded(IAd p0)
        {
            Console.WriteLine("");
            interstitialAd.Show();
        }

        public void OnError(IAd p0, AdError p1)
        {
            Console.WriteLine("OnError: " + p1.ErrorMessage);
        }

        public void OnInterstitialDismissed(IAd p0)
        {
            Console.WriteLine("OnInterstitialDismissed");
        }

        public void OnInterstitialDisplayed(IAd p0)
        {
            Console.WriteLine("OnInterstitialDisplayed");
        }

        public void OnLoggingImpression(IAd p0)
        {
            Console.WriteLine("OnLoggingImpression");
        }
    }
}