using GymClock.Components.Ribbon;
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
        var tab1 = ribbonBar.AddTab("Datei");
        var group1 = new RibbonGroup();
        group1.AddButton(new RibbonButton("Speichern", "sa.png", () => { RibbonMemberOverviewSave(); }));
        group1.AddButton(new RibbonButton("�ffnen", "open.png", () => { /* �ffnen-Logik */ }));
        ribbonBar.AddGroup("Datei", group1);

        var tab2 = ribbonBar.AddTab("Bearbeiten");
        var group2 = new RibbonGroup();
        group2.AddButton(new RibbonButton("Kopieren", "resources/images/icons/addD.png", () => { /* Kopieren-Logik */ }));
        group2.AddButton(new RibbonButton("Einf�gen", "paste.png", () => { /* Einf�gen-Logik */ }));
        ribbonBar.AddGroup("Bearbeiten", group2);
    }

    /*--Ribbon Aktion--*/
    // Hier werden die Buttons der RibbonBar mit Funktionalit�t belegt
    private void RibbonMemberOverviewSave()
    {

    }

    private void RibbonMemberOverviewOpen()
    {

    }
    private void RibbonMemberOverviewCopy()
    {

    }
}