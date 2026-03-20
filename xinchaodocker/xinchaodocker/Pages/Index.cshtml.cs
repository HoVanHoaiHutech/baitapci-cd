using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector; // Thêm thư viện này

namespace xinchaodocker.Pages; // Đổi namespace cho khớp với project của bạn

public class IndexModel : PageModel
{
    // Tạo 2 biến để truyền dữ liệu ra ngoài View
    public string HoTen { get; set; } = "Chưa có dữ liệu";
    public string MSSV { get; set; } = "Chưa có dữ liệu";

    public void OnGet()
    {
        // Chuỗi kết nối khớp với Docker compose bạn vừa cấu hình
        string connectionString = "Server=db;Port=3306;Database=hoai;Uid=root;Pwd=;";

        using var connection = new MySqlConnection(connectionString);
        connection.Open();

        // Lấy dữ liệu từ bảng SinhVien
        using var command = new MySqlCommand("SELECT HoTen, MSSV FROM SinhVien LIMIT 1", connection);
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            HoTen = reader.GetString("HoTen");
            MSSV = reader.GetString("MSSV");
        }
    }
}