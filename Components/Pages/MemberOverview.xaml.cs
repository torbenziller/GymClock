using GymClock.Components.Ribbon;


namespace GymClock.Components.Pages;

public partial class MemberOverview : ContentPage
{
	public MemberOverview()
	{
		InitializeComponent();
        InitializeRibbonBar();
    }
    /*--Ribbonbar Belegung--*/
    private void InitializeRibbonBar()
    {
        var tab1 = ribbonBar.AddTab("Datensatz");
        var group1 = new RibbonGroup();
        var group3 = new RibbonGroup();
        group1.AddButton(new RibbonButton("Speichern", "save.png", () => { RibbonMemberOverviewSave(); }));
        group1.AddButton(new RibbonButton("Öffnen", "open_dokument.png", () => { /* Öffnen-Logik */ }));
        group1.AddButton(new RibbonButton("Suchen", "search.png", () => { /*  */ }));
        group3.AddButton(new RibbonButton("Kopieren", "add_d.png", () => { /* Kopieren-Logik */ }));
        ribbonBar.AddGroup("Datensatz", group1);
        ribbonBar.AddGroup("Datensatz", group3);

        var tab2 = ribbonBar.AddTab("Bearbeiten");
        var group2 = new RibbonGroup();
        group2.AddButton(new RibbonButton("Kopieren", "add_d.png", () => { /* Kopieren-Logik */ }));
        
        ribbonBar.AddGroup("Bearbeiten", group2);
    }

    /*--Ribbon Aktion--*/
    // Hier werden die Buttons der RibbonBar mit Funktionalität belegt
    private async void RibbonMemberOverviewSave()
    {
        await DisplayAlert("Speichern","Wollen sie wikrlich speichern", "Ja", "Nein");
    }

    private void RibbonMemberOverviewOpen()
    {

    }
    private void RibbonMemberOverviewCopy()
    {

    }
}