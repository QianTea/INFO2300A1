using GameMarketPlace.Models.DataAccess;
using GameMarketPlace.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using OfficeOpenXml.Style;

namespace GameMarketPlace.Controllers
{
    public class ReportController : Controller
    {
        private readonly MarketContext context;
        private readonly string fileFormat = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ReportController(MarketContext context) 
        {
            this.context = context;
        }

        public FileContentResult GameReport()
        {
            XLWorkbook workbook = new XLWorkbook();
            workbook.Properties.Author = "Conestoga Market";
            workbook.Properties.Title = "Conestoga College Game List";

            IXLWorksheet? excel = workbook.Worksheets.Add("Game List Report");
            excel.Column(1).Width = 20;
            excel.Column(2).Width = 20;
            excel.Column(3).Width = 20;
            excel.Column(4).Width = 20;

            string[] headerValues = { "Game Name", "Price($)", "Phyiscal Editor", "Inventory" };
            for (int headerCol = 0; headerCol < headerValues.Length; headerCol++)
            {
                GenerateHeaderCell(excel, 1, headerCol + 1, headerValues[headerCol], XLColor.Blue, 12, XLBorderStyleValues.Double);
            }

            List<Game> games = GetAllGames();

            int row = 2;
            for (int i = 0; i < games.Count; i++)
            {
                int col = 1;
                GenerateBodyCell(excel, row, col, games[i].GameName);
                GenerateBodyCell(excel, row, ++col, games[i].GamePrice.ToString());
                GenerateBodyCell(excel, row, ++col, games[i].PhysicalEditor);
                GenerateBodyCell(excel, row, ++col, games[i].Inventory.ToString());
                row++;
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            Byte[] fileContent = memoryStream.ToArray();
            memoryStream.Close();

            string title = "Game Report";
            return File(
                fileContent,
                fileFormat,
                title
            );
        }

        public FileContentResult GameDetailReport()
        {
            XLWorkbook workbook = new XLWorkbook();
            workbook.Properties.Author = "Conestoga Market";
            workbook.Properties.Title = "Conestoga College Game List";

            IXLWorksheet? excel = workbook.Worksheets.Add("Game Detail Report");
            excel.Column(1).Width = 20;
            excel.Column(2).Width = 20;
            excel.Column(3).Width = 20;
            excel.Column(4).Width = 20;

            string[] headerValues = { "Game Name", "Publisher", "Release Date", "Genre" };
            for (int headerCol = 0; headerCol < headerValues.Length; headerCol++)
            {
                GenerateHeaderCell(excel, 1, headerCol + 1, headerValues[headerCol], XLColor.Blue, 12, XLBorderStyleValues.Double);
            }

            List<Game> games = GetAllGames();

            int row = 2;
            for (int i = 0; i < games.Count; i++)
            {
                int col = 1;
                GenerateBodyCell(excel, row, col, games[i].GameName);
                GenerateBodyCell(excel, row, ++col, games[i].Publisher);
                GenerateBodyCell(excel, row, ++col, games[i].ReleaseDate.ToShortDateString());
                GenerateBodyCell(excel, row, ++col, GetGenreById(games[i].GenreId));
                row++;
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            Byte[] fileContent = memoryStream.ToArray();
            memoryStream.Close();

            string title = "Game Detail Report";
            return File(
                fileContent,
                fileFormat,
                title
            );
        }

        public FileContentResult MemberReport()
        {
            XLWorkbook workbook = new XLWorkbook();
            workbook.Properties.Author = "Conestoga Market";
            workbook.Properties.Title = "Conestoga College Game List";

            IXLWorksheet? excel = workbook.Worksheets.Add("Member Report");
            excel.Column(1).Width = 40;
            excel.Column(2).Width = 20;
            excel.Column(3).Width = 110;

            string[] headerValues = { "Member Name", "Email Address", "Password" };
            for (int headerCol = 0; headerCol < headerValues.Length; headerCol++)
            {
                GenerateHeaderCell(excel, 1, headerCol + 1, headerValues[headerCol], XLColor.Green, 12, XLBorderStyleValues.Double);
            }

            List<Models.DomainModels.Member> members = GetAllMembers();

            int row = 2;
            for (int i = 0; i < members.Count; i++)
            {
                int col = 1;
                GenerateBodyCell(excel, row, col, members[i].UserName);
                GenerateBodyCell(excel, row, ++col, members[i].Email);
                GenerateBodyCell(excel, row, ++col, members[i].PasswordHash);
                row++;
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            Byte[] fileContent = memoryStream.ToArray();
            memoryStream.Close();

            string title = "Member Report";
            return File(
                fileContent,
                fileFormat,
                title
            );
        }

        public FileContentResult MemberDetailReport()
        {
            XLWorkbook workbook = new XLWorkbook();
            workbook.Properties.Author = "Conestoga Market";
            workbook.Properties.Title = "Conestoga College Game List";

            IXLWorksheet? excel = workbook.Worksheets.Add("Member Details Report");
            excel.Column(2).Width = 30;
            excel.Column(3).Width = 50;
            excel.Column(4).Width = 30;
            excel.Column(5).Width = 30;
            excel.Column(6).Width = 30;

            string[] headerValues = { "Member Name", "Full Name", "Gender", "Date of Birth", "Confirmed Email" };
            for (int headerCol = 0; headerCol < headerValues.Length; headerCol++)
            {
                GenerateHeaderCell(excel, 1, headerCol + 1, headerValues[headerCol], XLColor.Green, 12, XLBorderStyleValues.Double);
            }

            List<Models.DomainModels.Member> members = GetAllMembers();

            int row = 2;
            for (int i = 0; i < members.Count; i++)
            {
                int col = 1;
                GenerateBodyCell(excel, row, col, members[i].UserName);
                GenerateBodyCell(excel, row, ++col, members[i].FirstName + " " + members[i].LastName);
                GenerateBodyCell(excel, row, ++col, GetGenderById(members[i].GenderId));
                GenerateBodyCell(excel, row, ++col, members[i].DateOfBirth.ToShortDateString());
                GenerateBodyCell(excel, row, ++col, members[i].EmailConfirmed.ToString());
                row++;
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            Byte[] fileContent = memoryStream.ToArray();
            memoryStream.Close();

            string title = "Member Detail Report";
            return File(
                fileContent,
                fileFormat,
                title
            );
        }

        public FileContentResult SaleReport()
        {
            XLWorkbook workbook = new XLWorkbook();
            workbook.Properties.Author = "Conestoga Market";
            workbook.Properties.Title = "Conestoga College Game List";

            IXLWorksheet? excel = workbook.Worksheets.Add("Sale Report");
            excel.Column(1).Width = 30;
            excel.Column(2).Width = 30;

            string[] headerValues = { "Game Name", "Sold Number" };
            for (int headerCol = 0; headerCol < headerValues.Length; headerCol++)
            {
                GenerateHeaderCell(excel, 1, headerCol + 1, headerValues[headerCol], XLColor.Blue, 12, XLBorderStyleValues.Double);
            }

            List<Game> games = GetAllGames();

            int row = 2;
            for (int i = 0; i < games.Count; i++)
            {
                int col = 1;
                Random random = new Random();
                long randomNumber = random.NextInt64(100);
                GenerateBodyCell(excel, row, col, games[i].GameName);
                GenerateBodyCell(excel, row, ++col, randomNumber.ToString());
                row++;
            }

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            Byte[] fileContent = memoryStream.ToArray();
            memoryStream.Close();

            string title = "Sale Report";
            return File(
                fileContent,
                fileFormat,
                title
            );
        }

        public void GenerateHeaderCell(IXLWorksheet worksheet, int row, int col, string cellValue, XLColor? bgColour, double fontSize, XLBorderStyleValues borderStyle)
        {
            IXLCell cell = worksheet.Cell(row, col);
            cell.Value = cellValue;
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            cell.Style.Font.SetFontSize(fontSize);
            cell.Style.Font.SetFontColor(XLColor.White);
            cell.Style.Border.OutsideBorder = borderStyle;

            if (bgColour != null)
            {
                cell.Style.Fill.SetBackgroundColor(bgColour);
            }
        }
        public void GenerateBodyCell(IXLWorksheet worksheet, int row, int col, string cellValue)
        {
            IXLCell cell = worksheet.Cell(row, col);
            cell.Value = cellValue;
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        public List<Models.DomainModels.Member> GetAllMembers()
        {
            return context.Members.Where(m => m.UserName != "admin").ToList();
        }
        
        public string GetGenreById(int id)
        {
            Genre genre = context.Genres.First(g => g.GenreId == id);

            if (genre != null)
            {
                return genre.GenreName;
            }

            return "";
        }

        public string GetGenderById(int id)
        {
            Gender gender = context.Genders.First(g => g.GenderId == id);

            if (gender != null)
            {
                return gender.GenderName;
            }

            return "";
        }

        public List<Game> GetAllGames()
        {
            return context.Games.OrderBy(g => g.GameId).ToList();
        }
    }
}
