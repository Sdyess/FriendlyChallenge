using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLibraryAPI.Models
{
    public class Book
    {
        [JsonProperty("publishers")]
        public List<Publisher> Publishers { get; set; }

        [JsonProperty("pagination")]
        public string Pagination { get; set; }

        [JsonProperty("identifiers")]
        public Identifiers Identifiers { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("classifications")]
        public Classification Classifications { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("number_of_pages")]
        public int PageCount { get; set; }

        [JsonProperty("cover")]
        public Cover CoverImages { get; set; }

        [JsonProperty("subjects")]
        public List<Subject> Subjects { get; set; }

        [JsonProperty("publish_date")]
        public string YearPublished { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("authors")]
        public List<Author> Authors { get; set; }

        [JsonProperty("by_statement")]
        public string ByStatement { get; set; }

        [JsonProperty("publish_places")]
        public List<Place> PublishPlaces { get; set; }

        [JsonProperty("ebooks")]
        public List<EBook> EBooks { get; set; }
    }

    public class Publisher
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Identifiers
    {
        public List<string> Lccn { get; set; }
        public List<string> OpenLibrary { get; set; }
        public List<string> Isbn10 { get; set; }
        public List<string> WikiData { get; set; }
        public List<string> LibraryThing { get; set; }
        public List<string> Goodreads { get; set; }
    }

    public class Classification
    {
        [JsonProperty("dewey_decimal_class")]
        public List<string> DeweyDecimal { get; set; }

        [JsonProperty("lc_classifications")]
        public List<string> LcClassification { get; set; }
    }

    public class Cover
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }

    public class Subject
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Author
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Place
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class EBook
    {
        [JsonProperty("formats")]
        public object Formats { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }
    }
}
