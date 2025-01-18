using Emgu.CV.Aruco;
using Npgsql;

namespace IAR.Database;

public sealed class DatabaseManager
{
    protected static String connectionString = null;


    protected static void SetConnectionString()
    {
        Dictionary<string,string> properties = new Dictionary<string,string>();
        connectionString = $"Host={properties["Host"]}Port={properties["Port"]};Username={properties["Username"]};Password={properties["Password"]};Database={properties["Database"]}";
    }

    public static List<Dictionary<string, Object>> Execute(string query, NpgsqlConnection connection)
    {
        List<Dictionary<string, Object>> result = new List<Dictionary<string, Object>>();
        using (var command = new NpgsqlCommand(query, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                string[] columnNames = GetColumnNames(reader);

                while (reader.Read())
                {
                    Dictionary<string, Object> row = new Dictionary<string, Object>();
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        row.Add(columnNames[i], reader[columnNames[i]]);
                    }

                    result.Add(row);
                }
            }
        }

        return result;
    }

    public static NpgsqlConnection GetConnection()
    {
        if (connectionString==null)
        {
            SetConnectionString();
        }
        return new NpgsqlConnection(connectionString);
    }

    protected static string[] GetColumnNames(NpgsqlDataReader reader)
    {
        string[] columnNames = new string[reader.FieldCount];
        for (int i = 0; i < reader.FieldCount; i++)
        {
            columnNames[i] = reader.GetName(i);
        }

        return columnNames;
    }

    public static List<Dictionary<string, Object>> Execute(string query)
    {
        List<Dictionary<string, Object>> result = new List<Dictionary<string, Object>>();
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        try
        {
            connection.Open();
            return Execute(query, connection);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
        finally
        {
            connection.Close();
        }

        return result;
    }

    private static Dictionary<string,string> ReadProperties()
    {
        string filePath = "../../../config.properties"; // Chemin vers le fichier .properties
        Dictionary<string, string> result = new Dictionary<string, string>();
        try
        {
            // Dictionnaire pour stocker les paires clé-valeur
            var properties = new Dictionary<string, string>();

            // Lire chaque ligne du fichier
            foreach (var line in File.ReadAllLines(filePath))
            {
                // Ignorer les lignes vides ou les commentaires (commençant par # ou ;)
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#") || line.StartsWith(";"))
                    continue;

                // Diviser la ligne en clé et valeur
                var keyValue = line.Split(new[] { '=' }, 2); // Diviser uniquement au premier '='
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim();
                    string value = keyValue[1].Trim();
                    properties[key] = value;
                }
            }

            // Afficher les propriétés chargées
            foreach (var entry in properties)
            {
                result.Add(entry.Key, entry.Value);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Put the config.properties file at the root of the project: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture du fichier : {ex.Message}");
        }

        return result;
    }
}