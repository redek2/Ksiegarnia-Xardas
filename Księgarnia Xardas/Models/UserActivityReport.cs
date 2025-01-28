public class UserActivityReport
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public int BorrowCount { get; set; }
    public int ReturnCount { get; set; }
}