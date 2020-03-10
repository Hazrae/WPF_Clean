using DAL.Repository;
using DAL.Service;
using ModelLocal.Models;
using ModelLocal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

//ici est listée toutes les actions possible sur la class de la base de donnée
namespace ModelLocal.Services
{
    public class FilmServices : IRepository<Film>
    {
        FilmRepository DalInstance;

        public FilmServices()
        {
            DalInstance = new FilmRepository();
        }

        public void Create(Film f)
        {
            DalInstance.Create(f.ToGlobal());
        }

        public List<Film> GetAll()
        {
            return DalInstance.GetAll().Select(f=>f.ToLocal()).ToList();
        }

        public Film GetOne(int id)
        {
            return DalInstance.GetOne(id).ToLocal();
        }
    }
}
