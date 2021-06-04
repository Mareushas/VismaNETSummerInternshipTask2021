using VismaSummerInternshipTask;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaSummerInternshipTask.Tests
{
    public class TaskUtilsTests
    {

        // testing made with custom made JSON data file.
        
        [Fact()]
        public void AddBookTest()
        {
            var books = new BookRegister();

            books.AddBookToCollection(@"Data/Data.json");

            Assert.Equal("Meditacijos", books.GetBooks()[0].Name);
        }

        [Fact()]
        public void TakeBookTest()
        {
            var books = new BookRegister();

            books.AddBookToCollection(@"Data/Data.json");

            Assert.Equal("Meditacijos", books.GetBooks()[0].Name);


            books.SetBookToTaken("Meditacijos", DateTime.Parse("2021-06-04"));

            Assert.True(books.GetBooks()[0].Taken);
            Assert.Equal("2021-06-04", books.GetBooks()[0].WhenTaken.ToString("d"));
        }

        [Fact()]
        public void ReturnBookTest()
        {
            var books = new BookRegister();

            books.AddBookToCollection(@"Data/Data.json");

            Assert.Equal("Meditacijos", books.GetBooks()[0].Name);


            books.SetBookToTaken("Meditacijos", DateTime.Parse("2021-06-04"));

            Assert.True(books.GetBooks()[0].Taken);
            Assert.Equal("2021-06-04", books.GetBooks()[0].WhenTaken.ToString("d"));


            books.SetBookToReturned("Meditacijos", DateTime.Parse("2021-06-05"));

            Assert.False(books.GetBooks()[0].Taken);
            Assert.Equal("2021-06-05", books.GetBooks()[0].WhenReturned.ToString("d"));
        }

        [Fact()]
        public void DeleteAllBooksTest()
        {
            var books = new BookRegister();

            books.AddBookToCollection(@"Data/Data.json");

            Assert.Equal("Meditacijos", books.GetBooks()[0].Name);


            books.RemoveFromLibrary("Meditacijos");

            Assert.Empty(books.GetBooks());
        }

        [Fact()]
        public void DeleteOneBookTest()
        {
            var books = new BookRegister();

            books.AddBookToCollection(@"Data/Data.json");
            books.AddBookToCollection(@"Data/Data.json");
            books.AddBookToCollection(@"Data/Data.json");

            Assert.Single(books.GetBooks());
            Assert.Equal(3, books.GetBooks()[0].Count);


            books.ReduceCount("Meditacijos");

            Assert.Equal(2, books.GetBooks()[0].Count);
        }
    }
}