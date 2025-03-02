using System;

public class Connection
{
    public static string GetConnectionString()
    {

        //Torben Ziller 1.3.2025 Das hier ist der Connection String für die Datenbank
        return "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
    }
}