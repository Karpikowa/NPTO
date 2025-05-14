namespace zad2;

using System;
using System.Collections.Generic;

class Person
{
    private string FirstName;
    private string LastName;
    private string JobTitle;
    private string Company;
    private string Email = "Email: ";
    private string Adress = "Adres: ";

    public Person(string firstName, string lastName, string jobTitle, string company, 
                  string email, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        JobTitle = jobTitle;
        Company = company;

        Email = string.IsNullOrEmpty(email) ? "Email: " : "Email: " + email;
        Adress = string.IsNullOrEmpty(address) ? "Adres: " : "Adres: " + address;
    }

    public string GetEmail() { return Email; }
    public string GetAdress() { return Adress; }

    public void DisplayShortInfo()
    {
        Console.Write("Skrócona wizytówka: ");
        Console.WriteLine();
        if (!string.IsNullOrEmpty(JobTitle) && !string.IsNullOrEmpty(Company))
            Console.WriteLine($" {FirstName}  {LastName} ({JobTitle} at {Company})");

        else if (!string.IsNullOrEmpty(JobTitle))
            Console.WriteLine(FirstName + " " + LastName + " " + JobTitle);

        else if (!string.IsNullOrEmpty(Company))
            Console.WriteLine(FirstName + " " + LastName + " " + Company);

        else
            Console.WriteLine(FirstName + " " + LastName);
    }

    public void DisplayFullInfo()
    {
        Console.WriteLine("Pełna wizytówka: ");
        int szerokosc = Math.Max(FirstName.Length + LastName.Length + 1, 20);

        if (!string.IsNullOrEmpty(JobTitle))
            szerokosc = Math.Max(szerokosc, JobTitle.Length);

        if (!string.IsNullOrEmpty(Company))
            szerokosc = Math.Max(szerokosc, Company.Length);

        if (!string.IsNullOrEmpty(Email))
            szerokosc = Math.Max(szerokosc, Email.Length);

        if (!string.IsNullOrEmpty(Adress))
            szerokosc = Math.Max(szerokosc, Adress.Length);

        char znak1 = '=';
        char znak2 = '-';
        Console.WriteLine(new string(znak1, szerokosc));

        int srodek = (szerokosc - (FirstName.Length + LastName.Length + 1)) / 2;
        Console.WriteLine(new string(' ', srodek) + FirstName + " " + LastName);

        if (!string.IsNullOrEmpty(JobTitle) || !string.IsNullOrEmpty(Company) ||
            ((string.IsNullOrEmpty(JobTitle) && string.IsNullOrEmpty(Company)) &&
             (Email != "Email: " || Adress != "Adres: ")))
            Console.WriteLine(new string(znak2, szerokosc));

        if (!string.IsNullOrEmpty(JobTitle))
            Console.WriteLine(JobTitle);

        if (!string.IsNullOrEmpty(Company))
            Console.WriteLine(Company);

        if ((!string.IsNullOrEmpty(JobTitle) || !string.IsNullOrEmpty(Company)) &&
            (Email != "Email: " || Adress != "Adres: "))
            Console.WriteLine(new string(znak2, szerokosc));

        if (Email != "Email: ")
            Console.WriteLine(Email);

        if (Adress != "Adres: ")
            Console.WriteLine(Adress);

        Console.WriteLine(new string(znak1, szerokosc));
    }

    static void Main(string[] args)
    {
        List<Person> wizytowki = new List<Person>();
        string opcja;

        do
        {
            Console.WriteLine("=== Dodawanie wizytówki ===");

            string firstName, lastName;

            do
            {
                Console.Write("Podaj imię: ");
                firstName = Console.ReadLine();

                Console.Write("Podaj nazwisko: ");
                lastName = Console.ReadLine();

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                    Console.WriteLine("Brak obowiązkowych danych!!");

            } while (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));

            Console.Write("Podaj stanowisko: ");
            string jobTitle = Console.ReadLine();

            Console.Write("Podaj nazwę firmy: ");
            string company = Console.ReadLine();

            Console.Write("Podaj email: ");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                while (!email.Contains("@"))
                {
                    Console.WriteLine("E-mail NIE zawiera '@'. Podaj poprawny e-mail!");
                    Console.Write("Podaj email: ");
                    email = Console.ReadLine();
                }
            }

            Console.Write("Podaj adres: ");
            string address = Console.ReadLine();
            Console.WriteLine();

            wizytowki.Add(new Person(firstName, lastName, jobTitle, company,
                                    email, address));

            Console.Write("Czy chcesz dodać kolejną wizytówkę? (tak/nie): ");
            opcja = Console.ReadLine();

        } while (opcja == "tak" || opcja == "t");

        Console.WriteLine("\n=== Wszystkie wizytówki ===");
        foreach (var osoba in wizytowki)
        {
            osoba.DisplayShortInfo();
            Console.WriteLine();
            osoba.DisplayFullInfo();
            Console.WriteLine();
        }
    }
}