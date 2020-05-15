
namespace DataAccess.Entities
{
    public class Locality
    {
        public int Id { get; set; }
        public string LocalityName { get; set; }
        public string County { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
