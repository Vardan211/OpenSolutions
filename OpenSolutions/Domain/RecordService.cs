using OpenSolutions.DataAccess;
using OpenSolutions.DataAccess.Entities;
using OpenSolutions.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenSolutions.Domain
{
    public class RecordService: IRecordService
    {
        private readonly DataContext _context;

        public RecordService(DataContext context)
        {
            _context = context;
        }
        
        public async Task Add(RecordEntity recordEntity)
        {
            recordEntity.BirthDate = recordEntity.BirthDate.Date;
            await _context.Records.AddAsync(recordEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RecordEntity recordEntity)
        {
            _context.Records.Update(recordEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<double> GetAvgAge()
        {
            return _context.Records.Select(x => Math.Floor((DateTime.UtcNow - x.BirthDate).TotalDays / 365)).ToList().Average();
        }

        public async Task Delete(RecordEntity recordEntity)
        {
            _context.Records.Remove(recordEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<RecordModel> GetById(int id)
        {
            return await _context.Records.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GetRecordsResponse> GetAll(SortState sort, int skip = 0, int take = 10)
        {
            IQueryable<RecordEntity> query;
            var records = _context.Records;

            query = sort switch
            {
                SortState.NameAsc => records.OrderBy(x => x.FirstName),
                SortState.NameDesc => records.OrderByDescending(x => x.FirstName),
                SortState.LastNameAsc => records.OrderBy(x => x.LastName),
                SortState.LastNameDesc => records.OrderByDescending(x => x.LastName),
                SortState.BirthDateAsc => records.OrderBy(x => x.BirthDate),
                SortState.BirthDateDesc => records.OrderByDescending(x => x.BirthDate),
                SortState.IdAsc => records.OrderBy(x => x.Id),
                SortState.IdDesc => records.OrderByDescending(x => x.Id),
                _ => throw new Exception("Wrong input")
            };

            var count = await query.CountAsync();
            query = query.Skip(skip).Take(take);

            var result = new GetRecordsResponse
            {
                Records = await query.ToListAsync(),
                Count = count
            };
            
            return result;
        }
    }
}
