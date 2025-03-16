using GymClock.Components.Ribbon;
using GymClock.Database.Models;
using System.Data;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace GymClock.Components.Pages;

public partial class UserOverview : ContentPage
{
    public ObservableCollection<cAccUserModel> user { get; set; }
    public UserOverview()
	{
		InitializeComponent();
        InitializeRibbonBar();
        

        user = new ObservableCollection<cAccUserModel>();
        BindingContext = this;
        LoadUserList();

    }
    //Ribbonbar Belegung
    private void InitializeRibbonBar()
    {
        var tab1 = ribbonBar.AddTab("Datensatz");

        var group1 = new RibbonGroup();
        group1.AddButton(new RibbonButton("Hinzufügen", "save.png", () => { OnUserOverviewAddPerson(); }));
        group1.AddButton(new RibbonButton("Löschen", "trash_can.png", () => { /* Öffnen-Logik */ }));
        group1.AddButton(new RibbonButton("Aktualisieren", "refresh.png", () => { OnUserOverviewRefresh(); }));
        ribbonBar.AddGroup("Datensatz", group1);
        
    }

    private void LoadUserList()
    {
        try
        {
            var loadedUsers = cAccUserDataAcess.LoadListAccUser();

            // Collection leeren und neue Daten hinzufügen, statt zu ersetzen
            user.Clear();
            foreach (var item in loadedUsers)
            {
                user.Add(item);
            }

            // Nur ItemsSource setzen, wenn es nicht bereits gesetzt ist
            if (UserList.ItemsSource == null)
            {
                UserList.ItemsSource = user;
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Fehler", $"Fehler beim Laden der Benutzerliste: {ex.Message}", "OK");
        }
    }

    private void WireUpPeopleList()
    {
        // Korrigiert: ItemsSource nicht auf "Name" setzen, sondern DisplayMember in XAML definieren
        // UserList.ItemsSource = null; // Unnötig, da wir die gleiche ObservableCollection verwenden
        UserList.ItemsSource = user;
    }

    private void OnUserOverviewAddPerson()
    {
        try
        {
            // Nullprüfungen hinzufügen
            if (UserUsernameEntry == null || UserPasswortEntry == null ||
                UserVornameEntry == null || UserNachnameEntry == null)
            {
                DisplayAlert("Fehler", "Eingabefelder konnten nicht gefunden werden.", "OK");
                return;
            }

            cAccUserModel accUserModel = new cAccUserModel
            {
                Username = UserUsernameEntry.Text ?? string.Empty,
                Passwort = UserPasswortEntry.Text ?? string.Empty,
                Vorname = UserVornameEntry.Text ?? string.Empty,
                Nachname = UserNachnameEntry.Text ?? string.Empty
            };

            cAccUserDataAcess.SaveListAccUser(accUserModel);

            // Eingabefelder leeren
            UserUsernameEntry.Text = string.Empty;
            UserPasswortEntry.Text = string.Empty;
            UserVornameEntry.Text = string.Empty;
            UserNachnameEntry.Text = string.Empty;

            // Liste aktualisieren
            LoadUserList();

            DisplayAlert("Erfolg", "Benutzer wurde erfolgreich hinzugefügt.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Fehler", $"Fehler beim Hinzufügen des Benutzers: {ex.Message}", "OK");
        }
    }

    private void OnUserOverviewRefresh()
    {
        LoadUserList();
    }


}