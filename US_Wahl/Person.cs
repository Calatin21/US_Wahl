namespace US_Wahl {
    public enum Geschlecht { weiblich, maennlich };
    public enum Schicht { Unterschicht, Unteremittelschicht, Oberemittelschicht, Oberschicht };
    public enum Alter { Erstwaehler, BIS30, BIS40, BIS50, Restliche };
    public enum Beeinflussbar { Leicht, Mittel, Schwer };
    public enum Partei { Demokraten, Republikaner };
    internal class Person {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int PLZ { get; set; }
        public Geschlecht GeschlechtsGruppe { get; set; }
        public Alter AltersGruppe { get; set; }
        public Partei ParteiGruppe { get; set; }
        public Schicht SchichtGruppe { get; set; }
        public Beeinflussbar BeeinflussungsGruppe { get; set; }
        public Person(string nachname, List<Person> Personen) {
            Random rnd = new();
            this.ID = Personen.Count();
            this.Nachname = nachname;
            this.PLZ = rnd.Next(10000, 100000);
            this.GeschlechtsGruppe = (Geschlecht)rnd.Next(0, 2);
            this.AltersGruppe = (Alter)rnd.Next(0, 5);
            this.ParteiGruppe = (Partei)rnd.Next(0, 2);
            this.SchichtGruppe = (Schicht)rnd.Next(0, 4);
            this.BeeinflussungsGruppe = (Beeinflussbar)rnd.Next(0, 2);
        }
    }
}
