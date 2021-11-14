using Microsoft.EntityFrameworkCore;
using OpenSolutions.DataAccess;
using OpenSolutions.DataAccess.Entities;
using OpenSolutions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.Domain
{
    public class RecordService:IRecordService
    {
        private readonly DataContext _context;

        public RecordService(DataContext context)
        {
            _context = context;
        }

        private List<RecordEntity> Records { get; set; } = new List<RecordEntity>
        {
            new RecordEntity
                {
                    Id = 1, LastName = "Акимов", FirstName = "Семён", BirthDate = new DateTime(2002, 08, 02)
                },
                  new RecordEntity
                {
                    Id = 2, LastName = "Королев", FirstName = "Даниил", BirthDate = new DateTime(1991, 07, 06)
                },
                  new RecordEntity
                {
                    Id = 3, LastName = "Малахова", FirstName = "Вероника", BirthDate = new DateTime(2011, 05, 02)
                },
                  new RecordEntity
                {
                    Id = 4, LastName = "Головина", FirstName = "Софья", BirthDate = new DateTime(1992, 08, 04)
                },
                  new RecordEntity
                {
                    Id = 5, LastName = "Иванова", FirstName = "Варвара", BirthDate = new DateTime(2012, 03, 02)
                },
                  new RecordEntity
                {
                    Id = 6, LastName = "Захаров", FirstName = "Даниил", BirthDate = new DateTime(2006, 02, 01)
                },
                  new RecordEntity
                {
                    Id = 7, LastName = "Максимова", FirstName = "Дарина", BirthDate = new DateTime(1986, 07, 21)
                },
                  new RecordEntity
                {
                    Id = 8, LastName = "Мешков", FirstName = "Марк", BirthDate = new DateTime(2001, 11, 17)
                },
                  new RecordEntity
                {
                    Id = 9, LastName = "Шевелев", FirstName = "Марк", BirthDate = new DateTime(1975, 03, 13)
                },
                  new RecordEntity
                {
                    Id = 10, LastName = "Суханов", FirstName = "Даниил", BirthDate = new DateTime(2001, 09, 27)
                },
        };

        public async Task Add(RecordEntity recordEntity)
        {

            recordEntity.BirthDate = recordEntity.BirthDate.Date;
            await _context.Records.AddAsync(recordEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Change(RecordEntity recordEntity)
        {
            _context.Records.Update(recordEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(RecordEntity recordEntity)
        {
            _context.Records.Remove(recordEntity);
            await _context.SaveChangesAsync();
        }

        public List<RecordEntity> GetAll()
        {
            return _context.Records.ToList();
        }

        public List<RecordEntity> Sorting(Enum sort)
        {
           switch(sort)
            {
                case SortState.NameAsc:
                    var result = from u in _context.Records
                                 orderby u.FirstName ascending
                                 select u;
                    return (List<RecordEntity>)result;
                case SortState.NameDesc:
                    result = from u in _context.Records
                                 orderby u.FirstName descending
                                 select u;
                    return (List<RecordEntity>)result;
                case SortState.LastNameAsc:
                    result = from u in _context.Records
                                 orderby u.LastName ascending
                                 select u;
                    return (List<RecordEntity>)result;
                case SortState.LastNameDesc:
                    result = from u in _context.Records
                             orderby u.LastName descending
                             select u;
                    return (List<RecordEntity>)result;
                case SortState.DateAsc:
                    result = from u in _context.Records
                             orderby u.BirthDate ascending
                             select u;
                    return (List<RecordEntity>)result;
                case SortState.DateDesc:
                    result = from u in _context.Records
                             orderby u.BirthDate descending
                             select u;
                    return (List<RecordEntity>)result;
                default:
                    throw new Exception("Wrong input");
            }

        }
        public IEnumerable<RecordEntity> GetRecords()
        {
            RecordParameters recordParameters = new RecordParameters();
            return _context.Records
                .OrderBy(on => on.FirstName)
                .Skip((recordParameters.PageNumber - 1) * recordParameters.PageSize)
                .Take(recordParameters.PageSize)
                .ToList();
        }
    }
    public enum SortState
    {
        NameAsc,
        NameDesc,
        LastNameAsc,
        LastNameDesc,
        AgeAsc,
        AgeDesc,
        DateAsc,
        DateDesc
    }
}
