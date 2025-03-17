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
    private cAccUserModel selectedUser;

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
        group1.AddButton(new RibbonButton("Hinzufügen", "add_d.png", () => { OnUserOverviewClearEntry(); }));
        group1.AddButton(new RibbonButton("Hinzufügen", "save.png", () => { OnUserOverviewAddPerson(); }));
        group1.AddButton(new RibbonButton("Löschen", "trash_can.png", () => { OnUserOverviewDeletePerson(); }));
        group1.AddButton(new RibbonButton("Aktualisieren", "refresh.png", () => { OnUserOverviewRefresh(); }));
        
        ribbonBar.AddGroup("Datensatz", group1);
    }

    private void OnUserOverviewClearEntry()
    {
        UserNachnameEntry.Text = null;
        UserPasswortEntry.Text = null;
        UserVornameEntry.Text = null;
        UserUsernameEntry.Text = null;
    }
    private void LoadUserList()
    {
        try
        {
            var loadedUsers = cAccUserDataAcess.LoadListAccUser();
            // liste leeren und neue Daten hinzufügen, statt zu ersetzen
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
            DisplayAlert("Fehler", $"Fehler beim Laden {ex.Message}", "OK");
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
            ClearInputFields();
            // Liste aktualisieren
            LoadUserList();
            DisplayAlert("Erfolg", "Benutzer wurde erfolgreich hinzugefügt.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Fehler", $"Fehler beim Hinzufügen {ex.Message}", "OK");
        }
    }

    private void OnUserOverviewRefresh()
    {
        LoadUserList();
    }

    // Neue Methode: Eingabefelder leeren
    private void ClearInputFields()
    {
        UserUsernameEntry.Text = string.Empty;
        UserPasswortEntry.Text = string.Empty;
        UserVornameEntry.Text = string.Empty;
        UserNachnameEntry.Text = string.Empty;
        selectedUser = null;
    }

    // Neue Methode: Benutzer aus der Liste löschen
    private void OnUserOverviewDeletePerson()
    {
        if (selectedUser == null)
        {
            DisplayAlert("Hinweis", "Bitte wählen Sie zuerst einen Benutzer aus.", "OK");
            return;
        }

        try
        {
            
            ClearInputFields();
            LoadUserList();
            DisplayAlert("Erfolg", "Benutzer wurde erfolgreich gelöscht.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Fehler", $"Fehler beim Löschen: {ex.Message}", "OK");
        }
    }

    // Neue Methode: Reagiert auf die Auswahl eines Benutzers in der Liste
    private void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        selectedUser = e.SelectedItem as cAccUserModel;

        // Daten des ausgewählten Benutzers in die Eingabefelder übertragen
        UserUsernameEntry.Text = selectedUser.Username;
        UserPasswortEntry.Text = selectedUser.Passwort;
        UserVornameEntry.Text = selectedUser.Vorname;
        UserNachnameEntry.Text = selectedUser.Nachname;
    }

    // Diese Methode im XAML für den ListView verwenden
    // z.B. <ListView x:Name="UserList" ItemSelected="OnUserSelected" ...>
}