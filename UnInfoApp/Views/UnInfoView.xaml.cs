namespace UnInfoApp.Views;

public partial class UnInfoView : ContentView
{
	public UnInfoView(string unName, string unWebsite)
	{
		InitializeComponent();
		UnName.Text = unName;
		UnWebsite.Text = unWebsite;
	}
}
