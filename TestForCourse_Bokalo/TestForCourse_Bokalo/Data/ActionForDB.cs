using TestForCourse_Bokalo.Models;

namespace TestForCourse_Bokalo.Data
{
    public class ActionForDB
    {
        //це метод для стягнення і додавання даних(а саме папок) у БД з операційної системи
        static public void AddInDbCatalogs(string path)
        {
            using (DbContextApplication db = new DbContextApplication())
            {
                var parentCatalog = new Catalog
                {
                    NameFolder = path.Split('\\')[path.Split('\\').Length - 1],
                    Parent = null,
                };
                db.Catalogs.Add(parentCatalog);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    var innerException = ex.InnerException;
                }
                GetCatalogs(path, db);
            }
        }

        // метод для додавання всіх папок які знаходяться по певному шляху
        static public void GetCatalogs(string path, DbContextApplication db)
        {
            List<string> result = new List<string>();
            if (Directory.GetDirectories(path) != null)
            {
                foreach (string el in Directory.GetDirectories(path))
                {
                    db.Catalogs.Add(
                        new Catalog
                        {
                            // це для того аби додати назву, тому що el має шлях від початку, тобто від C:\\
                            // тому щоб цього уникнути зробив ось таким чином, де шлях сплічу по "\\" і додаю в БД останній елемент
                            NameFolder = el.Split('\\')[el.Split('\\').Length - 1],
                            Parent = db.Catalogs.ToList().First(el => el.NameFolder == path.Split('\\')[path.Split('\\').Length - 1])
                        });
                    db.SaveChanges();
                    GetCatalogs(el, db);
                }
            }
        }
    }
}
