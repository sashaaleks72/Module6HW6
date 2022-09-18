using Module6HW5.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW5.Interfaces
{
    public interface ITeapotDataProvider
    {
        public Task<List<Teapot>> GetTeapots();

        public Task<Teapot> GetTeapotById(Guid id);

        public Task<int> AddTeapot(Teapot teapot);

        public Task<int> EditTeapot(Teapot teapot);

        public Task<int> DeleteTeapot(Teapot teapot);
    }
}
