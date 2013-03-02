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
			//la.ChallengeCustomData =
			//	"StreamInstanceID=fd29fbf6-7de8-4f1c-b7fc-68ba4f242c7e&AssetID=627740&DestinationUniqueID=938888474@XBX-976383503&DeviceTypeId=842&ClientIP=209.237.233.54&AffiliateId=3991&ServerIP=10.22.121.82&PurchaseType=Purchase&PurchaseEndDate=12/31/2049 12:00:00 AM&RentalPeriodAllowedMinutes=59940&MinutesDiff=0";

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