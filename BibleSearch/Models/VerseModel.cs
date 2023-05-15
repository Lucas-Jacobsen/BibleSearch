namespace BibleApplication.Models
{
    public class VerseModel
    {

        public int Id { get; set; }

        public string Book { get; set; }

        public int Chapter { get; set; }

        public int Verse { get; set; }

        public string Passage { get; set; }

        public VerseModel(int id, string book, int chapter, int verse, string passage)
        {
            Id = id;
            Book = book;
            Chapter = chapter;
            Verse = verse;
        Passage = passage;
        }
    }
}
