namespace księgarnia_Xardas.Models
{
    public class TopBorrowedBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int BorrowCount { get; set; }
        public int Rank { get; set; }
    }
}