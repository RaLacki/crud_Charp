using System;
using System.Collections.Generic;
using System.Windows;

namespace CrudBoost
{
    public partial class MainWindow : Window
    {
        private readonly DataBase db = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person p = new Person(
                    txtNom.Text,
                    txtPrenom.Text,
                    int.Parse(txtAge.Text),
                    txtAdresse.Text,
                    txtTelephone.Text
                );

                db.AddPerson(p);
                MessageBox.Show("Personne ajoutée !");
                Afficher_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void Afficher_Click(object sender, RoutedEventArgs e)
        {
            listPersons.Items.Clear();
            List<Person> personnes = db.GetAllPersons();

            foreach (var p in personnes)
            {
                listPersons.Items.Add("{p.Id}: {p.Nom} {p.Prenom} - {p.Age} ans - {p.Adresse} - {p.Telephone}");
            }
        }
    }
}
