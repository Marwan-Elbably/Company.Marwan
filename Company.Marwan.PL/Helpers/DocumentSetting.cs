namespace Company.Marwan.PL.Helpers
{
    public class DocumentSetting
    {
        //1. Uplode
        //
        public static string UplodeFile(IFormFile file,string folderName)
        {
            //1. Get Folder Location
            // File Path

            // string folderPath = "C:\\Users\\MG Magic\\Source\\Repos\\Company.Marwan\\Company.Marwan.PL\\wwwroot\\Files\\Images\\"+ folderName;

            // var folderPAth = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + folderName ;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory() , @"wwwroot\Files" , folderName);

            // 2. Get file Name And Get it Uniqe this will be show by user 

            var fileName = $"{Guid.NewGuid()}{file.FileName}";

            var filePath = Path.Combine(folderPath, fileName);

           using var fileStream = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return fileName ;
        }


        //2. Delete
        public static void DeleteFile(string fileName,string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", folderName , fileName);

            if (File.Exists(filePath)) { 
                File.Delete(filePath);
            }


        }




    }
}
