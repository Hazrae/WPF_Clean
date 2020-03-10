using Dal = DAL.Model;
using Local = ModelLocal.Models;

namespace ModelLocal.Utils
{
    public static class Mappers
    {
        public static Local.Film ToLocal(this Dal.Film f)
        {
            return new Local.Film
            {
                Titre = f.Titre,
                AnneeDeSortie = f.AnneeDeSortie,
                ActeurPrincipal = f.ActeurPrincipal,
                Realisateur = f.Realisateur
            };
        }

        public static Dal.Film ToGlobal(this Local.Film f)
        {
            return new Dal.Film
            {
                Titre = f.Titre,
                AnneeDeSortie = f.AnneeDeSortie,
                ActeurPrincipal = f.ActeurPrincipal,
                Realisateur = f.Realisateur

            };
        }
    }
}

