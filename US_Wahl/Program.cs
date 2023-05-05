namespace US_Wahl {
    internal class Program {
        static void Main(string[] args) {
            Model.Dateneinlesen();
            Model.GeneriereWahlVolk(1000);
            //Console.WriteLine(Model.Nachnamen.Count());
            //Console.WriteLine(Model.VornamenMaedchen.Count());
            //Console.WriteLine(Model.VornamenJungen.Count());
            //Console.WriteLine(Model.Personen.Count());
            //Model.ZeigeWahlvolk();
            Model.SichereDaten();

        }
    }
}