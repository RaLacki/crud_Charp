using System;
using System.Collections.Generic;
using Npgsql;

namespace CrudBoost
{
    public class DataBase
    {
        private readonly string connectionString;

        public DataBase()
        {
            connectionString = "Host=localhost;Port=5432;Database=javaweb;Username=postgres;Password=123";
        }


        public void AddPerson(Person p)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO person (nom, prenom, age, adresse, telephone) VALUES (@nom, @prenom, @age, @adresse, @telephone);";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nom", p.Nom);
                    cmd.Parameters.AddWithValue("prenom", p.Prenom);
                    cmd.Parameters.AddWithValue("age", p.Age);
                    cmd.Parameters.AddWithValue("adresse", p.Adresse);
                    cmd.Parameters.AddWithValue("telephone", p.Telephone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> persons = new List<Person>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nom, prenom, age, adresse, telephone FROM person;";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persons.Add(new Person(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetString(5)
                        ));
                    }
                }
            }

            return persons;
        }

        public void EditPerson(Person p)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE person SET nom = @nom, prenom = @prenom, age = @age, adresse = @adresse, telephone = @telephone WHERE id = @id;";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nom", p.Nom);
                    cmd.Parameters.AddWithValue("prenom", p.Prenom);
                    cmd.Parameters.AddWithValue("age", p.Age);
                    cmd.Parameters.AddWithValue("adresse", p.Adresse);
                    cmd.Parameters.AddWithValue("telephone", p.Telephone);
                    cmd.Parameters.AddWithValue("id", p.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePerson(int id)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM person WHERE id = @id;";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
