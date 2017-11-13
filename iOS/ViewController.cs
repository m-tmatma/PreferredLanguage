using System;
using System.Globalization;
using System.Threading;
using Foundation;
using UIKit;

namespace PreferredLanguage.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                Button.SetTitle(title, UIControlState.Normal);
            };

            // Perform any additional setup after loading the view, typically from a nib.
            DateButton.AccessibilityIdentifier = "dateButton";
            DateButton.TouchUpInside += delegate
            {
                var langsMain = NSBundle.MainBundle.PreferredLocalizations;
                var langsLocale = NSLocale.PreferredLanguages;
                var langMain = langsMain[0];
                var langLocale = langsLocale[0];
                var dt = DateTime.Now;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(langLocale);
                var title = dt.ToString("d");
                DateButton.SetTitle(title, UIControlState.Normal);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
