namespace MyFirstApp.Models;

public class User
{
    public int Id { get; set; }              // 자동 증가 기본키
    public string Username { get; set; } = "";   // 아이디
    public string PasswordHash { get; set; } = ""; // 암호화된 비밀번호
    public DateTime CreatedAt { get; set; } = DateTime.Now; // 가입일
}