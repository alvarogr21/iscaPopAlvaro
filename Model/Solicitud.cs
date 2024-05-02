using SQLite;
using SQLiteNetExtensions.Attributes;

namespace iscaPopAlvaro.Model
{
    [Table("Solicitud")]
    public class Solicitud : Base.BaseModel
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }

        private DateTime _momento;
        public DateTime Momento { get { return _momento; } set { SetProperty(ref _momento, value); } }

        [ForeignKey(typeof(Organisme))]
        public int OrganismeId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public Organisme Organisme { get; set; }

        [ForeignKey(typeof(Material))]
        public int MaterialId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public Material Material { get; set; }

        public Solicitud()
        {
        }
    }
}
