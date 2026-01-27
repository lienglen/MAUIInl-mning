using MAUIInlämning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MAUIInlämning.Services
{
    public class APIBookService
    {
        //Allt som pratar med mitt Google Books API ska vara här

        //Skapar en HttpClient för att kunna göra anrop mot API:et
        HttpClient httpClient;
        List<Book> books = new List<Book>();

        //Konstruktor så att HttpClient skapas när klassen instansieras
        public APIBookService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var url = "https://www.googleapis.com/books/v1/volumes?q=subject:fiction&maxResults=20";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                //Läser in JSON-svaret och deserialiserar det till Rootobject
                var rootobject = await response.Content.ReadFromJsonAsync<GoogleBooksResponse.Rootobject>();

                //Rensar listan innan nya böcker läggs till
                books.Clear();

                if (rootobject != null && rootobject.items != null)
                {
                    foreach (var item in rootobject.items)
                    {
                        var volumeInfo = item.volumeInfo;

                        //Skapar en ny Book-instans och mappar data från API:et
                        var book = new Book
                        {
                            Id = item.id.GetHashCode(), // Genererar ett ID baserat på Google Books ID
                            Title = item.volumeInfo.title,
                            Author = item.volumeInfo.authors?[0] ?? "Unknown",
                            Description = item.volumeInfo.description ?? "No description available",
                            ImageUrl = item.volumeInfo.imageLinks?.thumbnail ?? "",
                            
                        };
                        books.Add(book);
                    }
                }
            }
            return books;
        }
    }
}
