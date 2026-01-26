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
                books = await response.Content.ReadFromJsonAsync<GoogleBooksResponse.Rootobject>();
            }
            return books;
        }
    }
}
