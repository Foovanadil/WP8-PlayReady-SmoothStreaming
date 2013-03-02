using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace SmoothStreaming.Sample
{
	public partial class MainPage : PhoneApplicationPage
	{
		const string LAURL = "http://playready.directtaps.net/pr/svc/rightsmanager.asmx?";

		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// Sample code to localize the ApplicationBar
			var la = new LicenseAcquirer();
			la.LicenseServerUriOverride = new Uri(LAURL);
			
			la.AcquireLicenseCompleted += la_AcquireLicenseCompleted;
			

			player.MediaFailed += player_MediaFailed;
				player.LicenseAcquirer = la;
				player.Source = new Uri("http://playready.directtaps.net/smoothstreaming/TTLSS720VC1PR/To_The_Limit_720.ism/Manifest");
		
		}

		void la_AcquireLicenseCompleted(object sender, AcquireLicenseCompletedEventArgs e)
		{
			Debug.WriteLine(e.ResponseCustomData);
		}

		void player_MediaFailed(object sender, System.Windows.ExceptionRoutedEventArgs e)
		{
			Debug.WriteLine(e.ErrorException.ToString());
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			player.Dispose();
			base.OnNavigatedFrom(e);
		}
	}
}