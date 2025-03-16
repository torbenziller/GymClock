using System;
using System.Data;
using System.Data.SQLite;
using Dapper;


//16.03.2025 ToZi -  Erstellt für das Model der Tabelle AccUser

namespace GymClock.Database.Models
{
    /* 
     * In dieser klasse wird das Model für die Tabelle (Datenbank) vordefiniert was da gespeichert werden soll
     * Das hilft dabei die Datenbank zu strukturieren und die Daten zu speichern
     */
    public class cAccUserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Passwort { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Name
        {
            get
            {
                return $"{Vorname} {Nachname}"; // Leerzeichen zwischen Vorname und Nachname hinzugefügt
            }
        }
    }

    public class cAccUserDataAcess
    {
        public static List<cAccUserModel> LoadListAccUser()
        {
            // ToZi 16.03.2025 Hier wird mit dem SQLite Connector eine Verbindung zur Datenbank aufgebaut
            using (IDbConnection cnn = new SQLiteConnection(Connection.GetConnectionString()))
            {
                var output = cnn.Query<cAccUserModel>("select * from AccUser", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveListAccUser(cAccUserModel user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Passwort) ||
                string.IsNullOrEmpty(user.Vorname) || string.IsNullOrEmpty(user.Nachname))
            {
                throw new ArgumentException("All user properties must be set.");
            }

            using (IDbConnection cnn = new SQLiteConnection(Connection.GetConnectionString()))
            {
                cnn.Execute("insert into AccUser (Username, Passwort, Vorname, Nachname) values (@Username, @Passwort, @Vorname, @Nachname)", user);
            }
        }
    }
}
