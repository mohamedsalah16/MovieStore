using MoivestoreMvc.Models.Domin;
using MovieStoreMvc.Models.Domin;

namespace MoivestoreMvc.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
       
    }
}
