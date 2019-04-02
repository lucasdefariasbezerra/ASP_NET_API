using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nba_stats.Service
{
    public interface IService<T>
    {
        int save(T dto);
        int patch(T dto, int id);
        int put(T dto, int id);
        int delete(int id);
        List<T> getAll();
        T getById(int id);
    }
}
