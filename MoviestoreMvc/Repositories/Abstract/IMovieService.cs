using MoivestoreMvc.Models.Domin;
using MoivestoreMvc.Models.DTO;
using MovieStoreMvc.Models.Domin;

namespace MoivestoreMvc.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);
        bool Update(Movie model);
        Movie GetById(int id);
        bool Delete(int id);
        MoiveListVm List();
        List<int> GetGenreByMovieId(int movieId);
    }
}
