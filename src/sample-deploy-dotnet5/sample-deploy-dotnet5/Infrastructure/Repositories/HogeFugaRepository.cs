using Domain.Models.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class HogeFugaRepository : Repository<HogeFuga>, IHogeFugaRepository
    {
        public HogeFugaRepository(SampleContext context) : base(context)
        {

        }
    }
}
