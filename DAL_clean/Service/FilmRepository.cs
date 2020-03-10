using DAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Service
{
    public class FilmRepository : IRepository<Film>
    {

        private const string connecString = @"Data Source=FORMA-VDI1114\TFTIC;Initial Catalog=ProjetWPF;User ID=sa;Password=tftic@2012";

        private readonly SqlConnection connec = new SqlConnection(connecString);


        //Ajout film

        public void Create(Film f)
        {
                //Creation de l'objet commande
            using(SqlCommand cmd = connec.CreateCommand())
            {
               string command = "Insert into Film (titre,acteurPrincipal,realisateur,anneeDeSortie) values (@titre,@acteur,@real,@annee)";

               //Parametres
               SqlParameter PTitre = new SqlParameter("titre",f.Titre);
               SqlParameter PActeur = new SqlParameter("acteur",f.ActeurPrincipal);
               SqlParameter PReal = new SqlParameter("real",f.Realisateur);
               SqlParameter PAnnee = new SqlParameter("annee",f.AnneeDeSortie);

               //construction de la cmd
               cmd.CommandText = command;
               cmd.Parameters.Add(PTitre);
               cmd.Parameters.Add(PActeur);
               cmd.Parameters.Add(PReal);
               cmd.Parameters.Add(PAnnee);

               //exec
               connec.Open();
               cmd.ExecuteScalar();
               connec.Close();


            }

            
        }

        //récupérer la liste de tous les films

        public List<Film> GetAll()
        {
            List<Film> l = new List<Film>();
            connec.Open();

            //creation de la cmd
            using (SqlCommand cmd = connec.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Film";
                
                //execution
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //creation de la liste en bouclant sur le DR
                    while (dr.Read())
                    {
                        l.Add(new Film
                        {
                            Titre = dr["titre"].ToString(),
                            ActeurPrincipal = dr["acteurPrincipal"].ToString(),
                            Realisateur = dr["realisateur"].ToString(),
                            AnneeDeSortie = (int)dr["anneeDeSortie"]
                        });
                    }
                }               
            }
            connec.Close();
            return l;
        }


        //Récupération d'un film en particulier
        public Film GetOne(int id)
        {
            connec.Open();
            Film f = new Film();

            //creation de la cmd
            using (SqlCommand cmd = connec.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Film WHERE iDFilm = @id";
                cmd.Parameters.AddWithValue("id", id);

                //exécution et boucle sur le DR pour garnir l'objet
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    f.Titre = dr["titre"].ToString();
                    f.ActeurPrincipal = dr["acteurPrincipal"].ToString();
                    f.Realisateur = dr["realisateur"].ToString();
                    f.AnneeDeSortie = (int)dr["anneeDeSortie"];

                    connec.Close();
                    return f;
                }
            }
        }
    }
}
