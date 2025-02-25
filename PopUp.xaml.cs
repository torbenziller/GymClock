namespace GymClock;

public partial class PopUp : ContentPage
{
	public PopUp()
	{
		InitializeComponent();
	}

	private void OnPointerEntered(object sender, EventArgs e)
{
    ((Frame)sender).Opacity = 0.7;
}

private void OnPointerExited(object sender, EventArgs e)
{
    ((Frame)sender).Opacity = 1.0;
}
}