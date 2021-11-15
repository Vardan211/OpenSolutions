using System;

namespace OpenSolutions.Domain.Models
{
    /*
     * у нас из данных - Фамилия, Имя, Дата рождения. Соответственно, если я хочу отфильтровать по Имени, то у меня должна
     * быть возможность найти всех "Иванов" или имена, в которых есть вхождение "ва". Аналогично с Фамилией. Возможно стоит
     * так же заложить CaseIgnore. по Дате рождения - все относительно однозначно. Я, например, должен иметь возможно
     * посмотреть людей с датой рождения 1 января. либо 1 января 1990 года
     */
    public class RecordFilterModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool CaseIgnore { get; set; } = true;
        public string BirthDate { get; set; }
    }
}