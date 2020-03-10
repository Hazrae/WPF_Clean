using ModelLocal.Models;
using ModelLocal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WPF_Clean
{
    class MainViewModel : ViewModelBase
	{

		private ObservableCollection<Film> _listFilms;

		public ObservableCollection<Film> ListeFilm
		{
			get { return _listFilms; }
			set
			{
				if (_listFilms != value)
				{
					_listFilms = value;
					RaisePropertyChanged(nameof(_listFilms));
				}
			}
		}
		public MainViewModel()
		{
			_listFilms = new ObservableCollection<Film>();
			FilmServices fs = new FilmServices();

			List<Film> films = new List<Film>();
			films.AddRange(fs.GetAll());

			foreach (Film item in films)
			{
				_listFilms.Add(item);
			}


		}

		private string _titre;

		public string Titre
		{
			get { return _titre; }
			set
			{
				_titre = value;
				RaisePropertyChanged(nameof(_titre));
			}
		}

		private string _acteur;

		public string Acteur
		{
			get { return _acteur; }
			set { _acteur = value;
				RaisePropertyChanged(nameof(_acteur));
			}
		}

		private string _real;

		public string Real
		{
			get { return _real; }
			set { _real = value;
				RaisePropertyChanged(nameof(_real));
			}
		}


		private int _anneeDeSortie;

		public int AnneeDeSortie
		{
			get { return _anneeDeSortie; }
			set { _anneeDeSortie = value;
				RaisePropertyChanged(nameof(_anneeDeSortie));
			}
		}

		private RelayCommand _ajoutCommand;

		public RelayCommand AjoutCommand
		{
			get { return _ajoutCommand ?? (_ajoutCommand = new RelayCommand(Ajout)); } 

		}

		/*private bool CanAjout()
		{
			return (Titre is null) ? false : ((Acteur is null) ? false : ((Real is null)?false:((AnneeDeSortie == 0)?false:true)));
		}*/

		private void Ajout()
		{
			Film f = new Film
			{
				Titre = Titre,
				ActeurPrincipal = Acteur,
				Realisateur = Real,
				AnneeDeSortie = AnneeDeSortie
			};

			FilmServices fs = new FilmServices();
			fs.Create(f);
			AjoutCollec(f);			
		}

		private void AjoutCollec(Film f)
		{
			_listFilms.Add(f);
			RaisePropertyChanged(nameof(_listFilms));
		}
	}
}
