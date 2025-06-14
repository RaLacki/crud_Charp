namespace CrudBoost
{
    public class Person
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }

        public Person() { }

        public Person(string nom, string prenom, int age, string adresse, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Adresse = adresse;
            Telephone = telephone;
        }

        public Person(int id, string nom, string prenom, int age, string adresse, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Adresse = adresse;
            Telephone = telephone;
        }
    }
}
