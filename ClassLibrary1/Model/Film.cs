//le modele de la class de travail
//cette classe est scrupuleusement la meme que dans la DAL
//cette même class est la représentation idéeal de ce qu'il se trouve en base de donnée
namespace ModelLocal.Models //Idéalement elle doit être placée à part dans le access Layer, dans un dossier modèle par exemple
{
    public class Film
    {
		private string _titre;

		public string Titre
		{
			get { return _titre; }
			set { _titre = value; }
		}

		private string _acteurPrincipal;

		public string ActeurPrincipal
		{
			get { return _acteurPrincipal; }
			set { _acteurPrincipal = value; }
		}

		private string _realisateur;

		public string Realisateur
		{
			get { return _realisateur; }
			set { _realisateur = value; }
		}

		private int _anneeDeSortie;

		public int AnneeDeSortie
		{
			get { return _anneeDeSortie; }
			set { _anneeDeSortie = value; }
		}


	}
}


