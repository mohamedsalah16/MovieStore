using MoivestoreMvc.Models.Domin;
using MovieStoreMvc.Models.Domin;

namespace MoivestoreMvc.Models.DTO
{
    public class MoiveListVm
    {
        public IQueryable<Movie> MoiveList { get; set; }
    }
}
