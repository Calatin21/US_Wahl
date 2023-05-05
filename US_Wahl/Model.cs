using System.Text;

namespace US_Wahl {
    internal static class Model {
        public static List<string> Nachnamen { get; set; }
        public static List<string> VornamenJungen { get; set; }
        public static List<string> VornamenMaedchen { get; set; }
        public static List<Person> Personen { get; set; } = new();
        public static void Dateneinlesen() {
            Model.FuelleVornamenJungen();
            Model.FuelleVornamenMaedchen();
            Model.FuelleNachnamen();
        }
        public static void GeneriereWahlVolk(int x) {
            Random rnd = new();
            for (int i = 0; i < x; i++) {
                Personen.Add(new Person(Nachnamen[i], Personen.Count()));
            }
            foreach (Person item in Personen) {
                if (item.GeschlechtsGruppe == (Geschlecht)0) {
                    item.Vorname = VornamenMaedchen[rnd.Next(0, 594)];
                }
                else if (item.GeschlechtsGruppe == (Geschlecht)1) {
                    item.Vorname = VornamenJungen[rnd.Next(0, 574)];
                }
            }
        }
        public static void ZeigeWahlvolk() {
            foreach (Person item in Personen) {
                Console.WriteLine($"ID: {item.ID}\nVorname: {item.Vorname}");
                Console.WriteLine($"Nachname: {item.Nachname}\nPostleitzahl: {item.PLZ}");
                Console.WriteLine($"Geschlecht: {item.GeschlechtsGruppe}\nAlter: {item.AltersGruppe}");
                Console.WriteLine($"Schicht: {item.SchichtGruppe}\nPartei Vorliebe: {item.ParteiGruppe}");
                Console.WriteLine($"Beeinflußbarkeit: {item.BeeinflussungsGruppe}");
            }
        }
        public static void SichereDaten() {
            FileStream outputStream = new("Wähler.csv", FileMode.OpenOrCreate, FileAccess.Write);
            string message = "ID;";
            message += "Vorname;";
            message += "Nachname;";
            message += "Postleitzahl;";
            message += "Geschlecht;";
            message += "Alter;";
            message += "Parteizugehörigkeit;";
            message += "Schicht;";
            message += "Beeinlfussbarkeit\n";
            foreach (Person item in Personen) {
                message += item.ID.ToString() + ";";
                message += item.Vorname.ToString() + ";";
                message += item.Nachname.ToString() + ";";
                message += item.PLZ.ToString() + ";";
                message += item.GeschlechtsGruppe.ToString() + ";";
                message += item.AltersGruppe.ToString() + ";";
                message += item.ParteiGruppe.ToString() + ";";
                message += item.SchichtGruppe.ToString() + ";";
                message += item.BeeinflussungsGruppe.ToString();
                message += "\n";
            }
            byte[] outputMessageBytes = Encoding.Latin1.GetBytes(message);
            outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
            outputStream.Close();
        }
        public static void FuelleVornamenJungen() {
            FileStream stream = new("jungennamen.txt", FileMode.Open, FileAccess.Read);
            long fileLength = stream.Length;
            byte[] readBytes = new byte[fileLength];
            stream.Read(readBytes, 0, (int)fileLength);
            string readString = Encoding.Latin1.GetString(readBytes);
            VornamenJungen = readString.Split(new[] { '\n' }).ToList();
            stream.Close();
        }
        public static void FuelleVornamenMaedchen() {
            FileStream stream = new("maedchennamen.txt", FileMode.Open, FileAccess.Read);
            long fileLength = stream.Length;
            byte[] readBytes = new byte[fileLength];
            stream.Read(readBytes, 0, (int)fileLength);
            string readString = Encoding.Latin1.GetString(readBytes);
            VornamenMaedchen = readString.Split(new[] { '\n' }).ToList();
            stream.Close();
        }
        public static void FuelleNachnamen() {
            FileStream stream = new("nachnamen.txt", FileMode.Open, FileAccess.Read);
            long fileLength = stream.Length;
            byte[] readBytes = new byte[fileLength];
            stream.Read(readBytes, 0, (int)fileLength);
            string readString = Encoding.Latin1.GetString(readBytes);
            Nachnamen = readString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            stream.Close();
        }
    }
}

