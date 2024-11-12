namespace ConsoleApp4
{
    internal class Varos
    {
        public string VarosNev { get; set; }
        public string OrszagNev { get; set; }
        public double Nepesseg { get; set; }

        public Varos(string sor)
        {
            var v = sor.Split(';');
            VarosNev = v[0];
            OrszagNev = v[1];
            Nepesseg = double.Parse(v[2]);
        }
        public override string ToString()
        {
            return $"{VarosNev} ({OrszagNev}), Népesség: {Nepesseg:00.0} millió fő";
        }
    }
}