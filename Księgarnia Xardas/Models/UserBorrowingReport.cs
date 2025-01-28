public class UserBorrowingReport
{
    public string UserId { get; set; }
    public string Title { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime? DateDue { get; set; }
}
