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

        public double GetAvgAge()
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
            var entity = await _context.Records.FirstOrDefaultAsync(x => x.Id == id);

            return new RecordModel
            {
                Id = entity.Id,
                BirthDate = entity.BirthDate.ToShortDateString(),
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        public async Task<GetRecordsResponse> GetAll(RecordFilterModel filters, SortState sort, int skip = 0, int take = 10)
        {
            IQueryable<RecordEntity> query = _context.Records;

            var culture = filters.CaseIgnore
                ? StringComparison.InvariantCultureIgnoreCase
                : StringComparison.InvariantCulture;
            
            if (!string.IsNullOrWhiteSpace(filters.FirstName))
            {
                query = query.Where(x=> EF.Functions.Like(x.FirstName,$"%{filters.FirstName}%"));
            }

            if (!string.IsNullOrWhiteSpace(filters.LastName))
            {
                query = query.Where(x => EF.Functions.Like(x.LastName, $"%{filters.LastName}%"));
            }

            if (!string.IsNullOrWhiteSpace(filters.Id))
            {
                query = query.Where(x => EF.Functions.Like(x.Id.ToString(), $"%{filters.Id}%"));
            }

            if (!string.IsNullOrWhiteSpace(filters.BirthDate))
            {
                query = query.Where(x => EF.Functions.Like(x.BirthDate.ToString(), $"%{filters.BirthDate}%"));
            }

            query = sort switch
            {
                SortState.NameAsc => query.OrderBy(x => x.FirstName),
                SortState.NameDesc => query.OrderByDescending(x => x.FirstName),
                SortState.LastNameAsc => query.OrderBy(x => x.LastName),
                SortState.LastNameDesc => query.OrderByDescending(x => x.LastName),
                SortState.BirthDateAsc => query.OrderBy(x => x.BirthDate),
                SortState.BirthDateDesc => query.OrderByDescending(x => x.BirthDate),
                SortState.IdAsc => query.OrderBy(x => x.Id),
                SortState.IdDesc => query.OrderByDescending(x => x.Id),
                _ => throw new Exception("Wrong input")
            };

            var count = await query.CountAsync();
            query = query.Skip(skip).Take(take);

            var result = new GetRecordsResponse
            {
                Records = await query.Select(entity => new RecordModel
                {
                    Id = entity.Id,
                    BirthDate = entity.BirthDate.ToShortDateString(),
                    FirstName = entity.FirstName,
                    LastName = entity.LastName
                }).ToListAsync(),
                Count = count
            };
            
            return result;
        }
    }
}
