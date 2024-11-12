using ConsoleApp4;

List<Varos> varosok = new();

using StreamReader sr = new($@"..\..\..\src\varosok.csv", encoding: System.Text.Encoding.UTF8);
sr.ReadLine();
while (!sr.EndOfStream) varosok.Add(new(sr.ReadLine()));

Console.WriteLine($"Kollekció hossza: {varosok.Count}\n");

//1) hány millió fő él összesen kínai nagyvárosokban?
double f1 = varosok.Where(f => f.OrszagNev == "Kína").Sum(f => f.Nepesseg);
Console.WriteLine($"Összesen {f1} millió fő él a kínai nagyvárosokban!\n");

//2) mekkora az indiai nagyvárosok átlaglélekszáma?
double f2 = varosok.Where(f => f.OrszagNev == "India").Average(f => f.Nepesseg);
Console.WriteLine($"Indiai nagyvárosok átlaglélekszáma: {f2}\n");

//3) melyik nagyváros a legnépesebb?
string f3 = varosok.OrderByDescending(f => f.Nepesseg).First().VarosNev;
Console.WriteLine($"Legnépesebb nagyváros: {f3}\n");

//4) 20M lakos feletti nagyvárosok, népesség szerint csökkenő sorrendben.
Console.WriteLine("20M lakos feletti nagyvárosok:");
var f4 = varosok.Where(f => f.Nepesseg > 20).OrderByDescending(f => f.Nepesseg).ToList();
foreach (var varos in f4) Console.WriteLine(varos);

//5) hány olyan ország van, ami több nagyávárossal is szerepel a listában?
var f5 = varosok.GroupBy(v => v.OrszagNev).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
Console.WriteLine($"\nOlyan országok száma, ahol több nagyváros szerepel: {f5.Count}\n");

//6) milyen betűvel kezdődik a legtöbb nagyváros neve?
var f6 = varosok.GroupBy(v => v.VarosNev[0]).OrderByDescending(g => g.Count()).First().Key;
Console.WriteLine($"A legtöbb város neve a '{f6}' betűvel kezdődik.");

