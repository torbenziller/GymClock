namespace GymClock;
using GymClock.Components.Ribbon;

public partial class PopUp : ContentPage
{
	public PopUp()
	{
		InitializeComponent();
        InitializeRibbonBar();
    }

    private void InitializeRibbonBar()
    {
        var tab1 = ribbonBar.AddTab("Datensatz");
        
        var group1 = new RibbonGroup();
        group1.AddButton(new RibbonButton("Speichern", "save.png", () => {  }));
        group1.AddButton(new RibbonButton("Kopieren", "add_d.png", () => { /* Kopieren-Logik */ }));
        ribbonBar.AddGroup("Datensatz", group1);

        var tab2 = ribbonBar.AddTab("Kommunikation");
        var group2 = new RibbonGroup();
        group2.AddButton(new RibbonButton("per Mail versenden", "send_mail.png", () => { /* Logik */ }));
        ribbonBar.AddGroup("Kommunikation", group2);

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