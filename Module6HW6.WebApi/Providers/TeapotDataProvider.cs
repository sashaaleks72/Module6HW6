using Microsoft.EntityFrameworkCore;
using Module6HW5.DB;
using Module6HW5.Interfaces;
using Module6HW5.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW5.Providers
{
    public class TeapotDataProvider : ITeapotDataProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public TeapotDataProvider(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Teapot>> GetTeapots()
        {
            var teapots = await _dbContext.Teapots.ToListAsync();

            return teapots;
        }

        public async Task<Teapot> GetTeapotById(Guid id)
        {
            var teapot = await _dbContext.Teapots.FirstOrDefaultAsync(x => x.Id == id);

            return teapot;
        }

        public async Task<int> AddTeapot(Teapot teapot)
        {
            await _dbContext.Teapots.AddAsync(teapot);
            int quanOfAddedTeapots = await _dbContext.SaveChangesAsync();

            Console.WriteLine(quanOfAddedTeapots);

            return quanOfAddedTeapots;
        }

        public async Task<int> EditTeapot(Teapot teapot)
        {
            _dbContext.Update(teapot);
            int quanOfChangedTeapots = await _dbContext.SaveChangesAsync();

            return quanOfChangedTeapots;
        }

        public async Task<int> DeleteTeapot(Teapot teapot)
        {
            _dbContext.Teapots.Remove(teapot);
            int quanOfDeletedTeapots = await _dbContext.SaveChangesAsync();

            return quanOfDeletedTeapots;
        }
    }
}
