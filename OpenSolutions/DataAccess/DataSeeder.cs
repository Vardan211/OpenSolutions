using OpenSolutions.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.DataAccess
{
    public class DataSeeder
    {
        private readonly DataContext _context;
        public DataSeeder(DataContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            if(!_context.Records.Any())
            {
                var records = new List<RecordEntity>()
                {
                    new RecordEntity()
                    {
                        Id = 1,
                        LastName = "Сурков",
                        FirstName = "Владимир",
                        BirthDate = new DateTime(2002,08,02)
                    },
                    new RecordEntity()
                    {
                        Id = 2,
                        LastName = "Исакова",
                        FirstName = "Виктория",
                        BirthDate = new DateTime(1986,02,01)
                    },
                    new RecordEntity()
                    {
                        Id = 3,
                        LastName = "Лопатина",
                        FirstName = "Вероника",
                        BirthDate = new DateTime(1977,03,21)
                    },
                    new RecordEntity()
                    {
                        Id = 4,
                        LastName = "Алексеева",
                        FirstName = "Анна",
                        BirthDate = new DateTime(1999,06,13)
                    },
                    new RecordEntity()
                    {
                        Id = 5,
                        LastName = "Королева",
                        FirstName = "Милана",
                        BirthDate = new DateTime(2001,01,11)
                    },
                    new RecordEntity()
                    {
                        Id = 6,
                        LastName = "Павлов",
                        FirstName = "Лев",
                        BirthDate = new DateTime(1987,09,13)
                    },
                    new RecordEntity()
                    {
                        Id = 7,
                        LastName = "Кудряшова",
                        FirstName = "Эмилия",
                        BirthDate = new DateTime(1976,04,04)
                    },
                    new RecordEntity()
                    {
                        Id = 8,
                        LastName = "Григорьев",
                        FirstName = "Фёдор",
                        BirthDate = new DateTime(1995,07,19)
                    },
                    new RecordEntity()
                    {
                        Id = 9,
                        LastName = "Суханова",
                        FirstName = "Майя",
                        BirthDate = new DateTime(1975,04,24)
                    },
                    new RecordEntity()
                    {
                        Id = 10,
                        LastName = "Колесникова",
                        FirstName = "Ксения",
                        BirthDate = new DateTime(1978,10,01)
                    },
                    new RecordEntity()
                    {
                        Id = 11,
                        LastName = "Сорокина",
                        FirstName = "Виктория",
                        BirthDate = new DateTime(2006,12,21)
                    },
                    new RecordEntity()
                    {
                        Id = 12,
                        LastName = "Федорова",
                        FirstName = "Елизавета",
                        BirthDate = new DateTime(1969,08,16)
                    },
                    new RecordEntity()
                    {
                        Id = 13,
                        LastName = "Демидова",
                        FirstName = "Екатерина",
                        BirthDate = new DateTime(1998,09,07)
                    },
                    new RecordEntity()
                    {
                        Id = 14,
                        LastName = "Карташов",
                        FirstName = "Иван",
                        BirthDate = new DateTime(2009,04,12)
                    },
                    new RecordEntity()
                    {
                        Id = 15,
                        LastName = "Куликов",
                        FirstName = "Артём",
                        BirthDate = new DateTime(2003,07,11)
                    },
                    new RecordEntity()
                    {
                        Id = 16,
                        LastName = "Мельникова",
                        FirstName = "Карина",
                        BirthDate = new DateTime(1986,02,01)
                    },
                    new RecordEntity()
                    {
                        Id = 17,
                        LastName = "Кузнецов",
                        FirstName = "Роман",
                        BirthDate = new DateTime(1986,01,01)
                    },
                    new RecordEntity()
                    {
                        Id = 18,
                        LastName = "Овчинников",
                        FirstName = "Александр",
                        BirthDate = new DateTime(1988,02,01)
                    },
                    new RecordEntity()
                    {
                        Id = 19,
                        LastName = "Ульянова",
                        FirstName = "Алина",
                        BirthDate = new DateTime(1990,04,02)
                    },
                    new RecordEntity()
                    {
                        Id = 20,
                        LastName = "Мельников",
                        FirstName = "Демид",
                        BirthDate = new DateTime(1986,02,01)
                    }
                };
                await _context.Records.AddRangeAsync(records);
                await _context.SaveChangesAsync();
            }
        }
    }
}
