using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomework
{

    public class Task2
    {
        List<object> data { get; set; }
        public Task2()
        {
            data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };
        }

        public void Execute()
        {
            Console.WriteLine("1. Выведите имена всех актеров.");

            foreach (var films in data.Where(o => o.GetType() == typeof(Film)))
            {
                var film = (Film)films;
                foreach (var actor in film.Actors)
                    Console.WriteLine(actor.Name);
            }

            Console.WriteLine("2. Выведите количество актеров родившихся в августе.");
            Console.WriteLine("_________________________________________________");

            int countOfBirth = 0;
            foreach (var films in data.Where(o => o.GetType() == typeof(Film)))
            {
                var film = (Film)films;
                foreach (var actor in film.Actors)
                    if (actor.Birthdate.Month == 8)
                        countOfBirth++;
            }
            Console.WriteLine(countOfBirth);
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("3. Выведите имена двух самых старых актеров.");
            var actors = new List<Actor>();
            foreach (var films in data.Where(o => o.GetType() == typeof(Film)))
            {
                var film = (Film)films;
                foreach (var actor in film.Actors)
                    actors.Add(actor);
            }
            actors = actors.OrderBy(o => o.Birthdate).ToList();
            Console.WriteLine(actors[0].Name);
            Console.WriteLine(actors[1].Name);
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("4. Выведите количество статей на каждого автора.");
            var articlesAuthors = new List<string>();
            var articles = new List<Article>();

            foreach (var article in data.Where(o => o.GetType() == typeof(Article)))
            {
                var formatted = (Article)article;
                articlesAuthors.Add(formatted.Author);
                articles.Add(formatted);
            }
            articlesAuthors = articlesAuthors.Distinct().ToList();
            foreach (var author in articlesAuthors)
                Console.WriteLine($"{author} - {articles.Count(o => o.Author == author)} ");
            Console.WriteLine("_________________________________________________");


            Console.WriteLine("5. Выведите количество статей по авторам и фильмов по режиссеру.");
            var authors = new List<string>();
            var artObjects = new List<ArtObject>();

            foreach (var artObject in data.Where(o => o.GetType() == typeof(Film) || o.GetType() == typeof(Article)))
            {
                var formatted = (ArtObject)artObject;
                authors.Add(formatted.Author);
                artObjects.Add(formatted);
            }
            authors = authors.Distinct().ToList();
            foreach (var author in authors)
                Console.WriteLine($"{author} - {artObjects.Count(o => o.Author == author)} ");
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("6. Выведите сколько разных букв используется во всех именах актеров.");
            string actorNames = "";
            foreach (var films in data.Where(o => o.GetType() == typeof(Film)))
            {
                var film = (Film)films;
                foreach (var actor in film.Actors)
                    actorNames += actor.Name.ToLower().Trim();
            }
            Console.WriteLine($"{actorNames.Distinct().Count()}");
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("7. Выведите названия всех статей, отсортированных по фамилиям их авторов и количеству страниц.");
            foreach(var sorted in articles.OrderBy(o => o.Author).OrderBy(o => o.Pages))
                Console.WriteLine(sorted.Name);
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("8. Выведите имя актера и все фильмы с этим актером.");
            var _actorNames = new List<string>();
            var _films = new List<Film>();
            foreach (var films in data.Where(o => o.GetType() == typeof(Film)))
            {
                var film = (Film)films;
                _films.Add(film);
                foreach (var actor in film.Actors)
                    _actorNames.Add(actor.Name);
            }
            _actorNames = _actorNames.Distinct().ToList();
            foreach(var actor in _actorNames)
            {
                Console.WriteLine($"{actor}:\t");
                foreach(var films in _films.Where(o=>o.Actors.Any(o=>o.Name == actor)))
                {
                    Console.WriteLine($"\t{films.Name}");
                }
            }
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("9. Выведите сумму общего количества страниц во всех статьях и во всех значениях int во всех последовательностях данных.");
            int articlePagesSum = articles.Select(o => o.Pages).Sum();
            var intList = (List<int>)data[2];
            var intListSum = intList.Sum();
            Console.WriteLine(articlePagesSum + intListSum);
            Console.WriteLine("_________________________________________________");

            Console.WriteLine("10. Получить словарь с ключом — автор статьи, значение — список статей.");
            var authorAndHisArticles = new Dictionary<string, List<Article>>();
            foreach(var author in articlesAuthors)
                authorAndHisArticles.Add(author, articles.Where(o => o.Author == author).ToList());

            foreach (var obj in authorAndHisArticles)
                Console.WriteLine($"{obj.Key} {obj.Value.Count}");

        }
    }
}
