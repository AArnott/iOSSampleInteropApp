using Nerdbank.Bitcoin;
using Nerdbank.Zcash;

namespace iOSSampleInteropApp
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow? Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// create a new window instance based on the screen size
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			try
			{
				ZcashAccount account = new(new Zip32HDWallet(Bip39Mnemonic.Create(256), ZcashNetwork.MainNet));
			}
			catch (InvalidOperationException)
			{
				// Expected, since we didn't provide a valid image.
			}

			// create a UIViewController with a single UILabel
			var vc = new UIViewController();
			vc.View!.AddSubview(new UILabel(Window!.Frame)
			{
				BackgroundColor = UIColor.SystemBackground,
				TextAlignment = UITextAlignment.Center,
				Text = "Hello, iOS!",
				AutoresizingMask = UIViewAutoresizing.All,
			});
			Window.RootViewController = vc;

			// make the window visible
			Window.MakeKeyAndVisible();

			return true;
		}
	}
}
