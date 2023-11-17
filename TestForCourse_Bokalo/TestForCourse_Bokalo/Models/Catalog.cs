namespace TestForCourse_Bokalo.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string NameFolder {  get; set; }
        public int? ParentId { get; set; }
        public Catalog? Parent { get; set; }
        public ICollection<Catalog>? SubCatalogs { get; set; }
    }
}
